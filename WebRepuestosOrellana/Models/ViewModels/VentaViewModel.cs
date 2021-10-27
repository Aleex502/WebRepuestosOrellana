using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebRepuestosOrellana.Models.ViewModels
{
    public class VentaViewModel : Venta
    {
        public List<VentaLineaViewModel> lineasVenta { get; set; }
    }

    public class VentaLineaViewModel : VentaLinea
    {

    }
}