using System;

namespace _2InvestigacionFormativa.Models
{
    public class Transaccion
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public string CategoriaSugeridaIA { get; set; }
        public string CategoriaConfirmada { get; set; }
        public double ConfianzaIA { get; set; }
    }
}
