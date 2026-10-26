using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using _2InvestigacionFormativa.Models;
using _2InvestigacionFormativa.Services;

namespace _2InvestigacionFormativa
{
    public partial class Form1 : Form
    {
        private readonly DatabaseService _databaseService;
        private readonly MLService _mlService;
        private readonly Timer _debounceTimer;

        private string _ultimaCategoriaSugerida = string.Empty;
        private double _ultimaConfianzaSugerida = 0.0;
        private Transaccion _transaccionEnEdicion = null;

        public Form1()
        {
            InitializeComponent();

            _debounceTimer = new Timer { Interval = 400 };
            _debounceTimer.Tick += DebounceTimer_Tick;

            try
            {
                _databaseService = new DatabaseService();
                _mlService = new MLService();

                // Selectores iniciales
                if (_cmbCategoria.Items.Count > 0) _cmbCategoria.SelectedIndex = 0;
                if (_cmbFiltroHistorial.Items.Count > 0) _cmbFiltroHistorial.SelectedIndex = 0;
                if (_cmbFiltroPeriodo.Items.Count > 0) _cmbFiltroPeriodo.SelectedIndex = 0;
                if (_cmbNuevaCategoria.Items.Count > 0) _cmbNuevaCategoria.SelectedIndex = 0;

                // Carga inicial de datos en las 4 pestañas
                ActualizarHistorial();
                CargarDashboard();
                CargarDatosEntrenamiento();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al inicializar la aplicación: " + ex.Message,
                    "Error de inicio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Pestaña 1: Dashboard Financiero

        private void CmbFiltroPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDashboard();
        }

        private void BtnActualizarDashboard_Click(object sender, EventArgs e)
        {
            CargarDashboard();
        }

        private void ObtenerRangoFechasFiltro(out DateTime? inicio, out DateTime? fin)
        {
            inicio = null;
            fin = null;
            int sel = _cmbFiltroPeriodo.SelectedIndex;

            if (sel == 1) // Este mes
            {
                var ahora = DateTime.Now;
                inicio = new DateTime(ahora.Year, ahora.Month, 1);
                fin = inicio.Value.AddMonths(1).AddSeconds(-1);
            }
            else if (sel == 2) // Últimos 30 días
            {
                fin = DateTime.Now;
                inicio = fin.Value.AddDays(-30);
            }
            else if (sel == 3) // Este año
            {
                var ahora = DateTime.Now;
                inicio = new DateTime(ahora.Year, 1, 1);
                fin = new DateTime(ahora.Year, 12, 31, 23, 59, 59);
            }
        }

        private void CargarDashboard()
        {
            if (_databaseService == null) return;

            try
            {
                ObtenerRangoFechasFiltro(out var fechaInicio, out var fechaFin);

                var transacciones = _databaseService.ObtenerTransacciones(null, null, fechaInicio, fechaFin);
                var resumen = _databaseService.ObtenerResumenPorCategoria(fechaInicio, fechaFin);

                decimal totalGasto = resumen.Sum(r => r.TotalMonto);
                int totalTransacciones = transacciones.Count;

                // Actualizar tarjetas KPI
                _lblKpi1Valor.Text = totalGasto.ToString("C2");

                _lblKpi2Valor.Text = totalTransacciones.ToString();

                if (resumen.Count > 0)
                {
                    var mayor = resumen[0];
                    _lblKpi3Valor.Text = mayor.Categoria;
                    _lblKpi3Sub.Text = $"{mayor.TotalMonto:C2} ({mayor.PorcentajeDelTotal:F1}%)";
                }
                else
                {
                    _lblKpi3Valor.Text = "Sin gastos";
                    _lblKpi3Sub.Text = "$0.00 (0%)";
                }

                // Certeza promedio de IA registrada
                var transaccionesConIA = transacciones.Where(t => t.ConfianzaIA > 0).ToList();
                double promedioConfianza = transaccionesConIA.Count > 0
                    ? transaccionesConIA.Average(t => t.ConfianzaIA) * 100.0
                    : 100.0;
                _lblKpi4Valor.Text = $"{promedioConfianza:F1}%";
                _lblKpi4Sub.Text = $"{transaccionesConIA.Count} predicciones analizadas";

                // Actualizar Gráfico de Dona (Pie)
                _chartPie.Series["Categorias"].Points.Clear();
                _chartBar.Series["MontoTotal"].Points.Clear();

                Color[] paletaColores = new Color[]
                {
                    Color.FromArgb(52, 152, 219),  // Azul
                    Color.FromArgb(46, 204, 113),  // Verde
                    Color.FromArgb(155, 89, 182),  // Púrpura
                    Color.FromArgb(241, 196, 15),  // Amarillo
                    Color.FromArgb(231, 76, 60),   // Rojo
                    Color.FromArgb(26, 188, 156),  // Turquesa
                    Color.FromArgb(230, 126, 34)   // Naranja
                };

                int colorIdx = 0;
                foreach (var item in resumen)
                {
                    var color = paletaColores[colorIdx % paletaColores.Length];
                    colorIdx++;

                    // Gráfico de Dona
                    int ptPieIdx = _chartPie.Series["Categorias"].Points.AddXY(item.Categoria, (double)item.TotalMonto);
                    var ptPie = _chartPie.Series["Categorias"].Points[ptPieIdx];
                    ptPie.Color = color;
                    ptPie.LegendText = $"{item.Categoria} ({item.PorcentajeDelTotal:F1}%)";
                    ptPie.ToolTip = $"{item.Categoria}: {item.TotalMonto:C2} ({item.PorcentajeDelTotal:F1}%)";

                    // Gráfico de Barras
                    int ptBarIdx = _chartBar.Series["MontoTotal"].Points.AddXY(item.Categoria, (double)item.TotalMonto);
                    var ptBar = _chartBar.Series["MontoTotal"].Points[ptBarIdx];
                    ptBar.Color = color;
                    ptBar.ToolTip = $"{item.Categoria}: {item.TotalMonto:C2}";
                }

                // Actualizar tabla resumen
                _dgvResumenCategorias.DataSource = null;
                _dgvResumenCategorias.DataSource = resumen;

                if (_dgvResumenCategorias.Columns.Count > 0)
                {
                    _dgvResumenCategorias.Columns[nameof(ResumenCategoria.Categoria)].HeaderText = "Categoría";
                    _dgvResumenCategorias.Columns[nameof(ResumenCategoria.Categoria)].FillWeight = 160;

                    _dgvResumenCategorias.Columns[nameof(ResumenCategoria.TotalMonto)].HeaderText = "Total Gastado";
                    _dgvResumenCategorias.Columns[nameof(ResumenCategoria.TotalMonto)].DefaultCellStyle.Format = "C2";
                    _dgvResumenCategorias.Columns[nameof(ResumenCategoria.TotalMonto)].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    _dgvResumenCategorias.Columns[nameof(ResumenCategoria.TotalMonto)].Width = 140;

                    _dgvResumenCategorias.Columns[nameof(ResumenCategoria.PorcentajeDelTotal)].HeaderText = "% del Total";
                    _dgvResumenCategorias.Columns[nameof(ResumenCategoria.PorcentajeDelTotal)].DefaultCellStyle.Format = "N1";
                    _dgvResumenCategorias.Columns[nameof(ResumenCategoria.PorcentajeDelTotal)].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    _dgvResumenCategorias.Columns[nameof(ResumenCategoria.PorcentajeDelTotal)].Width = 110;

                    _dgvResumenCategorias.Columns[nameof(ResumenCategoria.CantidadTransacciones)].HeaderText = "N° Transacciones";
                    _dgvResumenCategorias.Columns[nameof(ResumenCategoria.CantidadTransacciones)].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    _dgvResumenCategorias.Columns[nameof(ResumenCategoria.CantidadTransacciones)].Width = 130;

                    _dgvResumenCategorias.Columns[nameof(ResumenCategoria.PromedioPorTransaccion)].HeaderText = "Promedio / Gasto";
                    _dgvResumenCategorias.Columns[nameof(ResumenCategoria.PromedioPorTransaccion)].DefaultCellStyle.Format = "C2";
                    _dgvResumenCategorias.Columns[nameof(ResumenCategoria.PromedioPorTransaccion)].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    _dgvResumenCategorias.Columns[nameof(ResumenCategoria.PromedioPorTransaccion)].Width = 140;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el Dashboard: " + ex.Message,
                    "Error Dashboard", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Pestaña 2: Registro y Gestión de Gastos

        private void TxtDescripcion_TextChanged(object sender, EventArgs e)
        {
            // Solo predecir automáticamente si estamos ingresando uno nuevo y el texto tiene al menos 3 caracteres
            if (_transaccionEnEdicion == null)
            {
                _debounceTimer.Stop();
                if (_txtDescripcion.Text.Trim().Length >= 3)
                {
                    _debounceTimer.Start();
                }
                else
                {
                    LimpiarSugerenciaIA();
                }
            }
        }

        private void DebounceTimer_Tick(object sender, EventArgs e)
        {
            _debounceTimer.Stop();
            EjecutarPrediccionVisual(esManual: false);
        }

        private void BtnPredecirIA_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_txtDescripcion.Text))
            {
                MessageBox.Show("Escribe una descripción del gasto para que la IA pueda clasificarlo.",
                    "Dato requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _txtDescripcion.Focus();
                return;
            }

            EjecutarPrediccionVisual(esManual: true);
        }

        private void EjecutarPrediccionVisual(bool esManual)
        {
            try
            {
                string texto = _txtDescripcion.Text.Trim();
                if (string.IsNullOrWhiteSpace(texto)) return;

                var resultado = _mlService.PredecirDetalle(texto);

                if (!string.IsNullOrEmpty(resultado.Categoria))
                {
                    _ultimaCategoriaSugerida = resultado.Categoria;
                    _ultimaConfianzaSugerida = resultado.Confianza;

                    _lblSugerenciaIA.Text = $"Sugerencia: {resultado.Categoria}";

                    // Formatear Badge de Certeza con colores según confiabilidad
                    _lblConfianzaBadge.Text = $"Certeza: {resultado.ConfianzaTexto}";
                    if (resultado.Confianza >= 0.40)
                    {
                        _lblConfianzaBadge.BackColor = Color.FromArgb(212, 239, 223);
                        _lblConfianzaBadge.ForeColor = Color.FromArgb(20, 90, 50);
                    }
                    else if (resultado.Confianza >= 0.28)
                    {
                        _lblConfianzaBadge.BackColor = Color.FromArgb(254, 249, 231);
                        _lblConfianzaBadge.ForeColor = Color.FromArgb(125, 102, 8);
                    }
                    else
                    {
                        _lblConfianzaBadge.BackColor = Color.FromArgb(250, 219, 216);
                        _lblConfianzaBadge.ForeColor = Color.FromArgb(146, 43, 33);
                    }

                    // Auto-seleccionar en el ComboBox de categoría confirmada
                    int indice = _cmbCategoria.FindStringExact(resultado.Categoria);
                    if (indice >= 0)
                    {
                        _cmbCategoria.SelectedIndex = indice;
                    }
                }
                else
                {
                    LimpiarSugerenciaIA();
                }
            }
            catch (Exception ex)
            {
                if (esManual)
                {
                    MessageBox.Show("Error durante la predicción: " + ex.Message, "Error IA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LimpiarSugerenciaIA()
        {
            _ultimaCategoriaSugerida = string.Empty;
            _ultimaConfianzaSugerida = 0.0;
            _lblSugerenciaIA.Text = "Sugerencia: (Sin predicción)";
            _lblConfianzaBadge.Text = "Certeza: -";
            _lblConfianzaBadge.BackColor = Color.FromArgb(236, 240, 241);
            _lblConfianzaBadge.ForeColor = Color.FromArgb(52, 73, 94);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario()) return;

            try
            {
                string sugerida = _ultimaCategoriaSugerida;
                double confianza = _ultimaConfianzaSugerida;

                if (string.IsNullOrEmpty(sugerida))
                {
                    var pred = _mlService.PredecirDetalle(_txtDescripcion.Text.Trim());
                    sugerida = pred.Categoria;
                    confianza = pred.Confianza;
                }

                var transaccion = new Transaccion
                {
                    Fecha = _dtpFecha.Value,
                    Descripcion = _txtDescripcion.Text.Trim(),
                    Monto = _numMonto.Value,
                    CategoriaSugeridaIA = sugerida,
                    CategoriaConfirmada = _cmbCategoria.SelectedItem.ToString(),
                    ConfianzaIA = confianza
                };

                _databaseService.GuardarTransaccion(transaccion);

                LimpiarFormularioRegistro();
                ActualizarHistorial();
                CargarDashboard();

                MessageBox.Show("¡Transacción registrada exitosamente en SQLite!",
                    "Registro Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la transacción: " + ex.Message,
                    "Error de base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            if (_transaccionEnEdicion == null) return;
            if (!ValidarFormulario()) return;

            try
            {
                _transaccionEnEdicion.Fecha = _dtpFecha.Value;
                _transaccionEnEdicion.Descripcion = _txtDescripcion.Text.Trim();
                _transaccionEnEdicion.Monto = _numMonto.Value;
                _transaccionEnEdicion.CategoriaConfirmada = _cmbCategoria.SelectedItem.ToString();

                // Si cambió la descripción, recalcular la sugerencia IA
                if (!string.Equals(_transaccionEnEdicion.Descripcion, _txtDescripcion.Text.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    var pred = _mlService.PredecirDetalle(_txtDescripcion.Text.Trim());
                    _transaccionEnEdicion.CategoriaSugeridaIA = pred.Categoria;
                    _transaccionEnEdicion.ConfianzaIA = pred.Confianza;
                }

                _databaseService.ActualizarTransaccion(_transaccionEnEdicion);

                MessageBox.Show($"¡Transacción #{_transaccionEnEdicion.Id} actualizada correctamente!",
                    "Actualización Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormularioRegistro();
                ActualizarHistorial();
                CargarDashboard();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la transacción: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelarEdicion_Click(object sender, EventArgs e)
        {
            LimpiarFormularioRegistro();
        }

        private bool ValidarFormulario()
        {
            if (string.IsNullOrWhiteSpace(_txtDescripcion.Text))
            {
                MessageBox.Show("Por favor ingresa la descripción del gasto.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _txtDescripcion.Focus();
                return false;
            }

            if (_numMonto.Value <= 0)
            {
                MessageBox.Show("El monto debe ser un valor mayor a cero.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _numMonto.Focus();
                return false;
            }

            if (_cmbCategoria.SelectedItem == null)
            {
                MessageBox.Show("Debes seleccionar una categoría confirmada.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void LimpiarFormularioRegistro()
        {
            _transaccionEnEdicion = null;
            _txtDescripcion.Clear();
            _numMonto.Value = 0;
            _dtpFecha.Value = DateTime.Now;
            _cmbCategoria.SelectedIndex = 0;
            LimpiarSugerenciaIA();

            _btnActualizar.Enabled = false;
            _btnGuardar.Enabled = true;
            _txtDescripcion.Focus();
        }

        private void DgvTransacciones_SelectionChanged(object sender, EventArgs e)
        {
            if (_dgvTransacciones.CurrentRow?.DataBoundItem is Transaccion t)
            {
                _transaccionEnEdicion = t;
                _txtDescripcion.Text = t.Descripcion;
                _numMonto.Value = t.Monto;
                _dtpFecha.Value = t.Fecha;

                int idx = _cmbCategoria.FindStringExact(t.CategoriaConfirmada);
                if (idx >= 0) _cmbCategoria.SelectedIndex = idx;

                _lblSugerenciaIA.Text = $"Sugerida: {t.CategoriaSugeridaIA}";
                _lblConfianzaBadge.Text = t.ConfianzaIA > 0 ? $"Certeza: {t.ConfianzaIA * 100.0:F1}%" : "Certeza: -";

                _btnActualizar.Enabled = true;
                _btnGuardar.Enabled = false;
            }
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            ActualizarHistorial();
        }

        private void CmbFiltroHistorial_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarHistorial();
        }

        private void ActualizarHistorial()
        {
            if (_databaseService == null) return;

            try
            {
                string filtroTexto = _txtBuscar.Text.Trim();
                string filtroCat = _cmbFiltroHistorial.SelectedItem?.ToString();

                var transacciones = _databaseService.ObtenerTransacciones(filtroTexto, filtroCat);

                _dgvTransacciones.DataSource = null;
                _dgvTransacciones.DataSource = transacciones;

                if (_dgvTransacciones.Columns.Count > 0)
                {
                    _dgvTransacciones.Columns[nameof(Transaccion.Id)].HeaderText = "ID";
                    _dgvTransacciones.Columns[nameof(Transaccion.Id)].Width = 50;
                    _dgvTransacciones.Columns[nameof(Transaccion.Id)].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    _dgvTransacciones.Columns[nameof(Transaccion.Fecha)].HeaderText = "Fecha";
                    _dgvTransacciones.Columns[nameof(Transaccion.Fecha)].DefaultCellStyle.Format = "g";
                    _dgvTransacciones.Columns[nameof(Transaccion.Fecha)].Width = 140;

                    _dgvTransacciones.Columns[nameof(Transaccion.Descripcion)].HeaderText = "Descripción";
                    _dgvTransacciones.Columns[nameof(Transaccion.Descripcion)].FillWeight = 200;

                    _dgvTransacciones.Columns[nameof(Transaccion.Monto)].HeaderText = "Monto";
                    _dgvTransacciones.Columns[nameof(Transaccion.Monto)].DefaultCellStyle.Format = "C2";
                    _dgvTransacciones.Columns[nameof(Transaccion.Monto)].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    _dgvTransacciones.Columns[nameof(Transaccion.Monto)].Width = 110;

                    _dgvTransacciones.Columns[nameof(Transaccion.CategoriaSugeridaIA)].HeaderText = "Sugerencia IA";
                    _dgvTransacciones.Columns[nameof(Transaccion.CategoriaSugeridaIA)].Width = 140;

                    _dgvTransacciones.Columns[nameof(Transaccion.ConfianzaIA)].HeaderText = "Certeza IA";
                    _dgvTransacciones.Columns[nameof(Transaccion.ConfianzaIA)].DefaultCellStyle.Format = "0.0%";
                    _dgvTransacciones.Columns[nameof(Transaccion.ConfianzaIA)].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    _dgvTransacciones.Columns[nameof(Transaccion.ConfianzaIA)].Width = 95;

                    _dgvTransacciones.Columns[nameof(Transaccion.CategoriaConfirmada)].HeaderText = "Categoría Confirmada";
                    _dgvTransacciones.Columns[nameof(Transaccion.CategoriaConfirmada)].Width = 160;
                }

                decimal total = transacciones.Sum(t => t.Monto);
                _lblEstadisticas.Text = $"💡 Total registros listados: {transacciones.Count}  |  Gasto sumado: {total:C2}  (Haz clic en cualquier fila para editarla)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar historial: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvTransacciones_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (_dgvTransacciones.Columns[e.ColumnIndex].Name == nameof(Transaccion.CategoriaConfirmada) && e.Value != null)
            {
                e.CellStyle.Font = new Font(_dgvTransacciones.Font, FontStyle.Bold);
            }
        }

        private void BtnBorrarTransaccion_Click(object sender, EventArgs e)
        {
            if (_dgvTransacciones.CurrentRow?.DataBoundItem is Transaccion transaccion)
            {
                var confirmacion = MessageBox.Show(
                    $"¿Deseas eliminar permanentemente la transacción #{transaccion.Id} '{transaccion.Descripcion}'?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    try
                    {
                        _databaseService.EliminarTransaccion(transaccion.Id);
                        LimpiarFormularioRegistro();
                        ActualizarHistorial();
                        CargarDashboard();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar la transacción: " + ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona una transacción en la tabla para eliminar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnExportarCsv_Click(object sender, EventArgs e)
        {
            var transacciones = _databaseService.ObtenerTransacciones(_txtBuscar.Text.Trim(), _cmbFiltroHistorial.SelectedItem?.ToString());

            if (transacciones == null || transacciones.Count == 0)
            {
                MessageBox.Show("No hay transacciones para exportar con el filtro actual.",
                    "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Archivo CSV (*.csv)|*.csv";
                sfd.FileName = $"Reporte_Gastos_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var sb = new StringBuilder();
                        sb.AppendLine("ID;Fecha;Descripcion;Monto;CategoriaSugeridaIA;CertezaIA;CategoriaConfirmada");

                        foreach (var t in transacciones)
                        {
                            sb.AppendLine($"{t.Id};{t.Fecha:yyyy-MM-dd HH:mm:ss};\"{t.Descripcion.Replace("\"", "\"\"")}\";{t.Monto};\"{t.CategoriaSugeridaIA}\";{t.ConfianzaIA:F4};\"{t.CategoriaConfirmada}\"");
                        }

                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);

                        MessageBox.Show($"¡Archivo exportado exitosamente!\n\nRuta: {sfd.FileName}\nTotal registros: {transacciones.Count}",
                            "Exportación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al exportar CSV: " + ex.Message, "Error Exportación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        #endregion

        #region Pestaña 3: Validación y Métricas

        private void BtnEvaluarCasos_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                var resultado = _mlService.EvaluarMetricas();

                // 1. Mostrar Matriz de Confusión
                LlenarMatrizConfusion(resultado);

                // 2. Mostrar detalle de casos
                _dgvMetricas.DataSource = null;
                _dgvMetricas.DataSource = resultado.Detalles;

                if (_dgvMetricas.Columns.Count > 0)
                {
                    _dgvMetricas.Columns[nameof(DetalleEvaluacion.Descripcion)].HeaderText = "Descripción del Gasto de Prueba";
                    _dgvMetricas.Columns[nameof(DetalleEvaluacion.Descripcion)].FillWeight = 240;

                    _dgvMetricas.Columns[nameof(DetalleEvaluacion.CategoriaReal)].HeaderText = "Categoría Real (Etiqueta)";
                    _dgvMetricas.Columns[nameof(DetalleEvaluacion.CategoriaReal)].Width = 170;

                    _dgvMetricas.Columns[nameof(DetalleEvaluacion.CategoriaPredicha)].HeaderText = "Predicción del Modelo (IA)";
                    _dgvMetricas.Columns[nameof(DetalleEvaluacion.CategoriaPredicha)].Width = 170;

                    _dgvMetricas.Columns[nameof(DetalleEvaluacion.ConfianzaTexto)].HeaderText = "Certeza IA";
                    _dgvMetricas.Columns[nameof(DetalleEvaluacion.ConfianzaTexto)].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    _dgvMetricas.Columns[nameof(DetalleEvaluacion.ConfianzaTexto)].Width = 100;

                    _dgvMetricas.Columns[nameof(DetalleEvaluacion.Acierto)].HeaderText = "¿Acierto?";
                    _dgvMetricas.Columns[nameof(DetalleEvaluacion.Acierto)].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    _dgvMetricas.Columns[nameof(DetalleEvaluacion.Acierto)].Width = 90;

                    // Ocultar campo raw de confianza si existe
                    if (_dgvMetricas.Columns.Contains(nameof(DetalleEvaluacion.Confianza)))
                    {
                        _dgvMetricas.Columns[nameof(DetalleEvaluacion.Confianza)].Visible = false;
                    }
                }

                _lblResultadoExactitud.Text = string.Format(
                    "Exactitud Global: {0:F1}%  |  Aciertos: {1}/{2}  |  Macro-Accuracy: {3:F1}%",
                    resultado.PorcentajeExactitud,
                    resultado.Aciertos,
                    resultado.TotalCasos,
                    resultado.MacroAccuracy * 100.0);

                _lblResultadoExactitud.ForeColor = resultado.PorcentajeExactitud >= 80.0
                    ? Color.FromArgb(20, 90, 50)
                    : Color.FromArgb(176, 58, 46);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error durante la evaluación de métricas: " + ex.Message,
                    "Error de Evaluación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void LlenarMatrizConfusion(ResultadoEvaluacion resultado)
        {
            var dt = new DataTable();
            dt.Columns.Add("Categoría Real \\ Predicha", typeof(string));

            foreach (var cat in resultado.Categorias)
            {
                dt.Columns.Add(cat, typeof(int));
            }

            for (int i = 0; i < resultado.Categorias.Count; i++)
            {
                var row = dt.NewRow();
                row[0] = resultado.Categorias[i];
                for (int j = 0; j < resultado.Categorias.Count; j++)
                {
                    row[j + 1] = resultado.MatrizConfusion[i, j];
                }
                dt.Rows.Add(row);
            }

            _dgvMatrizConfusion.DataSource = dt;
            _dgvMatrizConfusion.Columns[0].FillWeight = 160;
            _dgvMatrizConfusion.Columns[0].DefaultCellStyle.Font = new Font(_dgvMatrizConfusion.Font, FontStyle.Bold);

            for (int j = 1; j < dt.Columns.Count; j++)
            {
                _dgvMatrizConfusion.Columns[j].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void DgvMatrizConfusion_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex > 0 && e.Value != null)
            {
                int colRealIdx = e.RowIndex + 1; // Columna correspondiente a la diagonal
                int val = Convert.ToInt32(e.Value);

                if (e.ColumnIndex == colRealIdx)
                {
                    // Diagonal (Aciertos)
                    e.CellStyle.BackColor = Color.FromArgb(212, 239, 223);
                    e.CellStyle.ForeColor = Color.FromArgb(20, 90, 50);
                    e.CellStyle.Font = new Font(_dgvMatrizConfusion.Font, FontStyle.Bold);
                }
                else if (val > 0)
                {
                    // Errores de clasificación
                    e.CellStyle.BackColor = Color.FromArgb(250, 219, 216);
                    e.CellStyle.ForeColor = Color.FromArgb(146, 43, 33);
                    e.CellStyle.Font = new Font(_dgvMatrizConfusion.Font, FontStyle.Bold);
                }
            }
        }

        private void DgvMetricas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (_dgvMetricas.Columns[e.ColumnIndex].Name == nameof(DetalleEvaluacion.Acierto) && e.Value != null)
            {
                string valor = e.Value.ToString();
                if (valor == "Sí")
                {
                    e.CellStyle.BackColor = Color.FromArgb(212, 239, 223);
                    e.CellStyle.ForeColor = Color.FromArgb(20, 90, 50);
                    e.CellStyle.Font = new Font(_dgvMetricas.Font, FontStyle.Bold);
                }
                else if (valor == "No")
                {
                    e.CellStyle.BackColor = Color.FromArgb(249, 219, 216);
                    e.CellStyle.ForeColor = Color.FromArgb(146, 43, 33);
                    e.CellStyle.Font = new Font(_dgvMetricas.Font, FontStyle.Bold);
                }
            }
        }

        #endregion

        #region Pestaña 4: Entrenamiento y Aprendizaje Continuo

        private void CargarDatosEntrenamiento()
        {
            try
            {
                var baseDatos = _mlService.SembrarDatosEntrenamiento();
                var confirmados = _databaseService.ObtenerGastosConfirmadosParaEntrenamiento();
                var personalizados = _databaseService.ObtenerEjemplosPersonalizados();

                var listaVista = new List<EjemploEntrenamientoVista>();

                // Agregar ejemplos base
                foreach (var b in baseDatos)
                {
                    listaVista.Add(new EjemploEntrenamientoVista
                    {
                        Origen = "📌 Base",
                        Descripcion = b.Descripcion,
                        Categoria = b.Categoria
                    });
                }

                // Agregar ejemplos personalizados y confirmados
                foreach (var p in personalizados)
                {
                    listaVista.Add(new EjemploEntrenamientoVista
                    {
                        Origen = "👤 Personalizado",
                        Descripcion = p.Descripcion,
                        Categoria = p.Categoria
                    });
                }

                foreach (var c in confirmados)
                {
                    if (!baseDatos.Any(b => string.Equals(b.Descripcion, c.Descripcion, StringComparison.OrdinalIgnoreCase)))
                    {
                        listaVista.Add(new EjemploEntrenamientoVista
                        {
                            Origen = "🔄 Confirmado (Usuario)",
                            Descripcion = c.Descripcion,
                            Categoria = c.Categoria
                        });
                    }
                }

                _dgvEntrenamiento.DataSource = null;
                _dgvEntrenamiento.DataSource = listaVista;

                if (_dgvEntrenamiento.Columns.Count > 0)
                {
                    _dgvEntrenamiento.Columns[nameof(EjemploEntrenamientoVista.Origen)].HeaderText = "Origen";
                    _dgvEntrenamiento.Columns[nameof(EjemploEntrenamientoVista.Origen)].Width = 160;

                    _dgvEntrenamiento.Columns[nameof(EjemploEntrenamientoVista.Descripcion)].HeaderText = "Descripción del Gasto";
                    _dgvEntrenamiento.Columns[nameof(EjemploEntrenamientoVista.Descripcion)].FillWeight = 260;

                    _dgvEntrenamiento.Columns[nameof(EjemploEntrenamientoVista.Categoria)].HeaderText = "Categoría Asignada";
                    _dgvEntrenamiento.Columns[nameof(EjemploEntrenamientoVista.Categoria)].Width = 180;
                }

                string fechaStr = _mlService.UltimaFechaEntrenamiento.HasValue
                    ? _mlService.UltimaFechaEntrenamiento.Value.ToString("HH:mm:ss")
                    : "Inicial";

                _lblEstadoEntrenamiento.Text = $"Estado: Modelo entrenado con {listaVista.Count} ejemplos activos ({baseDatos.Count} base + {listaVista.Count - baseDatos.Count} del usuario) a las {fechaStr}.";
                _lblEstadoEntrenamiento.ForeColor = Color.FromArgb(39, 174, 96);
            }
            catch (Exception ex)
            {
                _lblEstadoEntrenamiento.Text = "Error al cargar dataset: " + ex.Message;
                _lblEstadoEntrenamiento.ForeColor = Color.Red;
            }
        }

        private void DgvEntrenamiento_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (_dgvEntrenamiento.Columns[e.ColumnIndex].Name == nameof(EjemploEntrenamientoVista.Origen) && e.Value != null)
            {
                string valor = e.Value.ToString();
                if (valor.Contains("Usuario") || valor.Contains("Personalizado"))
                {
                    e.CellStyle.BackColor = Color.FromArgb(235, 245, 251);
                    e.CellStyle.ForeColor = Color.FromArgb(41, 128, 185);
                    e.CellStyle.Font = new Font(_dgvEntrenamiento.Font, FontStyle.Bold);
                }
            }
        }

        private void BtnReentrenarContinuo_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                var confirmados = _databaseService.ObtenerGastosConfirmadosParaEntrenamiento();
                var personalizados = _databaseService.ObtenerEjemplosPersonalizados();
                var todosAdicionales = confirmados.Concat(personalizados).ToList();

                int total = _mlService.EntrenarConDatosBaseYConfirmados(todosAdicionales);
                CargarDatosEntrenamiento();

                MessageBox.Show($"¡Aprendizaje continuo completado exitosamente!\n\nEl modelo ha incorporado {todosAdicionales.Count} gastos y ejemplos confirmados por ti, alcanzando un total de {total} ejemplos de entrenamiento en disco.",
                    "Reentrenamiento Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error durante el reentrenamiento: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void BtnRestablecerBase_Click(object sender, EventArgs e)
        {
            var conf = MessageBox.Show("¿Deseas restablecer el modelo a los 49 ejemplos base originales?",
                "Confirmar Restablecimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (conf == DialogResult.Yes)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    _mlService.EntrenarModelo(_mlService.SembrarDatosEntrenamiento(), guardarEnDisco: true);
                    CargarDatosEntrenamiento();
                    MessageBox.Show("El modelo ha sido restablecido a su configuración base.",
                        "Restablecimiento Completo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al restablecer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }

        private void BtnAgregarEjemplo_Click(object sender, EventArgs e)
        {
            string frase = _txtNuevaFrase.Text.Trim();
            string cat = _cmbNuevaCategoria.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(frase))
            {
                MessageBox.Show("Ingresa la frase o descripción del gasto para enseñar.",
                    "Dato requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _txtNuevaFrase.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(cat))
            {
                MessageBox.Show("Selecciona una categoría válida.", "Dato requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                _databaseService.GuardarEjemploPersonalizado(frase, cat);

                // Reentrenar con los nuevos datos
                var confirmados = _databaseService.ObtenerGastosConfirmadosParaEntrenamiento();
                var personalizados = _databaseService.ObtenerEjemplosPersonalizados();
                var adicionales = confirmados.Concat(personalizados).ToList();

                _mlService.EntrenarConDatosBaseYConfirmados(adicionales);

                _txtNuevaFrase.Clear();
                CargarDatosEntrenamiento();

                MessageBox.Show($"¡Concepto aprendido!\nFrase: '{frase}'\nCategoría: '{cat}'\n\nEl modelo ya fue reentrenado y persistido en disco.",
                    "Aprendizaje Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar ejemplo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        #endregion
    }
}
