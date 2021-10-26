using System;
using System.ComponentModel.DataAnnotations;

namespace WebRepuestosOrellana.Models
{
    public class Transaccion
    {
        [Key]
        public int ID { get; set; }
        public int TipoTransaccion { get; set; }
        public int CompraVentaID { get; set; }
        public int ProductoId { get; set; }
        public DateTime FechaHora { get; set; }
    }
}