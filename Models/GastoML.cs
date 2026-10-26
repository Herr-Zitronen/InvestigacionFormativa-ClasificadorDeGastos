using System.Collections.Generic;
using Microsoft.ML.Data;

namespace _2InvestigacionFormativa.Models
{
    public class GastoInput
    {
        [LoadColumn(0)]
        public string Descripcion { get; set; }

        [LoadColumn(1)]
        public string Categoria { get; set; }
    }

    public class GastoPrediction
    {
        [ColumnName("PredictedLabel")]
        public string PredictedLabel { get; set; }

        public float[] Score { get; set; }
    }

    public class PrediccionResultado
    {
        public string Categoria { get; set; }
        public double Confianza { get; set; } // 0.0 a 1.0 (ej. 0.92 = 92%)
        public Dictionary<string, double> DistribucionProbabilidades { get; set; } = new Dictionary<string, double>();

        public string ConfianzaTexto => $"{Confianza * 100.0:F1}%";
        public bool EsConfiable => Confianza >= 0.45;
    }

    public class DetalleEvaluacion
    {
        public string Descripcion { get; set; }
        public string CategoriaReal { get; set; }
        public string CategoriaPredicha { get; set; }
        public double Confianza { get; set; }
        public string ConfianzaTexto => $"{Confianza * 100.0:F1}%";
        public string Acierto { get; set; }
    }

    public class ResultadoEvaluacion
    {
        public int TotalCasos { get; set; }
        public int Aciertos { get; set; }
        public double PorcentajeExactitud { get; set; }
        public double MacroAccuracy { get; set; }
        public double MicroAccuracy { get; set; }
        public double LogLoss { get; set; }
        public List<string> Categorias { get; set; } = new List<string>();
        public int[,] MatrizConfusion { get; set; }
        public List<DetalleEvaluacion> Detalles { get; set; } = new List<DetalleEvaluacion>();
    }

    public class ResumenCategoria
    {
        public string Categoria { get; set; }
        public decimal TotalMonto { get; set; }
        public int CantidadTransacciones { get; set; }
        public double PorcentajeDelTotal { get; set; }
        public decimal PromedioPorTransaccion => CantidadTransacciones > 0 ? (TotalMonto / CantidadTransacciones) : 0m;
    }

    public class EjemploEntrenamientoVista
    {
        public string Origen { get; set; } // "Base" o "Confirmado (Usuario)"
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
    }
}
