using System.ComponentModel.DataAnnotations;

namespace University_Chain_Management_System.ModelsValidations
{
    public class CreationDateValidation : DateValidation
    {
        override protected ValidationResult ValidateParsed(DateTime parsed, string name)
        {
            if (parsed.Date > DateTime.Today) { return new ValidationResult($"{name} cannot be later than today's date."); }

            if (parsed.Year < MinYear) { return new ValidationResult($"{name} year cannot be earlier than {MinYear}."); }

            return ValidationResult.Success;
        }
    }
}
