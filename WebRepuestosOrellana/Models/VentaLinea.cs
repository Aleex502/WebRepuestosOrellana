using System;
using System.ComponentModel.DataAnnotations;

namespace WebRepuestosOrellana.Models
{
    public class VentaLinea
    {
        [Key]
        public int ID { get; set; }
        public int NoLinea { get; set; }
        public int ProductoID { get; set; }
        public int Cantidad { get; set; }
        public int VentaID { get; set; }
        public Decimal Precio { get; set; }
        public Producto Producto { get; set; }
        public Venta Venta { get; set; }
    }
}