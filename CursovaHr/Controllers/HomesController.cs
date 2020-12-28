using System.Web.Mvc;
using BLL.Service;
namespace CursovaHr.Controllers
{
    public class HomeController : Controller
    {

        private UnemService service;
        public HomeController()
        {
            service = new UnemService();
        }
        public ActionResult Index()
        {

            
            return View();
        }

        public ActionResult About()
        {
            

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}