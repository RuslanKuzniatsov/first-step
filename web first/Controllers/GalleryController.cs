using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using web_first.EfStuff;
using web_first.EfStuff.DbModel;
using web_first.EfStuff.Repositores;
using web_first.Models;

namespace web_first.Controllers
{
    public class GalleryController : Controller
    {
        private ImageRepository _imageRepository;
        private ImageCommentRepository _commentRepository;

        public GalleryController(ImageCommentRepository commentRepository, ImageRepository imageRepository)
        {
            _commentRepository = commentRepository;
            _imageRepository = imageRepository;
        }

        

        public IActionResult Index()
        {
            var dbImages = _imageRepository.GetAll();

            var viewModels = dbImages.Select(dbImage => new ImageViewModel()
            {
                Id = dbImage.Id,
                Name = dbImage.Name
            }).ToList();
                      
                
            return View(viewModels);
        }
        public IActionResult ShowImage(int id)
        {
            var dbImage = _imageRepository.Get(id);

            var model = new ImageUrlViewModel
            {
                Id = dbImage.Id,
                Url = dbImage.Url,
                Comments = dbImage.Comments.Select(x => x.Text).ToList(),
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

            var adminComment = new ImageComment()
            {
                
                Text = "first comment"
            };
            dbImage.Comments = new List<ImageComment>()
            {
                adminComment
            };
            _imageRepository.Save(dbImage);
            
            return View(viewModel);
        }
        public IActionResult AddComment(int ImageId, string text)
        {
            var image = _imageRepository.Get(ImageId);
            var comment = new ImageComment()
            {
                Text = text,
                Image = image,
            };
            _commentRepository.Save(comment);

            return RedirectToAction("ShowImage", new {id = ImageId});
        }




    }
}
