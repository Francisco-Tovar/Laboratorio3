using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Security;


namespace WebApplication.Controllers
{
    [SecurityFilter]

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }        
        public ActionResult vClientes()
        {
            return View();
        }
        public ActionResult vCuentas()
        {
            return View();
        }
        public ActionResult vCreditos()
        {
            return View();
        }
        public ActionResult vDirecciones()
        {
            return View();
        }
        public ActionResult vMovimientos()
        {
            return View();
        }
        public ActionResult vListarMovimientos()
        {
            return View();
        }
        public ActionResult vPagos()
        {
            return View();
        }
        public ActionResult vListarPagos()
        {
            return View();
        }
    }
}