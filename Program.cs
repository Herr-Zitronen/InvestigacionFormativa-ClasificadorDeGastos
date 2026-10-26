using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using _2InvestigacionFormativa.Models;
using _2InvestigacionFormativa.Services;

namespace _2InvestigacionFormativa
{
    internal static class Program
    {
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AttachConsole(int pid);

        [STAThread]
        static void Main(string[] args)
        {
            if (args != null && args.Length > 0 && args[0] == "--test")
            {
                AttachConsole(-1);
                EjecutarPruebasConsola();
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        private static void EjecutarPruebasConsola()
        {
            var sb = new StringBuilder();
            Action<string> log = msg => {
                Console.WriteLine(msg);
                sb.AppendLine(msg);
            };

            log("=== INICIO DE PRUEBAS DE SERVICIOS RENOVADOS ===");

            // 1. Probar SQLite DatabaseService
            log("\n[1] Probando DatabaseService (CRUD y Resumen)...");
            var db = new DatabaseService();
            var tNueva = new Transaccion
            {
                Fecha = DateTime.Now,
                Descripcion = "Almuerzo ejecutivo gourmet",
                Monto = 25000m,
                CategoriaSugeridaIA = "Alimentación",
                CategoriaConfirmada = "Alimentación",
                ConfianzaIA = 0.95
            };
            db.GuardarTransaccion(tNueva);
            log($"Transacción guardada con ID: {tNueva.Id}");

            // Prueba de actualización
            tNueva.Monto = 27000m;
            db.ActualizarTransaccion(tNueva);
            log("Transacción actualizada con nuevo monto: 27000");

            var resumen = db.ObtenerResumenPorCategoria();
            log($"Categorías en resumen financiero: {resumen.Count}");
            foreach (var r in resumen)
            {
                log($" - {r.Categoria}: {r.TotalMonto:C2} ({r.PorcentajeDelTotal:F1}%)");
            }

            // 2. Probar MLService con Confianza y Probabilidades
            log("\n[2] Probando MLService con probabilidades y confianza...");
            var ml = new MLService();
            var p1 = ml.PredecirDetalle("Cena en restaurante italiano con vino");
            log($"Predicción 1: {p1.Categoria} (Confianza: {p1.ConfianzaTexto})");
            foreach (var kvp in p1.DistribucionProbabilidades)
            {
                log($"   * {kvp.Key}: {kvp.Value * 100:F1}%");
            }

            var p2 = ml.PredecirDetalle("Pasaje bus transmilenio");
            log($"Predicción 2: {p2.Categoria} (Confianza: {p2.ConfianzaTexto})");

            // 3. Probar Aprendizaje Continuo
            log("\n[3] Probando Aprendizaje Continuo con confirmados...");
            var confirmados = db.ObtenerGastosConfirmadosParaEntrenamiento();
            int totalEntrenados = ml.EntrenarConDatosBaseYConfirmados(confirmados);
            log($"Total de ejemplos entrenados (Base + Confirmados): {totalEntrenados}");

            // 4. Probar Evaluación y Matriz de Confusión
            log("\n[4] Evaluando métricas y Matriz de Confusión...");
            var resultado = ml.EvaluarMetricas();
            log($"Total casos: {resultado.TotalCasos} | Aciertos: {resultado.Aciertos} | Exactitud: {resultado.PorcentajeExactitud}%");

            log("\nMatriz de Confusión (Filas=Real, Columnas=Predicho):");
            log(string.Format("{0,-20} | {1}", "Real \\ Pred", string.Join(" | ", resultado.Categorias)));
            for (int i = 0; i < resultado.Categorias.Count; i++)
            {
                var fila = new StringBuilder();
                fila.Append(string.Format("{0,-20} | ", resultado.Categorias[i]));
                for (int j = 0; j < resultado.Categorias.Count; j++)
                {
                    fila.Append(string.Format("{0,12} | ", resultado.MatrizConfusion[i, j]));
                }
                log(fila.ToString());
            }

            // 5. Probar inicialización completa de la UI (Form1)
            log("\n[5] Probando inicialización de Form1 y componentes visuales...");
            using (var form = new Form1())
            {
                log($"Formulario creado correctamente. Título: '{form.Text}', Dimensiones: {form.Width}x{form.Height}");
            }

            log("\n=== PRUEBAS COMPLETADAS SATISFACTORIAMENTE ===");
            File.WriteAllText("test_results.txt", sb.ToString());
        }
    }
}
