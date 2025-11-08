using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace University_Chain_Management_System.ModelsValidations
{
    public class EmailValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var email = value as string;

            if (email == null) { return ValidationResult.Success; }

            if (email.Length > 128) { return new ValidationResult("Email is too long. (maximum 254 characters)"); }
               

            if (email.Count(c => c == '@') == 0) { return new ValidationResult("Email must contain exactly one @ symbol."); }
            if (email.Count(c => c == '@') > 1) { return new ValidationResult("Email must not contain more than one @ symbol."); }

            var parts = email.Split(['@'], 2);
            var local = parts[0];
            var domain = parts[1];

            if (string.IsNullOrEmpty(local)) { return new ValidationResult("Email must have characters before the @ symbol."); }
            if (string.IsNullOrEmpty(domain)) { return new ValidationResult("Email must have characters after the @ symbol."); }

            if (Regex.IsMatch(email, @"[^A-Za-z0-9._\-@]")) { return new ValidationResult("Email contains invalid characters. Only letters, digits, dot, underscore and hyphen are allowed."); }

            if (local.StartsWith(".") || local.EndsWith(".")) { return new ValidationResult("Local part cannot start or end with a dot."); }
            if (local.Contains("..")) { return new ValidationResult("Local part cannot contain consecutive dots."); }

            if (!domain.Contains(".")) { return new ValidationResult("Domain must contain at least one dot."); }

            var domainParts = domain.Split('.');
            var tld = domainParts.Last();

            if (!Regex.IsMatch(tld, @"^[A-Za-z]{2,24}$")) { return new ValidationResult("Top-level domain must be letters only and 2 to 24 characters long."); }

            foreach (var label in domainParts)
            {
                if (string.IsNullOrEmpty(label)) { return new ValidationResult("Domain labels must not be empty."); }
                if (!Regex.IsMatch(label, @"^[A-Za-z0-9-]+$")){ return new ValidationResult("Domain labels may contain only letters, digits and hyphens."); }
                if (label.StartsWith("-") || label.EndsWith("-")){ return new ValidationResult("Domain labels must not start or end with a hyphen."); }
            }

            return ValidationResult.Success;
        }
    }
}
