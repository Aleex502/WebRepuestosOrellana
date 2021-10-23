using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebRepuestosOrellana.Models
{
    public class Producto
    {
        [Key]
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public int TipoProductoID { get; set; }
        public TipoProducto TipoProducto { get; set; }

    }
}