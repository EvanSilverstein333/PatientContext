using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Shared.ValueObjects
{
    public class HealthNumber : ValueObject<HealthNumber>
    {
        public HealthNumber(string number)
        {
            if (!IsNumberValid(number)) { throw new Exception("A valid healthcard number contains 10 digits"); }
            Number = number;
        }

        public string Number { get; private set; }

        public override string ToString()
        {
            return Number;
        }

        private bool IsNumberValid(string number)
        {
            var healthcardNumberPattern = @"^(\+[0-9]{10})$"; // may need to be refined
            var valid = Regex.Match(number, healthcardNumberPattern).Success;
            return valid;
        }
    }
}
