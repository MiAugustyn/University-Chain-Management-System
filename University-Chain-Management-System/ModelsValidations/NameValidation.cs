using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace University_Chain_Management_System.ModelsValidations
{
    public class NameValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var name = value as string;

            if (name == null) { return new ValidationResult("Name cannot be empty."); }
            if (name.Length > 64) { return new ValidationResult("Name is too long. (maximum 254 characters)"); }

            var pattern = @"^[\p{L}\p{M}\s]+$";
            if (!Regex.IsMatch(name, pattern)) { return new ValidationResult("Name contains invalid characters. Only letters are allowed."); }

            return ValidationResult.Success;
        }
    }
}

