using System.ComponentModel.DataAnnotations;

namespace web_first.Models.CustomValidationAttribute
{
    public class IsPositiveAttribute: ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return !string.IsNullOrEmpty(ErrorMessage)
                ? ErrorMessage
                : $"Sorry, but '{name}' must be positive ";
        }


        public override bool IsValid(object value)
        {
            int number;

            if(!int.TryParse(value?.ToString(), out number))
            {

                throw new ValidationException("You cannot use IsPositiveAttribute with not a number");
            }

            return number > 0;
        }
    }
}
