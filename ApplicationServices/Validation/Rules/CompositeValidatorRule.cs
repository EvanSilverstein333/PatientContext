using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Attributes;
using FluentValidation.Results;
using FluentValidation.Validators;

namespace ApplicationServices.Validation.Rules
{
    public class CompositeValidatorRule : IValidationRule
    {
        private IValidator[] _validators;

        public CompositeValidatorRule(params IValidator[] validators)
        {
            _validators = validators;
        }

        #region IValidationRule Members
        public string RuleSet
        {
            get; set;
        }

        public IEnumerable<ValidationFailure> Validate(ValidationContext context)
        {
            var errors = new List<ValidationFailure>();
            foreach (var v in _validators)
            {
                errors.AddRange(v.Validate(context).Errors);
            }

            return errors;
        }

        public Task<IEnumerable<ValidationFailure>> ValidateAsync(ValidationContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public void ApplyCondition(Func<object, bool> predicate, ApplyConditionTo applyConditionTo = ApplyConditionTo.AllValidators)
        {
            throw new NotImplementedException();
        }

        public void ApplyAsyncCondition(Func<object, Task<bool>> predicate, ApplyConditionTo applyConditionTo = ApplyConditionTo.AllValidators)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPropertyValidator> Validators
        {
            get { yield break; }
        }
        #endregion
    }
}
