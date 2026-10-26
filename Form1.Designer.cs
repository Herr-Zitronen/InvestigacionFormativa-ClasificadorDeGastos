namespace _2InvestigacionFormativa
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // Contenedor principal de pestañas
        private System.Windows.Forms.TabControl _tabs;

        // Pestaña 1: Dashboard Financiero
        private System.Windows.Forms.TabPage _tabDashboard;
        private System.Windows.Forms.Panel _pnlDashboardToolbar;
        private System.Windows.Forms.Label _lblFiltroPeriodo;
        private System.Windows.Forms.ComboBox _cmbFiltroPeriodo;
        private System.Windows.Forms.Button _btnActualizarDashboard;
        private System.Windows.Forms.TableLayoutPanel _pnlKpiContainer;
        private System.Windows.Forms.Panel _pnlKpi1;
        private System.Windows.Forms.Label _lblKpi1Titulo;
        private System.Windows.Forms.Label _lblKpi1Valor;
        private System.Windows.Forms.Label _lblKpi1Sub;
        private System.Windows.Forms.Panel _pnlKpi2;
        private System.Windows.Forms.Label _lblKpi2Titulo;
        private System.Windows.Forms.Label _lblKpi2Valor;
        private System.Windows.Forms.Label _lblKpi2Sub;
        private System.Windows.Forms.Panel _pnlKpi3;
        private System.Windows.Forms.Label _lblKpi3Titulo;
        private System.Windows.Forms.Label _lblKpi3Valor;
        private System.Windows.Forms.Label _lblKpi3Sub;
        private System.Windows.Forms.Panel _pnlKpi4;
        private System.Windows.Forms.Label _lblKpi4Titulo;
        private System.Windows.Forms.Label _lblKpi4Valor;
        private System.Windows.Forms.Label _lblKpi4Sub;
        private System.Windows.Forms.TableLayoutPanel _pnlGraficos;
        private System.Windows.Forms.DataVisualization.Charting.Chart _chartPie;
        private System.Windows.Forms.DataVisualization.Charting.Chart _chartBar;
        private System.Windows.Forms.DataGridView _dgvResumenCategorias;

        // Pestaña 2: Registro y Gestión de Gastos
        private System.Windows.Forms.TabPage _tabRegistro;
        private System.Windows.Forms.Panel _pnlFormulario;
        private System.Windows.Forms.Label _lblDescripcion;
        private System.Windows.Forms.TextBox _txtDescripcion;
        private System.Windows.Forms.Label _lblMonto;
        private System.Windows.Forms.NumericUpDown _numMonto;
        private System.Windows.Forms.Label _lblFecha;
        private System.Windows.Forms.DateTimePicker _dtpFecha;
        private System.Windows.Forms.Button _btnPredecirIA;
        private System.Windows.Forms.Label _lblSugerenciaIA;
        private System.Windows.Forms.Label _lblConfianzaBadge;
        private System.Windows.Forms.Label _lblCategoria;
        private System.Windows.Forms.ComboBox _cmbCategoria;
        private System.Windows.Forms.Button _btnGuardar;
        private System.Windows.Forms.Button _btnActualizar;
        private System.Windows.Forms.Button _btnCancelarEdicion;
        private System.Windows.Forms.Panel _pnlHistorialToolbar;
        private System.Windows.Forms.Label _lblBuscar;
        private System.Windows.Forms.TextBox _txtBuscar;
        private System.Windows.Forms.Label _lblFiltroCat;
        private System.Windows.Forms.ComboBox _cmbFiltroHistorial;
        private System.Windows.Forms.Button _btnBorrarTransaccion;
        private System.Windows.Forms.Button _btnExportarCsv;
        private System.Windows.Forms.DataGridView _dgvTransacciones;
        private System.Windows.Forms.Label _lblEstadisticas;

        // Pestaña 3: Validación y Métricas
        private System.Windows.Forms.TabPage _tabMetricas;
        private System.Windows.Forms.Panel _pnlMetricasTop;
        private System.Windows.Forms.Button _btnEvaluarCasos;
        private System.Windows.Forms.Label _lblResultadoExactitud;
        private System.Windows.Forms.Label _lblMetricasSub;
        private System.Windows.Forms.Label _lblTituloConfusion;
        private System.Windows.Forms.DataGridView _dgvMatrizConfusion;
        private System.Windows.Forms.Label _lblTituloCasos;
        private System.Windows.Forms.DataGridView _dgvMetricas;

        // Pestaña 4: Entrenamiento y Aprendizaje Continuo
        private System.Windows.Forms.TabPage _tabEntrenamiento;
        private System.Windows.Forms.Panel _pnlEntrenamientoTop;
        private System.Windows.Forms.Button _btnReentrenarContinuo;
        private System.Windows.Forms.Button _btnRestablecerBase;
        private System.Windows.Forms.Label _lblEstadoEntrenamiento;
        private System.Windows.Forms.GroupBox _grpNuevoEjemplo;
        private System.Windows.Forms.Label _lblNuevaFrase;
        private System.Windows.Forms.TextBox _txtNuevaFrase;
        private System.Windows.Forms.Label _lblNuevaCategoria;
        private System.Windows.Forms.ComboBox _cmbNuevaCategoria;
        private System.Windows.Forms.Button _btnAgregarEjemplo;
        private System.Windows.Forms.Label _lblTituloDataset;
        private System.Windows.Forms.DataGridView _dgvEntrenamiento;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dgvHeader = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartAreaPie = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legendPie = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series seriesPie = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartAreaBar = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legendBar = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series seriesBar = new System.Windows.Forms.DataVisualization.Charting.Series();

            this._tabs = new System.Windows.Forms.TabControl();

            // Pestaña 1
            this._tabDashboard = new System.Windows.Forms.TabPage();
            this._pnlDashboardToolbar = new System.Windows.Forms.Panel();
            this._lblFiltroPeriodo = new System.Windows.Forms.Label();
            this._cmbFiltroPeriodo = new System.Windows.Forms.ComboBox();
            this._btnActualizarDashboard = new System.Windows.Forms.Button();
            this._pnlKpiContainer = new System.Windows.Forms.TableLayoutPanel();
            this._pnlKpi1 = new System.Windows.Forms.Panel();
            this._lblKpi1Titulo = new System.Windows.Forms.Label();
            this._lblKpi1Valor = new System.Windows.Forms.Label();
            this._lblKpi1Sub = new System.Windows.Forms.Label();
            this._pnlKpi2 = new System.Windows.Forms.Panel();
            this._lblKpi2Titulo = new System.Windows.Forms.Label();
            this._lblKpi2Valor = new System.Windows.Forms.Label();
            this._lblKpi2Sub = new System.Windows.Forms.Label();
            this._pnlKpi3 = new System.Windows.Forms.Panel();
            this._lblKpi3Titulo = new System.Windows.Forms.Label();
            this._lblKpi3Valor = new System.Windows.Forms.Label();
            this._lblKpi3Sub = new System.Windows.Forms.Label();
            this._pnlKpi4 = new System.Windows.Forms.Panel();
            this._lblKpi4Titulo = new System.Windows.Forms.Label();
            this._lblKpi4Valor = new System.Windows.Forms.Label();
            this._lblKpi4Sub = new System.Windows.Forms.Label();
            this._pnlGraficos = new System.Windows.Forms.TableLayoutPanel();
            this._chartPie = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this._chartBar = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this._dgvResumenCategorias = new System.Windows.Forms.DataGridView();

            // Pestaña 2
            this._tabRegistro = new System.Windows.Forms.TabPage();
            this._pnlFormulario = new System.Windows.Forms.Panel();
            this._lblDescripcion = new System.Windows.Forms.Label();
            this._txtDescripcion = new System.Windows.Forms.TextBox();
            this._lblMonto = new System.Windows.Forms.Label();
            this._numMonto = new System.Windows.Forms.NumericUpDown();
            this._lblFecha = new System.Windows.Forms.Label();
            this._dtpFecha = new System.Windows.Forms.DateTimePicker();
            this._btnPredecirIA = new System.Windows.Forms.Button();
            this._lblSugerenciaIA = new System.Windows.Forms.Label();
            this._lblConfianzaBadge = new System.Windows.Forms.Label();
            this._lblCategoria = new System.Windows.Forms.Label();
            this._cmbCategoria = new System.Windows.Forms.ComboBox();
            this._btnGuardar = new System.Windows.Forms.Button();
            this._btnActualizar = new System.Windows.Forms.Button();
            this._btnCancelarEdicion = new System.Windows.Forms.Button();
            this._pnlHistorialToolbar = new System.Windows.Forms.Panel();
            this._lblBuscar = new System.Windows.Forms.Label();
            this._txtBuscar = new System.Windows.Forms.TextBox();
            this._lblFiltroCat = new System.Windows.Forms.Label();
            this._cmbFiltroHistorial = new System.Windows.Forms.ComboBox();
            this._btnBorrarTransaccion = new System.Windows.Forms.Button();
            this._btnExportarCsv = new System.Windows.Forms.Button();
            this._dgvTransacciones = new System.Windows.Forms.DataGridView();
            this._lblEstadisticas = new System.Windows.Forms.Label();

            // Pestaña 3
            this._tabMetricas = new System.Windows.Forms.TabPage();
            this._pnlMetricasTop = new System.Windows.Forms.Panel();
            this._btnEvaluarCasos = new System.Windows.Forms.Button();
            this._lblResultadoExactitud = new System.Windows.Forms.Label();
            this._lblMetricasSub = new System.Windows.Forms.Label();
            this._lblTituloConfusion = new System.Windows.Forms.Label();
            this._dgvMatrizConfusion = new System.Windows.Forms.DataGridView();
            this._lblTituloCasos = new System.Windows.Forms.Label();
            this._dgvMetricas = new System.Windows.Forms.DataGridView();

            // Pestaña 4
            this._tabEntrenamiento = new System.Windows.Forms.TabPage();
            this._pnlEntrenamientoTop = new System.Windows.Forms.Panel();
            this._btnReentrenarContinuo = new System.Windows.Forms.Button();
            this._btnRestablecerBase = new System.Windows.Forms.Button();
            this._lblEstadoEntrenamiento = new System.Windows.Forms.Label();
            this._grpNuevoEjemplo = new System.Windows.Forms.GroupBox();
            this._lblNuevaFrase = new System.Windows.Forms.Label();
            this._txtNuevaFrase = new System.Windows.Forms.TextBox();
            this._lblNuevaCategoria = new System.Windows.Forms.Label();
            this._cmbNuevaCategoria = new System.Windows.Forms.ComboBox();
            this._btnAgregarEjemplo = new System.Windows.Forms.Button();
            this._lblTituloDataset = new System.Windows.Forms.Label();
            this._dgvEntrenamiento = new System.Windows.Forms.DataGridView();

            this._tabs.SuspendLayout();
            this._tabDashboard.SuspendLayout();
            this._pnlDashboardToolbar.SuspendLayout();
            this._pnlKpiContainer.SuspendLayout();
            this._pnlKpi1.SuspendLayout();
            this._pnlKpi2.SuspendLayout();
            this._pnlKpi3.SuspendLayout();
            this._pnlKpi4.SuspendLayout();
            this._pnlGraficos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._chartPie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._chartBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvResumenCategorias)).BeginInit();

            this._tabRegistro.SuspendLayout();
            this._pnlFormulario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numMonto)).BeginInit();
            this._pnlHistorialToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvTransacciones)).BeginInit();

            this._tabMetricas.SuspendLayout();
            this._pnlMetricasTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvMatrizConfusion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvMetricas)).BeginInit();

            this._tabEntrenamiento.SuspendLayout();
            this._pnlEntrenamientoTop.SuspendLayout();
            this._grpNuevoEjemplo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvEntrenamiento)).BeginInit();
            this.SuspendLayout();

            // 
            // _tabs
            // 
            this._tabs.Controls.Add(this._tabDashboard);
            this._tabs.Controls.Add(this._tabRegistro);
            this._tabs.Controls.Add(this._tabMetricas);
            this._tabs.Controls.Add(this._tabEntrenamiento);
            this._tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tabs.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._tabs.ItemSize = new System.Drawing.Size(200, 36);
            this._tabs.Location = new System.Drawing.Point(0, 0);
            this._tabs.Name = "_tabs";
            this._tabs.SelectedIndex = 0;
            this._tabs.Size = new System.Drawing.Size(1184, 750);
            this._tabs.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this._tabs.TabIndex = 0;

            // ==========================================
            // PESTAÑA 1: DASHBOARD FINANCIERO
            // ==========================================
            this._tabDashboard.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this._tabDashboard.Controls.Add(this._dgvResumenCategorias);
            this._tabDashboard.Controls.Add(this._pnlGraficos);
            this._tabDashboard.Controls.Add(this._pnlKpiContainer);
            this._tabDashboard.Controls.Add(this._pnlDashboardToolbar);
            this._tabDashboard.Location = new System.Drawing.Point(4, 40);
            this._tabDashboard.Name = "_tabDashboard";
            this._tabDashboard.Padding = new System.Windows.Forms.Padding(12);
            this._tabDashboard.Size = new System.Drawing.Size(1176, 706);
            this._tabDashboard.TabIndex = 0;
            this._tabDashboard.Text = "📊 Dashboard Financiero";

            // _pnlDashboardToolbar
            this._pnlDashboardToolbar.Controls.Add(this._lblFiltroPeriodo);
            this._pnlDashboardToolbar.Controls.Add(this._cmbFiltroPeriodo);
            this._pnlDashboardToolbar.Controls.Add(this._btnActualizarDashboard);
            this._pnlDashboardToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this._pnlDashboardToolbar.Location = new System.Drawing.Point(12, 12);
            this._pnlDashboardToolbar.Name = "_pnlDashboardToolbar";
            this._pnlDashboardToolbar.Size = new System.Drawing.Size(1152, 42);
            this._pnlDashboardToolbar.TabIndex = 0;

            this._lblFiltroPeriodo.AutoSize = true;
            this._lblFiltroPeriodo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._lblFiltroPeriodo.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this._lblFiltroPeriodo.Location = new System.Drawing.Point(4, 9);
            this._lblFiltroPeriodo.Name = "_lblFiltroPeriodo";
            this._lblFiltroPeriodo.Size = new System.Drawing.Size(130, 21);
            this._lblFiltroPeriodo.Text = "Período Análisis:";

            this._cmbFiltroPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbFiltroPeriodo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._cmbFiltroPeriodo.Items.AddRange(new object[] {
            "Todo el historial",
            "Este mes",
            "Últimos 30 días",
            "Este año"});
            this._cmbFiltroPeriodo.Location = new System.Drawing.Point(140, 5);
            this._cmbFiltroPeriodo.Name = "_cmbFiltroPeriodo";
            this._cmbFiltroPeriodo.Size = new System.Drawing.Size(200, 29);
            this._cmbFiltroPeriodo.TabIndex = 1;
            this._cmbFiltroPeriodo.SelectedIndexChanged += new System.EventHandler(this.CmbFiltroPeriodo_SelectedIndexChanged);

            this._btnActualizarDashboard.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this._btnActualizarDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnActualizarDashboard.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._btnActualizarDashboard.ForeColor = System.Drawing.Color.White;
            this._btnActualizarDashboard.Location = new System.Drawing.Point(350, 4);
            this._btnActualizarDashboard.Name = "_btnActualizarDashboard";
            this._btnActualizarDashboard.Size = new System.Drawing.Size(130, 31);
            this._btnActualizarDashboard.TabIndex = 2;
            this._btnActualizarDashboard.Text = "🔄 Actualizar";
            this._btnActualizarDashboard.UseVisualStyleBackColor = false;
            this._btnActualizarDashboard.Click += new System.EventHandler(this.BtnActualizarDashboard_Click);

            // _pnlKpiContainer
            this._pnlKpiContainer.ColumnCount = 4;
            this._pnlKpiContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._pnlKpiContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._pnlKpiContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._pnlKpiContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._pnlKpiContainer.Controls.Add(this._pnlKpi1, 0, 0);
            this._pnlKpiContainer.Controls.Add(this._pnlKpi2, 1, 0);
            this._pnlKpiContainer.Controls.Add(this._pnlKpi3, 2, 0);
            this._pnlKpiContainer.Controls.Add(this._pnlKpi4, 3, 0);
            this._pnlKpiContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this._pnlKpiContainer.Location = new System.Drawing.Point(12, 54);
            this._pnlKpiContainer.Name = "_pnlKpiContainer";
            this._pnlKpiContainer.RowCount = 1;
            this._pnlKpiContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._pnlKpiContainer.Size = new System.Drawing.Size(1152, 90);
            this._pnlKpiContainer.TabIndex = 1;

            // KPI 1
            this._pnlKpi1.BackColor = System.Drawing.Color.White;
            this._pnlKpi1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._pnlKpi1.Controls.Add(this._lblKpi1Titulo);
            this._pnlKpi1.Controls.Add(this._lblKpi1Valor);
            this._pnlKpi1.Controls.Add(this._lblKpi1Sub);
            this._pnlKpi1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlKpi1.Margin = new System.Windows.Forms.Padding(4);
            this._pnlKpi1.Name = "_pnlKpi1";
            this._pnlKpi1.Padding = new System.Windows.Forms.Padding(8);

            this._lblKpi1Titulo.AutoSize = true;
            this._lblKpi1Titulo.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this._lblKpi1Titulo.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this._lblKpi1Titulo.Location = new System.Drawing.Point(8, 6);
            this._lblKpi1Titulo.Text = "GASTO TOTAL";

            this._lblKpi1Valor.AutoSize = true;
            this._lblKpi1Valor.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this._lblKpi1Valor.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this._lblKpi1Valor.Location = new System.Drawing.Point(6, 26);
            this._lblKpi1Valor.Text = "$0.00";

            this._lblKpi1Sub.AutoSize = true;
            this._lblKpi1Sub.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this._lblKpi1Sub.ForeColor = System.Drawing.Color.Gray;
            this._lblKpi1Sub.Location = new System.Drawing.Point(8, 62);
            this._lblKpi1Sub.Text = "Acumulado en período";

            // KPI 2
            this._pnlKpi2.BackColor = System.Drawing.Color.White;
            this._pnlKpi2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._pnlKpi2.Controls.Add(this._lblKpi2Titulo);
            this._pnlKpi2.Controls.Add(this._lblKpi2Valor);
            this._pnlKpi2.Controls.Add(this._lblKpi2Sub);
            this._pnlKpi2.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlKpi2.Margin = new System.Windows.Forms.Padding(4);
            this._pnlKpi2.Name = "_pnlKpi2";
            this._pnlKpi2.Padding = new System.Windows.Forms.Padding(8);

            this._lblKpi2Titulo.AutoSize = true;
            this._lblKpi2Titulo.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this._lblKpi2Titulo.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this._lblKpi2Titulo.Location = new System.Drawing.Point(8, 6);
            this._lblKpi2Titulo.Text = "TRANSACCIONES";

            this._lblKpi2Valor.AutoSize = true;
            this._lblKpi2Valor.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this._lblKpi2Valor.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this._lblKpi2Valor.Location = new System.Drawing.Point(6, 26);
            this._lblKpi2Valor.Text = "0";

            this._lblKpi2Sub.AutoSize = true;
            this._lblKpi2Sub.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this._lblKpi2Sub.ForeColor = System.Drawing.Color.Gray;
            this._lblKpi2Sub.Location = new System.Drawing.Point(8, 62);
            this._lblKpi2Sub.Text = "Registros confirmados";

            // KPI 3
            this._pnlKpi3.BackColor = System.Drawing.Color.White;
            this._pnlKpi3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._pnlKpi3.Controls.Add(this._lblKpi3Titulo);
            this._pnlKpi3.Controls.Add(this._lblKpi3Valor);
            this._pnlKpi3.Controls.Add(this._lblKpi3Sub);
            this._pnlKpi3.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlKpi3.Margin = new System.Windows.Forms.Padding(4);
            this._pnlKpi3.Name = "_pnlKpi3";
            this._pnlKpi3.Padding = new System.Windows.Forms.Padding(8);

            this._lblKpi3Titulo.AutoSize = true;
            this._lblKpi3Titulo.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this._lblKpi3Titulo.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this._lblKpi3Titulo.Location = new System.Drawing.Point(8, 6);
            this._lblKpi3Titulo.Text = "MAYOR CONSUMO";

            this._lblKpi3Valor.AutoSize = true;
            this._lblKpi3Valor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this._lblKpi3Valor.ForeColor = System.Drawing.Color.FromArgb(230, 126, 34);
            this._lblKpi3Valor.Location = new System.Drawing.Point(6, 28);
            this._lblKpi3Valor.Text = "Sin datos";

            this._lblKpi3Sub.AutoSize = true;
            this._lblKpi3Sub.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this._lblKpi3Sub.ForeColor = System.Drawing.Color.Gray;
            this._lblKpi3Sub.Location = new System.Drawing.Point(8, 62);
            this._lblKpi3Sub.Text = "$0.00 (0%)";

            // KPI 4
            this._pnlKpi4.BackColor = System.Drawing.Color.White;
            this._pnlKpi4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._pnlKpi4.Controls.Add(this._lblKpi4Titulo);
            this._pnlKpi4.Controls.Add(this._lblKpi4Valor);
            this._pnlKpi4.Controls.Add(this._lblKpi4Sub);
            this._pnlKpi4.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlKpi4.Margin = new System.Windows.Forms.Padding(4);
            this._pnlKpi4.Name = "_pnlKpi4";
            this._pnlKpi4.Padding = new System.Windows.Forms.Padding(8);

            this._lblKpi4Titulo.AutoSize = true;
            this._lblKpi4Titulo.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this._lblKpi4Titulo.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this._lblKpi4Titulo.Location = new System.Drawing.Point(8, 6);
            this._lblKpi4Titulo.Text = "PRECISIÓN IA";

            this._lblKpi4Valor.AutoSize = true;
            this._lblKpi4Valor.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this._lblKpi4Valor.ForeColor = System.Drawing.Color.FromArgb(142, 68, 173);
            this._lblKpi4Valor.Location = new System.Drawing.Point(6, 26);
            this._lblKpi4Valor.Text = "100%";

            this._lblKpi4Sub.AutoSize = true;
            this._lblKpi4Sub.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this._lblKpi4Sub.ForeColor = System.Drawing.Color.Gray;
            this._lblKpi4Sub.Location = new System.Drawing.Point(8, 62);
            this._lblKpi4Sub.Text = "Modelo calibrado";

            // _pnlGraficos
            this._pnlGraficos.ColumnCount = 2;
            this._pnlGraficos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._pnlGraficos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._pnlGraficos.Controls.Add(this._chartPie, 0, 0);
            this._pnlGraficos.Controls.Add(this._chartBar, 1, 0);
            this._pnlGraficos.Dock = System.Windows.Forms.DockStyle.Top;
            this._pnlGraficos.Location = new System.Drawing.Point(12, 144);
            this._pnlGraficos.Name = "_pnlGraficos";
            this._pnlGraficos.RowCount = 1;
            this._pnlGraficos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._pnlGraficos.Size = new System.Drawing.Size(1152, 320);
            this._pnlGraficos.TabIndex = 2;

            // Chart Pie
            chartAreaPie.Name = "ChartAreaPie";
            this._chartPie.ChartAreas.Add(chartAreaPie);
            this._chartPie.Dock = System.Windows.Forms.DockStyle.Fill;
            legendPie.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legendPie.Font = new System.Drawing.Font("Segoe UI", 8F);
            legendPie.Name = "LegendPie";
            this._chartPie.Legends.Add(legendPie);
            this._chartPie.Location = new System.Drawing.Point(3, 3);
            this._chartPie.Name = "_chartPie";
            seriesPie.ChartArea = "ChartAreaPie";
            seriesPie.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            seriesPie.Font = new System.Drawing.Font("Segoe UI", 8F);
            seriesPie.Legend = "LegendPie";
            seriesPie.Name = "Categorias";
            this._chartPie.Series.Add(seriesPie);
            this._chartPie.Size = new System.Drawing.Size(570, 314);
            this._chartPie.TabIndex = 0;

            // Chart Bar
            chartAreaBar.Name = "ChartAreaBar";
            this._chartBar.ChartAreas.Add(chartAreaBar);
            this._chartBar.Dock = System.Windows.Forms.DockStyle.Fill;
            legendBar.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legendBar.Font = new System.Drawing.Font("Segoe UI", 8F);
            legendBar.Name = "LegendBar";
            this._chartBar.Legends.Add(legendBar);
            this._chartBar.Location = new System.Drawing.Point(579, 3);
            this._chartBar.Name = "_chartBar";
            seriesBar.ChartArea = "ChartAreaBar";
            seriesBar.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            seriesBar.Font = new System.Drawing.Font("Segoe UI", 8F);
            seriesBar.Legend = "LegendBar";
            seriesBar.Name = "MontoTotal";
            seriesBar.Color = System.Drawing.Color.FromArgb(41, 128, 185);
            this._chartBar.Series.Add(seriesBar);
            this._chartBar.Size = new System.Drawing.Size(570, 314);
            this._chartBar.TabIndex = 1;

            // _dgvResumenCategorias
            this._dgvResumenCategorias.AllowUserToAddRows = false;
            this._dgvResumenCategorias.AllowUserToDeleteRows = false;
            this._dgvResumenCategorias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dgvResumenCategorias.BackgroundColor = System.Drawing.Color.White;
            this._dgvResumenCategorias.ColumnHeadersHeight = 32;
            this._dgvResumenCategorias.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgvResumenCategorias.Location = new System.Drawing.Point(12, 464);
            this._dgvResumenCategorias.MultiSelect = false;
            this._dgvResumenCategorias.Name = "_dgvResumenCategorias";
            this._dgvResumenCategorias.ReadOnly = true;
            this._dgvResumenCategorias.RowHeadersVisible = false;
            this._dgvResumenCategorias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvResumenCategorias.Size = new System.Drawing.Size(1152, 230);
            this._dgvResumenCategorias.TabIndex = 3;

            // ==========================================
            // PESTAÑA 2: REGISTRO Y GESTIÓN
            // ==========================================
            this._tabRegistro.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this._tabRegistro.Controls.Add(this._dgvTransacciones);
            this._tabRegistro.Controls.Add(this._lblEstadisticas);
            this._tabRegistro.Controls.Add(this._pnlHistorialToolbar);
            this._tabRegistro.Controls.Add(this._pnlFormulario);
            this._tabRegistro.Location = new System.Drawing.Point(4, 40);
            this._tabRegistro.Name = "_tabRegistro";
            this._tabRegistro.Padding = new System.Windows.Forms.Padding(12);
            this._tabRegistro.Size = new System.Drawing.Size(1176, 706);
            this._tabRegistro.TabIndex = 1;
            this._tabRegistro.Text = "💳 Registro y Gestión";

            // _pnlFormulario
            this._pnlFormulario.BackColor = System.Drawing.Color.White;
            this._pnlFormulario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._pnlFormulario.Controls.Add(this._lblDescripcion);
            this._pnlFormulario.Controls.Add(this._txtDescripcion);
            this._pnlFormulario.Controls.Add(this._lblMonto);
            this._pnlFormulario.Controls.Add(this._numMonto);
            this._pnlFormulario.Controls.Add(this._lblFecha);
            this._pnlFormulario.Controls.Add(this._dtpFecha);
            this._pnlFormulario.Controls.Add(this._btnPredecirIA);
            this._pnlFormulario.Controls.Add(this._lblSugerenciaIA);
            this._pnlFormulario.Controls.Add(this._lblConfianzaBadge);
            this._pnlFormulario.Controls.Add(this._lblCategoria);
            this._pnlFormulario.Controls.Add(this._cmbCategoria);
            this._pnlFormulario.Controls.Add(this._btnGuardar);
            this._pnlFormulario.Controls.Add(this._btnActualizar);
            this._pnlFormulario.Controls.Add(this._btnCancelarEdicion);
            this._pnlFormulario.Dock = System.Windows.Forms.DockStyle.Top;
            this._pnlFormulario.Location = new System.Drawing.Point(12, 12);
            this._pnlFormulario.Name = "_pnlFormulario";
            this._pnlFormulario.Padding = new System.Windows.Forms.Padding(10);
            this._pnlFormulario.Size = new System.Drawing.Size(1152, 125);
            this._pnlFormulario.TabIndex = 0;

            // Fila 1 Formulario
            this._lblDescripcion.AutoSize = true;
            this._lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblDescripcion.Location = new System.Drawing.Point(10, 8);
            this._lblDescripcion.Name = "_lblDescripcion";
            this._lblDescripcion.Size = new System.Drawing.Size(94, 20);
            this._lblDescripcion.Text = "Descripción:";

            this._txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._txtDescripcion.Location = new System.Drawing.Point(10, 29);
            this._txtDescripcion.Name = "_txtDescripcion";
            this._txtDescripcion.Size = new System.Drawing.Size(430, 29);
            this._txtDescripcion.TabIndex = 0;
            this._txtDescripcion.TextChanged += new System.EventHandler(this.TxtDescripcion_TextChanged);

            this._lblMonto.AutoSize = true;
            this._lblMonto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblMonto.Location = new System.Drawing.Point(455, 8);
            this._lblMonto.Name = "_lblMonto";
            this._lblMonto.Size = new System.Drawing.Size(60, 20);
            this._lblMonto.Text = "Monto:";

            this._numMonto.DecimalPlaces = 2;
            this._numMonto.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._numMonto.Location = new System.Drawing.Point(455, 29);
            this._numMonto.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            this._numMonto.Name = "_numMonto";
            this._numMonto.Size = new System.Drawing.Size(130, 29);
            this._numMonto.TabIndex = 1;
            this._numMonto.ThousandsSeparator = true;

            this._lblFecha.AutoSize = true;
            this._lblFecha.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblFecha.Location = new System.Drawing.Point(600, 8);
            this._lblFecha.Name = "_lblFecha";
            this._lblFecha.Size = new System.Drawing.Size(53, 20);
            this._lblFecha.Text = "Fecha:";

            this._dtpFecha.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._dtpFecha.Location = new System.Drawing.Point(600, 29);
            this._dtpFecha.Name = "_dtpFecha";
            this._dtpFecha.Size = new System.Drawing.Size(140, 29);
            this._dtpFecha.TabIndex = 2;

            // Fila 2 Formulario (IA y Categoría)
            this._btnPredecirIA.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this._btnPredecirIA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnPredecirIA.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this._btnPredecirIA.ForeColor = System.Drawing.Color.White;
            this._btnPredecirIA.Location = new System.Drawing.Point(10, 72);
            this._btnPredecirIA.Name = "_btnPredecirIA";
            this._btnPredecirIA.Size = new System.Drawing.Size(140, 34);
            this._btnPredecirIA.TabIndex = 3;
            this._btnPredecirIA.Text = "🤖 Predecir IA";
            this._btnPredecirIA.UseVisualStyleBackColor = false;
            this._btnPredecirIA.Click += new System.EventHandler(this.BtnPredecirIA_Click);

            this._lblSugerenciaIA.AutoSize = true;
            this._lblSugerenciaIA.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblSugerenciaIA.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this._lblSugerenciaIA.Location = new System.Drawing.Point(155, 79);
            this._lblSugerenciaIA.Name = "_lblSugerenciaIA";
            this._lblSugerenciaIA.Size = new System.Drawing.Size(121, 20);
            this._lblSugerenciaIA.Text = "Sugerencia: (Sin predicción)";

            this._lblConfianzaBadge.AutoSize = true;
            this._lblConfianzaBadge.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this._lblConfianzaBadge.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this._lblConfianzaBadge.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this._lblConfianzaBadge.Location = new System.Drawing.Point(365, 79);
            this._lblConfianzaBadge.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this._lblConfianzaBadge.Text = "Certeza: -";

            this._lblCategoria.AutoSize = true;
            this._lblCategoria.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblCategoria.Location = new System.Drawing.Point(455, 79);
            this._lblCategoria.Name = "_lblCategoria";
            this._lblCategoria.Size = new System.Drawing.Size(166, 20);
            this._lblCategoria.Text = "Categoría Confirmada:";

            this._cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbCategoria.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._cmbCategoria.FormattingEnabled = true;
            this._cmbCategoria.Items.AddRange(new object[] {
            "Alimentación",
            "Transporte",
            "Servicios",
            "Entretenimiento",
            "Salud y Educación"});
            this._cmbCategoria.Location = new System.Drawing.Point(625, 75);
            this._cmbCategoria.Name = "_cmbCategoria";
            this._cmbCategoria.Size = new System.Drawing.Size(190, 29);
            this._cmbCategoria.TabIndex = 4;

            this._btnGuardar.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this._btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._btnGuardar.ForeColor = System.Drawing.Color.White;
            this._btnGuardar.Location = new System.Drawing.Point(825, 71);
            this._btnGuardar.Name = "_btnGuardar";
            this._btnGuardar.Size = new System.Drawing.Size(140, 38);
            this._btnGuardar.TabIndex = 5;
            this._btnGuardar.Text = "➕ Registrar";
            this._btnGuardar.UseVisualStyleBackColor = false;
            this._btnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);

            this._btnActualizar.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this._btnActualizar.Enabled = false;
            this._btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnActualizar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._btnActualizar.ForeColor = System.Drawing.Color.White;
            this._btnActualizar.Location = new System.Drawing.Point(970, 71);
            this._btnActualizar.Name = "_btnActualizar";
            this._btnActualizar.Size = new System.Drawing.Size(130, 38);
            this._btnActualizar.TabIndex = 6;
            this._btnActualizar.Text = "✏️ Actualizar";
            this._btnActualizar.UseVisualStyleBackColor = false;
            this._btnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);

            this._btnCancelarEdicion.BackColor = System.Drawing.Color.FromArgb(149, 165, 166);
            this._btnCancelarEdicion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnCancelarEdicion.Font = new System.Drawing.Font("Segoe UI", 8F);
            this._btnCancelarEdicion.ForeColor = System.Drawing.Color.White;
            this._btnCancelarEdicion.Location = new System.Drawing.Point(1105, 71);
            this._btnCancelarEdicion.Name = "_btnCancelarEdicion";
            this._btnCancelarEdicion.Size = new System.Drawing.Size(35, 38);
            this._btnCancelarEdicion.TabIndex = 7;
            this._btnCancelarEdicion.Text = "✖";
            this._btnCancelarEdicion.UseVisualStyleBackColor = false;
            this._btnCancelarEdicion.Click += new System.EventHandler(this.BtnCancelarEdicion_Click);

            // _pnlHistorialToolbar
            this._pnlHistorialToolbar.Controls.Add(this._lblBuscar);
            this._pnlHistorialToolbar.Controls.Add(this._txtBuscar);
            this._pnlHistorialToolbar.Controls.Add(this._lblFiltroCat);
            this._pnlHistorialToolbar.Controls.Add(this._cmbFiltroHistorial);
            this._pnlHistorialToolbar.Controls.Add(this._btnBorrarTransaccion);
            this._pnlHistorialToolbar.Controls.Add(this._btnExportarCsv);
            this._pnlHistorialToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this._pnlHistorialToolbar.Location = new System.Drawing.Point(12, 137);
            this._pnlHistorialToolbar.Name = "_pnlHistorialToolbar";
            this._pnlHistorialToolbar.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this._pnlHistorialToolbar.Size = new System.Drawing.Size(1152, 45);
            this._pnlHistorialToolbar.TabIndex = 1;

            this._lblBuscar.AutoSize = true;
            this._lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblBuscar.Location = new System.Drawing.Point(4, 12);
            this._lblBuscar.Name = "_lblBuscar";
            this._lblBuscar.Size = new System.Drawing.Size(60, 20);
            this._lblBuscar.Text = "Buscar:";

            this._txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._txtBuscar.Location = new System.Drawing.Point(68, 8);
            this._txtBuscar.Name = "_txtBuscar";
            this._txtBuscar.Size = new System.Drawing.Size(260, 29);
            this._txtBuscar.TabIndex = 0;
            this._txtBuscar.TextChanged += new System.EventHandler(this.TxtBuscar_TextChanged);

            this._lblFiltroCat.AutoSize = true;
            this._lblFiltroCat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblFiltroCat.Location = new System.Drawing.Point(340, 12);
            this._lblFiltroCat.Name = "_lblFiltroCat";
            this._lblFiltroCat.Size = new System.Drawing.Size(80, 20);
            this._lblFiltroCat.Text = "Categoría:";

            this._cmbFiltroHistorial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbFiltroHistorial.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._cmbFiltroHistorial.Items.AddRange(new object[] {
            "Todas",
            "Alimentación",
            "Transporte",
            "Servicios",
            "Entretenimiento",
            "Salud y Educación"});
            this._cmbFiltroHistorial.Location = new System.Drawing.Point(425, 8);
            this._cmbFiltroHistorial.Name = "_cmbFiltroHistorial";
            this._cmbFiltroHistorial.Size = new System.Drawing.Size(180, 29);
            this._cmbFiltroHistorial.TabIndex = 1;
            this._cmbFiltroHistorial.SelectedIndexChanged += new System.EventHandler(this.CmbFiltroHistorial_SelectedIndexChanged);

            this._btnExportarCsv.BackColor = System.Drawing.Color.FromArgb(22, 160, 133);
            this._btnExportarCsv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnExportarCsv.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this._btnExportarCsv.ForeColor = System.Drawing.Color.White;
            this._btnExportarCsv.Location = new System.Drawing.Point(825, 6);
            this._btnExportarCsv.Name = "_btnExportarCsv";
            this._btnExportarCsv.Size = new System.Drawing.Size(150, 32);
            this._btnExportarCsv.TabIndex = 2;
            this._btnExportarCsv.Text = "📥 Exportar CSV";
            this._btnExportarCsv.UseVisualStyleBackColor = false;
            this._btnExportarCsv.Click += new System.EventHandler(this.BtnExportarCsv_Click);

            this._btnBorrarTransaccion.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this._btnBorrarTransaccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnBorrarTransaccion.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this._btnBorrarTransaccion.ForeColor = System.Drawing.Color.White;
            this._btnBorrarTransaccion.Location = new System.Drawing.Point(985, 6);
            this._btnBorrarTransaccion.Name = "_btnBorrarTransaccion";
            this._btnBorrarTransaccion.Size = new System.Drawing.Size(155, 32);
            this._btnBorrarTransaccion.TabIndex = 3;
            this._btnBorrarTransaccion.Text = "🗑️ Eliminar";
            this._btnBorrarTransaccion.UseVisualStyleBackColor = false;
            this._btnBorrarTransaccion.Click += new System.EventHandler(this.BtnBorrarTransaccion_Click);

            // _dgvTransacciones
            this._dgvTransacciones.AllowUserToAddRows = false;
            this._dgvTransacciones.AllowUserToDeleteRows = false;
            this._dgvTransacciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dgvTransacciones.BackgroundColor = System.Drawing.Color.White;
            this._dgvTransacciones.ColumnHeadersHeight = 32;
            this._dgvTransacciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgvTransacciones.Location = new System.Drawing.Point(12, 182);
            this._dgvTransacciones.MultiSelect = false;
            this._dgvTransacciones.Name = "_dgvTransacciones";
            this._dgvTransacciones.ReadOnly = true;
            this._dgvTransacciones.RowHeadersVisible = false;
            this._dgvTransacciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvTransacciones.Size = new System.Drawing.Size(1152, 482);
            this._dgvTransacciones.TabIndex = 2;
            this._dgvTransacciones.SelectionChanged += new System.EventHandler(this.DgvTransacciones_SelectionChanged);
            this._dgvTransacciones.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvTransacciones_CellFormatting);

            // _lblEstadisticas
            this._lblEstadisticas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._lblEstadisticas.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lblEstadisticas.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this._lblEstadisticas.Location = new System.Drawing.Point(12, 664);
            this._lblEstadisticas.Name = "_lblEstadisticas";
            this._lblEstadisticas.Size = new System.Drawing.Size(1152, 30);
            this._lblEstadisticas.TabIndex = 3;
            this._lblEstadisticas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // ==========================================
            // PESTAÑA 3: VALIDACIÓN Y MÉTRICAS
            // ==========================================
            this._tabMetricas.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this._tabMetricas.Controls.Add(this._dgvMetricas);
            this._tabMetricas.Controls.Add(this._lblTituloCasos);
            this._tabMetricas.Controls.Add(this._dgvMatrizConfusion);
            this._tabMetricas.Controls.Add(this._lblTituloConfusion);
            this._tabMetricas.Controls.Add(this._pnlMetricasTop);
            this._tabMetricas.Location = new System.Drawing.Point(4, 40);
            this._tabMetricas.Name = "_tabMetricas";
            this._tabMetricas.Padding = new System.Windows.Forms.Padding(12);
            this._tabMetricas.Size = new System.Drawing.Size(1176, 706);
            this._tabMetricas.TabIndex = 2;
            this._tabMetricas.Text = "📈 Validación y Métricas";

            // _pnlMetricasTop
            this._pnlMetricasTop.BackColor = System.Drawing.Color.White;
            this._pnlMetricasTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._pnlMetricasTop.Controls.Add(this._btnEvaluarCasos);
            this._pnlMetricasTop.Controls.Add(this._lblResultadoExactitud);
            this._pnlMetricasTop.Controls.Add(this._lblMetricasSub);
            this._pnlMetricasTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._pnlMetricasTop.Location = new System.Drawing.Point(12, 12);
            this._pnlMetricasTop.Name = "_pnlMetricasTop";
            this._pnlMetricasTop.Padding = new System.Windows.Forms.Padding(10);
            this._pnlMetricasTop.Size = new System.Drawing.Size(1152, 65);
            this._pnlMetricasTop.TabIndex = 0;

            this._btnEvaluarCasos.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this._btnEvaluarCasos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnEvaluarCasos.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._btnEvaluarCasos.ForeColor = System.Drawing.Color.White;
            this._btnEvaluarCasos.Location = new System.Drawing.Point(10, 10);
            this._btnEvaluarCasos.Name = "_btnEvaluarCasos";
            this._btnEvaluarCasos.Size = new System.Drawing.Size(260, 42);
            this._btnEvaluarCasos.TabIndex = 0;
            this._btnEvaluarCasos.Text = "📊 Evaluar 20 Casos de Prueba";
            this._btnEvaluarCasos.UseVisualStyleBackColor = false;
            this._btnEvaluarCasos.Click += new System.EventHandler(this.BtnEvaluarCasos_Click);

            this._lblResultadoExactitud.AutoSize = true;
            this._lblResultadoExactitud.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this._lblResultadoExactitud.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this._lblResultadoExactitud.Location = new System.Drawing.Point(290, 8);
            this._lblResultadoExactitud.Name = "_lblResultadoExactitud";
            this._lblResultadoExactitud.Size = new System.Drawing.Size(460, 28);
            this._lblResultadoExactitud.Text = "Exactitud Global: Presiona el botón para evaluar.";

            this._lblMetricasSub.AutoSize = true;
            this._lblMetricasSub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this._lblMetricasSub.ForeColor = System.Drawing.Color.DimGray;
            this._lblMetricasSub.Location = new System.Drawing.Point(292, 36);
            this._lblMetricasSub.Name = "_lblMetricasSub";
            this._lblMetricasSub.Size = new System.Drawing.Size(525, 20);
            this._lblMetricasSub.Text = "Dataset de prueba independiente con 4 casos por categoría no vistos en entrenamiento.";

            // _lblTituloConfusion
            this._lblTituloConfusion.Dock = System.Windows.Forms.DockStyle.Top;
            this._lblTituloConfusion.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._lblTituloConfusion.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this._lblTituloConfusion.Location = new System.Drawing.Point(12, 77);
            this._lblTituloConfusion.Name = "_lblTituloConfusion";
            this._lblTituloConfusion.Padding = new System.Windows.Forms.Padding(0, 8, 0, 4);
            this._lblTituloConfusion.Size = new System.Drawing.Size(1152, 32);
            this._lblTituloConfusion.TabIndex = 1;
            this._lblTituloConfusion.Text = "Matriz de Confusión (Filas: Categoría Real  |  Columnas: Categoría Predicha):";

            // _dgvMatrizConfusion
            this._dgvMatrizConfusion.AllowUserToAddRows = false;
            this._dgvMatrizConfusion.AllowUserToDeleteRows = false;
            this._dgvMatrizConfusion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dgvMatrizConfusion.BackgroundColor = System.Drawing.Color.White;
            this._dgvMatrizConfusion.ColumnHeadersHeight = 30;
            this._dgvMatrizConfusion.Dock = System.Windows.Forms.DockStyle.Top;
            this._dgvMatrizConfusion.Location = new System.Drawing.Point(12, 109);
            this._dgvMatrizConfusion.MultiSelect = false;
            this._dgvMatrizConfusion.Name = "_dgvMatrizConfusion";
            this._dgvMatrizConfusion.ReadOnly = true;
            this._dgvMatrizConfusion.RowHeadersVisible = false;
            this._dgvMatrizConfusion.Size = new System.Drawing.Size(1152, 170);
            this._dgvMatrizConfusion.TabIndex = 2;
            this._dgvMatrizConfusion.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvMatrizConfusion_CellFormatting);

            // _lblTituloCasos
            this._lblTituloCasos.Dock = System.Windows.Forms.DockStyle.Top;
            this._lblTituloCasos.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._lblTituloCasos.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this._lblTituloCasos.Location = new System.Drawing.Point(12, 279);
            this._lblTituloCasos.Name = "_lblTituloCasos";
            this._lblTituloCasos.Padding = new System.Windows.Forms.Padding(0, 8, 0, 4);
            this._lblTituloCasos.Size = new System.Drawing.Size(1152, 32);
            this._lblTituloCasos.TabIndex = 3;
            this._lblTituloCasos.Text = "Desglose Individual de los 20 Casos de Prueba con Certeza:";

            // _dgvMetricas
            this._dgvMetricas.AllowUserToAddRows = false;
            this._dgvMetricas.AllowUserToDeleteRows = false;
            this._dgvMetricas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dgvMetricas.BackgroundColor = System.Drawing.Color.White;
            this._dgvMetricas.ColumnHeadersHeight = 32;
            this._dgvMetricas.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgvMetricas.Location = new System.Drawing.Point(12, 311);
            this._dgvMetricas.MultiSelect = false;
            this._dgvMetricas.Name = "_dgvMetricas";
            this._dgvMetricas.ReadOnly = true;
            this._dgvMetricas.RowHeadersVisible = false;
            this._dgvMetricas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvMetricas.Size = new System.Drawing.Size(1152, 383);
            this._dgvMetricas.TabIndex = 4;
            this._dgvMetricas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvMetricas_CellFormatting);

            // ==========================================
            // PESTAÑA 4: ENTRENAMIENTO Y CONTINUO
            // ==========================================
            this._tabEntrenamiento.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this._tabEntrenamiento.Controls.Add(this._dgvEntrenamiento);
            this._tabEntrenamiento.Controls.Add(this._lblTituloDataset);
            this._tabEntrenamiento.Controls.Add(this._grpNuevoEjemplo);
            this._tabEntrenamiento.Controls.Add(this._pnlEntrenamientoTop);
            this._tabEntrenamiento.Location = new System.Drawing.Point(4, 40);
            this._tabEntrenamiento.Name = "_tabEntrenamiento";
            this._tabEntrenamiento.Padding = new System.Windows.Forms.Padding(12);
            this._tabEntrenamiento.Size = new System.Drawing.Size(1176, 706);
            this._tabEntrenamiento.TabIndex = 3;
            this._tabEntrenamiento.Text = "🧠 Aprendizaje Continuo";

            // _pnlEntrenamientoTop
            this._pnlEntrenamientoTop.BackColor = System.Drawing.Color.White;
            this._pnlEntrenamientoTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._pnlEntrenamientoTop.Controls.Add(this._btnReentrenarContinuo);
            this._pnlEntrenamientoTop.Controls.Add(this._btnRestablecerBase);
            this._pnlEntrenamientoTop.Controls.Add(this._lblEstadoEntrenamiento);
            this._pnlEntrenamientoTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._pnlEntrenamientoTop.Location = new System.Drawing.Point(12, 12);
            this._pnlEntrenamientoTop.Name = "_pnlEntrenamientoTop";
            this._pnlEntrenamientoTop.Padding = new System.Windows.Forms.Padding(10);
            this._pnlEntrenamientoTop.Size = new System.Drawing.Size(1152, 65);
            this._pnlEntrenamientoTop.TabIndex = 0;

            this._btnReentrenarContinuo.BackColor = System.Drawing.Color.FromArgb(142, 68, 173);
            this._btnReentrenarContinuo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnReentrenarContinuo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._btnReentrenarContinuo.ForeColor = System.Drawing.Color.White;
            this._btnReentrenarContinuo.Location = new System.Drawing.Point(10, 10);
            this._btnReentrenarContinuo.Name = "_btnReentrenarContinuo";
            this._btnReentrenarContinuo.Size = new System.Drawing.Size(290, 42);
            this._btnReentrenarContinuo.TabIndex = 0;
            this._btnReentrenarContinuo.Text = "🔄 Reentrenar con Gastos Confirmados";
            this._btnReentrenarContinuo.UseVisualStyleBackColor = false;
            this._btnReentrenarContinuo.Click += new System.EventHandler(this.BtnReentrenarContinuo_Click);

            this._btnRestablecerBase.BackColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this._btnRestablecerBase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnRestablecerBase.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this._btnRestablecerBase.ForeColor = System.Drawing.Color.White;
            this._btnRestablecerBase.Location = new System.Drawing.Point(310, 10);
            this._btnRestablecerBase.Name = "_btnRestablecerBase";
            this._btnRestablecerBase.Size = new System.Drawing.Size(170, 42);
            this._btnRestablecerBase.TabIndex = 1;
            this._btnRestablecerBase.Text = "⚡ Restablecer Base";
            this._btnRestablecerBase.UseVisualStyleBackColor = false;
            this._btnRestablecerBase.Click += new System.EventHandler(this.BtnRestablecerBase_Click);

            this._lblEstadoEntrenamiento.AutoSize = true;
            this._lblEstadoEntrenamiento.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            this._lblEstadoEntrenamiento.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this._lblEstadoEntrenamiento.Location = new System.Drawing.Point(495, 20);
            this._lblEstadoEntrenamiento.Name = "_lblEstadoEntrenamiento";
            this._lblEstadoEntrenamiento.Size = new System.Drawing.Size(434, 21);
            this._lblEstadoEntrenamiento.TabIndex = 2;
            this._lblEstadoEntrenamiento.Text = "Estado: Modelo activo en memoria y sincronizado en disco.";

            // _grpNuevoEjemplo
            this._grpNuevoEjemplo.Controls.Add(this._lblNuevaFrase);
            this._grpNuevoEjemplo.Controls.Add(this._txtNuevaFrase);
            this._grpNuevoEjemplo.Controls.Add(this._lblNuevaCategoria);
            this._grpNuevoEjemplo.Controls.Add(this._cmbNuevaCategoria);
            this._grpNuevoEjemplo.Controls.Add(this._btnAgregarEjemplo);
            this._grpNuevoEjemplo.Dock = System.Windows.Forms.DockStyle.Top;
            this._grpNuevoEjemplo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._grpNuevoEjemplo.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this._grpNuevoEjemplo.Location = new System.Drawing.Point(12, 77);
            this._grpNuevoEjemplo.Name = "_grpNuevoEjemplo";
            this._grpNuevoEjemplo.Size = new System.Drawing.Size(1152, 75);
            this._grpNuevoEjemplo.TabIndex = 1;
            this._grpNuevoEjemplo.TabStop = false;
            this._grpNuevoEjemplo.Text = "Enseñar un nuevo concepto a la IA manualmente:";

            this._lblNuevaFrase.AutoSize = true;
            this._lblNuevaFrase.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lblNuevaFrase.Location = new System.Drawing.Point(12, 33);
            this._lblNuevaFrase.Name = "_lblNuevaFrase";
            this._lblNuevaFrase.Size = new System.Drawing.Size(90, 20);
            this._lblNuevaFrase.Text = "Frase/Gasto:";

            this._txtNuevaFrase.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._txtNuevaFrase.Location = new System.Drawing.Point(105, 29);
            this._txtNuevaFrase.Name = "_txtNuevaFrase";
            this._txtNuevaFrase.Size = new System.Drawing.Size(420, 29);
            this._txtNuevaFrase.TabIndex = 0;

            this._lblNuevaCategoria.AutoSize = true;
            this._lblNuevaCategoria.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lblNuevaCategoria.Location = new System.Drawing.Point(540, 33);
            this._lblNuevaCategoria.Name = "_lblNuevaCategoria";
            this._lblNuevaCategoria.Size = new System.Drawing.Size(77, 20);
            this._lblNuevaCategoria.Text = "Categoría:";

            this._cmbNuevaCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbNuevaCategoria.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._cmbNuevaCategoria.Items.AddRange(new object[] {
            "Alimentación",
            "Transporte",
            "Servicios",
            "Entretenimiento",
            "Salud y Educación"});
            this._cmbNuevaCategoria.Location = new System.Drawing.Point(620, 29);
            this._cmbNuevaCategoria.Name = "_cmbNuevaCategoria";
            this._cmbNuevaCategoria.Size = new System.Drawing.Size(200, 29);
            this._cmbNuevaCategoria.TabIndex = 1;

            this._btnAgregarEjemplo.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this._btnAgregarEjemplo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnAgregarEjemplo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._btnAgregarEjemplo.ForeColor = System.Drawing.Color.White;
            this._btnAgregarEjemplo.Location = new System.Drawing.Point(835, 26);
            this._btnAgregarEjemplo.Name = "_btnAgregarEjemplo";
            this._btnAgregarEjemplo.Size = new System.Drawing.Size(180, 34);
            this._btnAgregarEjemplo.TabIndex = 2;
            this._btnAgregarEjemplo.Text = "➕ Enseñar a la IA";
            this._btnAgregarEjemplo.UseVisualStyleBackColor = false;
            this._btnAgregarEjemplo.Click += new System.EventHandler(this.BtnAgregarEjemplo_Click);

            // _lblTituloDataset
            this._lblTituloDataset.Dock = System.Windows.Forms.DockStyle.Top;
            this._lblTituloDataset.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._lblTituloDataset.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this._lblTituloDataset.Location = new System.Drawing.Point(12, 152);
            this._lblTituloDataset.Name = "_lblTituloDataset";
            this._lblTituloDataset.Padding = new System.Windows.Forms.Padding(0, 8, 0, 4);
            this._lblTituloDataset.Size = new System.Drawing.Size(1152, 32);
            this._lblTituloDataset.TabIndex = 2;
            this._lblTituloDataset.Text = "Dataset de entrenamiento actual (Base + Aprendidos del usuario):";

            // _dgvEntrenamiento
            this._dgvEntrenamiento.AllowUserToAddRows = false;
            this._dgvEntrenamiento.AllowUserToDeleteRows = false;
            this._dgvEntrenamiento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dgvEntrenamiento.BackgroundColor = System.Drawing.Color.White;
            this._dgvEntrenamiento.ColumnHeadersHeight = 32;
            this._dgvEntrenamiento.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgvEntrenamiento.Location = new System.Drawing.Point(12, 184);
            this._dgvEntrenamiento.MultiSelect = false;
            this._dgvEntrenamiento.Name = "_dgvEntrenamiento";
            this._dgvEntrenamiento.ReadOnly = true;
            this._dgvEntrenamiento.RowHeadersVisible = false;
            this._dgvEntrenamiento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvEntrenamiento.Size = new System.Drawing.Size(1152, 510);
            this._dgvEntrenamiento.TabIndex = 3;
            this._dgvEntrenamiento.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvEntrenamiento_CellFormatting);

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 750);
            this.Controls.Add(this._tabs);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1050, 700);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clasificador Inteligente de Gastos - ML.NET & SQLite";
            this._tabs.ResumeLayout(false);
            this._tabDashboard.ResumeLayout(false);
            this._pnlDashboardToolbar.ResumeLayout(false);
            this._pnlDashboardToolbar.PerformLayout();
            this._pnlKpiContainer.ResumeLayout(false);
            this._pnlKpi1.ResumeLayout(false);
            this._pnlKpi1.PerformLayout();
            this._pnlKpi2.ResumeLayout(false);
            this._pnlKpi2.PerformLayout();
            this._pnlKpi3.ResumeLayout(false);
            this._pnlKpi3.PerformLayout();
            this._pnlKpi4.ResumeLayout(false);
            this._pnlKpi4.PerformLayout();
            this._pnlGraficos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._chartPie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._chartBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvResumenCategorias)).EndInit();

            this._tabRegistro.ResumeLayout(false);
            this._pnlFormulario.ResumeLayout(false);
            this._pnlFormulario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numMonto)).EndInit();
            this._pnlHistorialToolbar.ResumeLayout(false);
            this._pnlHistorialToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvTransacciones)).EndInit();

            this._tabMetricas.ResumeLayout(false);
            this._pnlMetricasTop.ResumeLayout(false);
            this._pnlMetricasTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvMatrizConfusion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvMetricas)).EndInit();

            this._tabEntrenamiento.ResumeLayout(false);
            this._pnlEntrenamientoTop.ResumeLayout(false);
            this._pnlEntrenamientoTop.PerformLayout();
            this._grpNuevoEjemplo.ResumeLayout(false);
            this._grpNuevoEjemplo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvEntrenamiento)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
