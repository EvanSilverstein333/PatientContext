using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ValueObjects
{
    public class ActionResult
    {
        public ActionResult()
        {
            //ActionSucceeded = actionSucceeded;
        }
        public bool ActionSucceeded { get; set; }
    }
}
