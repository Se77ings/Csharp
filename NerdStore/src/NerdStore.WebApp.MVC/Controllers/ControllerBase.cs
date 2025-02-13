
using Microsoft.AspNetCore.Mvc;

namespace NerdStore.WebApp.MVC.Controllers
{
    public abstract class ControllerBase : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        protected Guid ClienteId = new Guid();
    }
}
