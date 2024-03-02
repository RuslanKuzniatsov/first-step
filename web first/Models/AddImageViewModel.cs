using System.ComponentModel.DataAnnotations;
using web_first.Models.CustomValidationAttribute;

namespace web_first.Models
{
    public class AddImageViewModel
    {
        [Required]
        public string Url { get; set; }

        [Required]
        public string Name { get; set; }

        [MyRange(0,100)]
        public int Rate { get; set; }


    }
}
