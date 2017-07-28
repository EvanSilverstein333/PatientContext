using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using PatientManager.Contract.Dto;
using ValueObjects.Health;

namespace ApplicationServices.Validation.Validators
{
    public class HealthIdValidator : AbstractValidator<HealthIdentificationDto>
    {
        public HealthIdValidator()
        {
            RuleFor(healthId => healthId.Healthcard).SetValidator(new HealthcardValidator());
        }
    }
}
