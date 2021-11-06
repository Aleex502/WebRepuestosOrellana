using System;
using System.Collections.Generic;
namespace WebRepuestosOrellana.Models.ViewModels
{
    public class VentaViewModel
    {
        public int ClienteID { get; set; }
        public int EmpleadoID { get; set; }
        public List<VentaLineaViewModel> lineasVenta { get; set; }
    }

    public class VentaLineaViewModel
    {
        public int NoLinea { get; set; }
        public int Cantidad { get; set; }
        public int ProductoID { get; set; }
        public Decimal Precio { get; set; }
    }
}