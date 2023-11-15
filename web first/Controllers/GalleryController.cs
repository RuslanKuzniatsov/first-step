using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using web_first.EfStuff;
using web_first.EfStuff.DbModel;
using web_first.Models;

namespace web_first.Controllers
{
    public class GalleryController : Controller
    {
        private WebContext _webContext;

        public GalleryController(WebContext webContext)
        {
            _webContext = webContext;
        }

        public IActionResult Index()
        {
            var dbImages = _webContext.Images.ToList();

            var viewModels = dbImages.Select(dbImage => new ImageViewModel()
            {
                Id = dbImage.Id,
                Name = dbImage.Name
            }).ToList();
                      
                
            return View(viewModels);
        }
        public IActionResult ShowImage(int id)
        {
            var dbImage = _webContext.Images.First(x => x.Id==id);

            var model = new ImageUrlViewModel
            {
                Url = dbImage.Url,
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult AddImage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddImage(AddImageViewModel viewModel)
        {
            var dbImage = new Image()
            {
                Url = viewModel.Url,
                Name = viewModel.Name,
                Rate = viewModel.Rate,
            };
            _webContext.Images.Add(dbImage);
            _webContext.SaveChanges();
            return View(viewModel);
        }

    }
}
