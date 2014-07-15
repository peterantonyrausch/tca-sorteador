using System.Web.Mvc;

namespace TCA.Visao.Web.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Projeto The Clean Architecture - Sorteador";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Entre em contato!";

            return View();
        }
    }
}