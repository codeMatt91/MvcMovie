using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class MoreThanOneWordValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validation)
        {
            string fieldValue = (string) value;
            if (fieldValue == null || fieldValue.Trim().IndexOf(" ") == -1)
                return  new ValidationResult("Il campo deve avere almeno 2 parole");

            return ValidationResult.Success;
        }
    }
}
