using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Shared.ValueObjects
{
    public class VersionCode
    {
        public VersionCode(string code)
        {
            if (!IsVersionValid(code)) { throw new Exception("A valid version code contains 0-2 letters as indicated on the healthcard"); }
            Code = code;

        }

        public string Code { get; private set; }

        public override string ToString()
        {
            return Code;
        }

        private bool IsVersionValid(string version)
        {
            var healthcardVersionPattern = @"^[a-zA-Z]{0,2}$"; // may need to be refined
            var valid = Regex.Match(version, healthcardVersionPattern).Success;
            return valid;

        }



    }
}
