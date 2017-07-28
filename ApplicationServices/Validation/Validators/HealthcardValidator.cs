using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Validators;
using ValueObjects.Health;

namespace ApplicationServices.Validation.Validators
{
    public class HealthcardValidator : AbstractValidator<Healthcard>
    {
        public HealthcardValidator()
        {
            var healthcardNumberPattern = @"(^$)|(^\d{4}([- ]?\d{3}){2}$)"; // blank or 10 digits;
            var healthcardVersionPattern = @"^[A-Z]{0,2}$";
            RuleFor(card => card.Number).SetValidator(new RegularExpressionValidator(healthcardNumberPattern)).WithMessage("Healthcard number must be 10 digits");
            RuleFor(card => card.VersionCode).SetValidator(new RegularExpressionValidator(healthcardVersionPattern)).WithMessage("Healthcard version code must range between 0-2 (uppercase) characters from the alphabet");
            RuleFor(card => card.ExpiryDate).Must(date => date==null || date > DateTime.Now.Date).WithMessage("The date entered is expired");
        }
    }
}
