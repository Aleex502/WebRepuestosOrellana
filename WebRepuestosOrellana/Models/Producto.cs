using System;
using System.ComponentModel.DataAnnotations;

namespace WebRepuestosOrellana.Models
{
    public class Producto
    {
        [Key]
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public Decimal Precio { get; set; }
        public int TipoProductoID { get; set; }
        public TipoProducto TipoProducto { get; set; }

    }
}