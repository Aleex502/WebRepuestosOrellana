using System;
using System.Collections.Generic;
namespace WebRepuestosOrellana.Models.ViewModels
{
    public class CompraViewModel
    {
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaFactura { get; set; }
        public string SerieFactura { get; set; }
        public int ProveedorID { get; set; }
        public string UsuarioID { get; set; }
        public List<VentaLineaViewModel> lineasCompra { get; set; }
    }

    public class CompraLineaViewModel
    {
        public int NoLinea { get; set; }
        public int Cantidad { get; set; }
        public int ProductoID { get; set; }
        public Decimal Precio { get; set; }
    }
}