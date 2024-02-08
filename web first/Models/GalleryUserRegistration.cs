using System;
using System.ComponentModel.DataAnnotations;

namespace web_first.Models
{
    public class GalleryUserRegistration
    {
        [Required(ErrorMessage = "Enter Email!")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Enter Name!")]        
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Password!")]        
        public string Password { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
    }
}
