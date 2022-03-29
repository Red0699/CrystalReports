using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//Agregar los using para trabajar con Crystal
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalReports.Reports;

namespace CrystalReports.Controllers
    //Agregar los using para trabajar con Crystal

{
    public class ProductosController : Controller
    {

        public ActionResult ReporteSimple()
        {
            return View();
        }

        public ActionResult ReporteParam()
        {
            return View();
        }

        public ActionResult VerReporte()
        {
            var reporte = new ReportClass(); //
            reporte.FileName = Server.MapPath("/Reports/CrystalReport1.rpt");

            //Conexion para el reporte
            var coninfo = ReportesConexion.getConexion(); //
            TableLogOnInfo logoninfo = new TableLogOnInfo();
            Tables tables;
            tables = reporte.Database.Tables;
            foreach (Table item in tables)
            {
                logoninfo = item.LogOnInfo;
                logoninfo.ConnectionInfo = coninfo;
                item.ApplyLogOnInfo(logoninfo);
            }
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            Stream stream = reporte.ExportToStream(ExportFormatType.PortableDocFormat);
            return new FileStreamResult(stream, "application/pdf");
        }
        // GET: Productos
        public ActionResult Index()
        {
            return View();
        }
    }
}