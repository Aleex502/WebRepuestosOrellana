using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebRepuestosOrellana.Models
{
    public class VentaEncabezado
    {
        [Key]
        public int ID { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public Empleado IdUsuario { get; set; }
        public List<VentaDetalle> Detalles { get; set; }
    }
}