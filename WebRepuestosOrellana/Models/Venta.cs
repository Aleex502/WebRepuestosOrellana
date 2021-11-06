using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebRepuestosOrellana.Models
{
    public class Venta
    {
        [Key]
        public int ID { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int ClienteID { get; set; }
        public string UsuarioID { get; set; }
        public ApplicationUser Usuario { get; set; }
        public Cliente Cliente { get; set; }
        public Empleado Empleado { get; set; }
        public ICollection<VentaLinea> VentaLineas { get; set; }
    }
}