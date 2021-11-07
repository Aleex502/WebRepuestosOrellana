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

        public ActionResult Compra(int id)
        {
            try
            {
                ReportDocument reporte = new ReportDocument();
                string strReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reportes/Compra.rpt");
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
            catch (Exception e)
            {
                return Content($"<h1>{e.Message}</h1>");
            }

        }
        public ActionResult StockActual(int id)
        {
            try
            {
                ReportDocument reporte = new ReportDocument();
                string strReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reportes/StockActual.rpt");
                reporte.Load(strReportPath);
                reporte.SetDatabaseLogon("sa", "Aleex502");
                Tables tables = reporte.Database.Tables;
                Stream stream = null;
                if (id == 1)
                {
                    stream = reporte.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Flush();
                    reporte.Close();
                    reporte.Dispose();
                    return File(stream, MediaTypeNames.Application.Pdf);
                }
                else
                {
                    stream = reporte.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel);
                    stream.Flush();
                    reporte.Close();
                    reporte.Dispose();
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream, "application/vnd.ms-excel", "StockActual.xls");
                }
            }
            catch (Exception e)
            {
                return Content($"<h1>{e.Message}</h1>");
            }

        }

        public ActionResult Transacciones(int id)
        {
            try
            {
                ReportDocument reporte = new ReportDocument();
                string strReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reportes/Transacciones.rpt");
                reporte.Load(strReportPath);
                reporte.SetDatabaseLogon("sa", "Aleex502");
                Tables tables = reporte.Database.Tables;
                Stream stream = null;
                if (id == 1)
                {
                    stream = reporte.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Flush();
                    reporte.Close();
                    reporte.Dispose();
                    return File(stream, MediaTypeNames.Application.Pdf);
                }
                else
                {
                    stream = reporte.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel);
                    stream.Flush();
                    reporte.Close();
                    reporte.Dispose();
                    return File(stream, MediaTypeNames.Application.Octet);
                }

                
            }
            catch (Exception e)
            {
                return Content($"<h1>{e.Message}</h1>");
            }

        }


    }
}