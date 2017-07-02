    using System.Web.Mvc;

namespace ApplicantTracker.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


    }
}