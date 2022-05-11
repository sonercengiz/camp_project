using Microsoft.AspNetCore.Mvc;

namespace camp_project.Controllers
{
    public class CampgroundController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
