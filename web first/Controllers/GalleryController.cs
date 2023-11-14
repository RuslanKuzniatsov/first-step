using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using web_first.Models;

namespace web_first.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Index()
        {
            var models = new List<ImageViewModel>()
            {
                new ImageViewModel
                {
                    Id = 1,
                    Name = "nice"
                },
                new ImageViewModel
                {
                    Id = 2,
                    Name = "good"
                },
            };
                
            return View(models);
        }
        public IActionResult AddImage(int id)
        {
            var model = new ImageUrlViewModel();
            switch (id)
            {
                case 1:
                    model.Url = "/images/gallery/girl1.jpg";
                    break;
                case 2:
                    model.Url = "/images/gallery/girl2.jpg";
                    break;
                default:
                    break;
            }
            return View(model);
        }
    }
}
