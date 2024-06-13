using Microsoft.AspNetCore.Mvc;

namespace Tray.Controllers
{
    public class TrayModelsController : Controller
    {
        // GET: /Tray/
        public IActionResult Index()
        {
            return View();
        }
    }
}
