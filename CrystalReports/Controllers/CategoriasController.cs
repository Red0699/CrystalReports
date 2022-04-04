using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrystalReports.Models;

namespace CrystalReports.Controllers
{
    public class CategoriasController : Controller
    {

        mitiendaEntities contexto = new mitiendaEntities();

        public JsonResult GetCategorias()
        {
            var cats = contexto.categorias.Select(x => x.nombrecat).ToList(); //accedor al contexto de la tabla 
            return Json(new { resultado = cats },JsonRequestBehavior.AllowGet);
        }

        // GET: Categorias
        public ActionResult Index()
        {
            return View();
        }
    }
}