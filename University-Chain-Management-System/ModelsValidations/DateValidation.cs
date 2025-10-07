using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace University_Chain_Management_System.ModelsValidations
{
    public class DateValidation : ValidationAttribute
    {
        static int MinYear { get { return 1900; } }

        static int MaxYear { get { return DateTime.UtcNow.Year + 50; } }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var name = validationContext?.DisplayName ?? "The field";

            if (value == null) { return ValidationResult.Success; }
            if (value is DateTime dateTime) { return ValidateParsed(dateTime, name); }

            var s = value as string;

            if (s == null) { return new ValidationResult($"{name} must be a date in dd/MM/yyyy format."); }

            s = s.Trim();
            s = s.Replace('.', '/').Replace('-', '/');

            if (!DateTime.TryParseExact(s, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsed)) 
            { return new ValidationResult($"{name} must be a valid date in dd/MM/yyyy format."); }

            return ValidateParsed(parsed, name);
        }

        private ValidationResult ValidateParsed(DateTime parsed, string name)
        {
            if (parsed.Year < MinYear)
                return new ValidationResult($"{name} year cannot be earlier than {MinYear}.");

            if (parsed.Year > MaxYear)
                return new ValidationResult($"{name} year cannot be later than {MaxYear}.");

            return ValidationResult.Success;
        }
    }
}
