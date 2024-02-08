using System;
using System.ComponentModel.DataAnnotations;

namespace web_first.Models
{
    public class GalleryUserAutorization
    {
        [Required(ErrorMessage = "Enter Name!")]
        public string Name { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter Password!")]
        public string Password { get; set; }
    }
}
