using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//Agregar los using para trabajar con Crystal
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

using CrystalReports.Reports; //Using de la carpeta Reports

namespace CrystalReports.Controllers
    //Agregar los using para trabajar con Crystal

{
    public class ProductosController : Controller
    {

        public ActionResult ReporteSimple()
        {
            return View(); //Se crea la vista 
        }

        public ActionResult ReporteParam()
        {
            return View();
        }

        public ActionResult VerReporte()
        {
            var reporte = new ReportClass(); //
            reporte.FileName = Server.MapPath("/Reports/CrystalReport1.rpt"); //La variable reporte accede mediante un MapPath que traza la ruta al servidor en la raiz

            //Conexion para el reporte
            var coninfo = ReportesConexion.getConexion(); //
            TableLogOnInfo logoninfo = new TableLogOnInfo(); //Representa la informacion de las tablas del reporte
            Tables tables; //La tabla que se alimentara del reporte
            tables = reporte.Database.Tables;

            //Recorre las tablas del reporte
            foreach (Table item in tables)
            {
                //Metiendo la informacion que se utilizara al reporte
                logoninfo = item.LogOnInfo; //
                logoninfo.ConnectionInfo = coninfo;
                item.ApplyLogOnInfo(logoninfo);
            }
            //Liberar recursos
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            Stream stream = reporte.ExportToStream(ExportFormatType.PortableDocFormat); //Se alimenta la pagina con stream de datos a una exportacion de tipo PDF
            return new FileStreamResult(stream, "application/pdf"); //retorna un archivo stream al tipo de contenido 
        }

        public ActionResult VerReporteParam(string parametro)
        {
            var reporte = new ReportClass(); //
            reporte.FileName = Server.MapPath("/Reports/CrystalReport2.rpt"); //La variable reporte accede mediante un MapPath que traza la ruta al servidor en la raiz

            reporte.SetParameterValue("paramCategorias",parametro); //Estableciendo un parametro al reporte

            //Conexion para el reporte
            var coninfo = ReportesConexion.getConexion(); //
            TableLogOnInfo logoninfo = new TableLogOnInfo(); //Representa la informacion de las tablas del reporte
            Tables tables; //La tabla que se alimentara del reporte
            tables = reporte.Database.Tables;

            //Recorre las tablas del reporte
            foreach (Table item in tables)
            {
                //Metiendo la informacion que se utilizara al reporte
                logoninfo = item.LogOnInfo; //
                logoninfo.ConnectionInfo = coninfo;
                item.ApplyLogOnInfo(logoninfo);
            }
            //Liberar recursos
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            Stream stream = reporte.ExportToStream(ExportFormatType.PortableDocFormat); //Se alimenta la pagina con stream de datos a una exportacion de tipo PDF
            return new FileStreamResult(stream, "application/pdf"); //retorna un archivo stream al tipo de contenido 
        }
        // GET: Productos
        public ActionResult Index()
        {
            return View();
        }
    }
}