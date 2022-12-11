using Microsoft.AspNetCore.Mvc;

namespace PeopleApp.Controllers
{
    public class AjaxController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
