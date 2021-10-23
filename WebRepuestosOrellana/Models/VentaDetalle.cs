using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebRepuestosOrellana.Models
{
    public class VentaDetalle
    {
        [Key]
        public int ID { get; set; }
        public int NoLinea { get; set; }
        public Producto Producto { get; set; }
    }
}