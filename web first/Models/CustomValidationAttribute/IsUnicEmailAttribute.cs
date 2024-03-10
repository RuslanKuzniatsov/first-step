using System.ComponentModel.DataAnnotations;
using web_first.EfStuff.Repositores;

namespace web_first.Models.CustomValidationAttribute
{
    public class IsUnicEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            


            var galleryUserRepository = validationContext
                .GetService(typeof(GalleryUserRepository)) as GalleryUserRepository;

            var email = value?.ToString();

            var isDublicate = galleryUserRepository.IsEmailExist(email);

            

            
            return isDublicate 
                ? new ValidationResult("Email already is used")
                : ValidationResult.Success;
        }
    }
}
