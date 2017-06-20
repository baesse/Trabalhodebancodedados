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
        public ActionResult Consultar(Models.Cliente Clientecadastro)
        {
            
            return View();
        }
        public ActionResult Deletar(Models.Cliente Clientecadastro)
        {
           

            return View();
        }
        public ActionResult Editar(Models.Cliente Clientecadastro)
        {
            return View();
            
        }
        public void cadastrar(Models.Cliente Clientecadastro)
        {
            Clientecadastro.CadastrarCliente(Clientecadastro);
            Response.Redirect(@"~/home/index");


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