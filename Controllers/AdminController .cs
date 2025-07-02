using Microsoft.AspNetCore.Mvc;

namespace WasteFood.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
