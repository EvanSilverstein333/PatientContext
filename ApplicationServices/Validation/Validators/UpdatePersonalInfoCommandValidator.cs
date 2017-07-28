using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using PatientManager.Contract.Commands;

namespace ApplicationServices.Validation.Validators
{
    public class UpdatePersonalInfoCommandValidator : AbstractValidator<UpdateHealthIdCommand>
    {
        public UpdatePersonalInfoCommandValidator()
        {
            RuleFor(cmd => cmd.HealthId).SetValidator(new HealthIdValidator());
        }
    }
}
