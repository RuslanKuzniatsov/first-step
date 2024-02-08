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
        private GalleryUserRepository _userRepository;

        public GalleryController(ImageCommentRepository commentRepository, ImageRepository imageRepository, GalleryUserRepository userRepository)
        {
            _commentRepository = commentRepository;
            _imageRepository = imageRepository;
            _userRepository = userRepository;
        }

        

        public IActionResult Index(int page = 1)
        {
            var perPage = 2;
            var dbImages = _imageRepository.GetAll().Skip((page - 1)  * perPage).Take(perPage);

            var imageViewModel = dbImages.Select(dbImage => new ImageViewModel()
            {
                Id = dbImage.Id,
                Name = dbImage.Name
            }).ToList();
            var viewModel = new IndexGalleryViewModel
            {
                Page = page,
                Images = imageViewModel
            };
            
                      
                
            return View(viewModel);
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


        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(GalleryUserRegistration userViewModel)
        {
            if (ModelState.IsValid)
            {
                var userDb = new GalleryUser
                {
                    Email = userViewModel.Email,
                    Password = userViewModel.Password,
                    Name = userViewModel.Name,
                };
                _userRepository.Save(userDb);
                return RedirectToRoute("default", new { controller = "Gallery", action = "index" });

            }
            else {
                return View();
                 };
        }


        [HttpGet]
        public IActionResult Autorization()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Autorization(GalleryUserRegistration userViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var user = _userRepository.GetByNameAndPass(userViewModel.Name, userViewModel.Password);
            if (user == null)
            {
                return View();
            }
            return RedirectToRoute("default", new { controller = "Gallery", action = "index", id = user.Id });
        }

    }
}
