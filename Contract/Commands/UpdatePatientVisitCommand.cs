using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientManager.Contract.Dto;

namespace PatientManager.Contract.Commands
{
    public class UpdatePatientVisitCommand : MessageNotifyOnCompletion, ICommand
    {
        UpdatePatientVisitCommand() { }
        public UpdatePatientVisitCommand(PatientVisitDto visit)
        {
            Visit = visit;
        }

        public PatientVisitDto Visit { get; set; }
    }
}
