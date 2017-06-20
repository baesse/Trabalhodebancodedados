using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDBD.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Consultar()
        {
           
            return View();
        }
        public ActionResult Deletar()
        {

            return View();
        }
        public ActionResult Editar()
        {

            return View();
        }
        public void cadastrar(Models.Cliente Clientecadastro)
        {

            Response.Redirect(@"~/views/home/index");


        }
       
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}