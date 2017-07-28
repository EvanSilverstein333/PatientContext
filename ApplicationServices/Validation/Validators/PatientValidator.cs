using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationServices.Validation;
using ValueObjects.Health;
using PatientManager.Contract.Dto;
using FluentValidation;
using FluentValidation.Results;

namespace ApplicationServices.Validation.Validators
{
    public class PatientValidator : AbstractValidator<PatientDto>
    {
        public PatientValidator()
        {
            RuleFor(pt => pt.FirstName).NotEmpty().WithMessage("First name is required");
            RuleFor(pt => pt.LastName).NotEmpty().WithMessage("Last name is required");
            RuleFor(pt => pt.DateOfBirth).NotEmpty().WithMessage("Date of birth is required");
            RuleFor(pt => pt.Gender).NotEqual(GenderType.None).WithMessage("Gender is required");

        }
        //public IEnumerable<ValidationResult> Validate(AddPatientCommand command)
        //{
        //    var patient = command.Patient;
        //    var contactInfo = command.ContactInfo;
        //    var healthId = command.HealthId;
        //    var validationErrors = new List<ValidationResult>();

        //    //patient inputs
        //    if (string.IsNullOrWhiteSpace(patient.FirstName)) { validationErrors.Add(new ValidationResult(()=>patient.FirstName, "First name is invalid")); }
        //    if (string.IsNullOrWhiteSpace(patient.LastName)) { validationErrors.Add(new ValidationResult(() => patient.LastName, "Last name is invalid")); }
        //    if (patient.DateOfBirth==null) { validationErrors.Add(new ValidationResult(() => patient.DateOfBirth, "Date of birth is required")); }
        //    if(patient.Gender == GenderType.None) { validationErrors.Add(new ValidationResult(() => patient.Gender, "Gender is required")); }

        //    return validationErrors;


        //}
    }
}
