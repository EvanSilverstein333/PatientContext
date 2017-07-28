using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using PatientManager.Contract.Commands;

namespace ApplicationServices.Validation.Validators
{
    public class AddPatientCommandValidator : AbstractValidator<AddPatientCommand>
    {
        public AddPatientCommandValidator()
        {
            RuleFor(cmd => cmd.Patient).SetValidator(new PatientValidator());
            RuleFor(cmd => cmd.HealthId).SetValidator(new HealthIdValidator());

            //AddRule(new CompositeValidatorRule(new AddPatientCommandValidator()));
        }

    }
}
