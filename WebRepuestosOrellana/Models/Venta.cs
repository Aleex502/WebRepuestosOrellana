using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebRepuestosOrellana.Models
{
    public class Venta
    {
        [Key]
        public int ID { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public int ClienteID { get; set; }
        public int EmpleadoID { get; set; }
        public Cliente Cliente { get; set; }
        public Empleado Empleado { get; set; }
        public ICollection<VentaLinea> VentaLineas { get; set; }
    }
}