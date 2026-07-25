using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
