using System.ComponentModel.DataAnnotations;

namespace web_first.Models.CustomValidationAttribute
{
    public class MyRangeAttribute: ValidationAttribute
    {
        private int _min;
        private int _max;

        public MyRangeAttribute(int min, int max)
        {
            _min = min;
            _max = max;
        }

        public override string FormatErrorMessage(string name)
        {
            return !string.IsNullOrEmpty(ErrorMessage)
                ? ErrorMessage
                : $"Sorry, but '{name}' must be more than {_min} and less than {_max}  ";
        }


        public override bool IsValid(object value)
        {
            int number;

            if(!int.TryParse(value?.ToString(), out number))
            {

                throw new ValidationException("You cannot use IsPositiveAttribute with not a number");
            }

            return number > 0 && number<100;
        }
    }
}
