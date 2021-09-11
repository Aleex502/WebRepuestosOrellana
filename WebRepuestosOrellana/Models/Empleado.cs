using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebRepuestosOrellana.Models
{
    public class Empleado
    {
        public int ID { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string DPI { get; set; }
        public string TelefonoCasa { get; set; }
        public string Celular { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Decimal ComisionPorVentas { get; set; }
    }
}