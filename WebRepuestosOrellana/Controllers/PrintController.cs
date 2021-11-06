using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;

namespace WebRepuestosOrellana.Controllers
{
    public class PrintController : Controller
    {
        // GET: Print
        public ActionResult Venta(int id)
        {
            try
            {
                ReportDocument reporte = new ReportDocument();
                string strReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reportes/Venta.rpt");
                reporte.Load(strReportPath);
                reporte.SetDatabaseLogon("sa", "Aleex502");
                reporte.SetParameterValue("ID", id);
                Tables tables = reporte.Database.Tables;
                Stream stream = reporte.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Flush();
                reporte.Close();
                reporte.Dispose();
                return File(stream, MediaTypeNames.Application.Pdf);
            }
            catch(Exception e)
            {
                return Content($"<h1>{e.Message}</h1>");
            }
            
        }
    }
}