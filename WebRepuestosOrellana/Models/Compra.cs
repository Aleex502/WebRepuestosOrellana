using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebRepuestosOrellana.Models
{
    public class Compra
    {
        [Key]
        public int ID { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaFactura { get; set; }
        public string SerieFactura { get; set; }
        public int ProveedorID { get; set; }
        public string UsuarioID { get; set; }
        public ApplicationUser Usuario { get; set; }
        public Proveedor Proveedor { get; set; }
        public ICollection<CompraLinea> CompraLineas { get; set; }
    }
}