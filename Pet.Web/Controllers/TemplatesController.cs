using System.Web.Mvc;

namespace Pet.Web.Controllers
{
    public class TemplatesController : Controller
    {
        public ActionResult Home()
        {
            return PartialView("~/Views/Templates/Home.cshtml");
        }

        public ActionResult MyPets()
        {
            return PartialView("~/Views/Templates/MyPets.cshtml");
        }
    }
}