using System;
using System.ComponentModel.DataAnnotations;
using web_first.Models.CustomValidationAttribute;

namespace web_first.Models
{
    public class GalleryUserRegistration
    {
        [Required(ErrorMessage = "Enter Email!")]
        [IsUnicEmail]
        public string Email { get; set; }


        [Required(ErrorMessage = "Enter Name!")]        
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Password!")]        
        public string Password { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        internal bool IsEmailExist(string str)
        {
            throw new NotImplementedException();
        }
    }
}
