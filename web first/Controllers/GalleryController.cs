using Microsoft.AspNetCore.Mvc;

namespace web_first.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Index()
        {
            int a = 1;
            return View(a);
        }
    }
}
