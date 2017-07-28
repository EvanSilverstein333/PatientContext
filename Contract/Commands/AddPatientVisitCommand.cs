using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientManager.Contract.Dto;

namespace PatientManager.Contract.Commands
{
    public class AddPatientVisitCommand : MessageNotifyOnCompletion, ICommand
    {
        public AddPatientVisitCommand() { }
        public AddPatientVisitCommand(PatientVisitDto visit, Guid patientId)
        {
            Visit = visit;
            PatientId = patientId;
        }

        public PatientVisitDto Visit { get; set; }
        public Guid PatientId { get; set; }
    }
}
