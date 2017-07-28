using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Contract.Commands
{
    public class DeletePatientVisitCommand : MessageNotifyOnCompletion, ICommand
    {
        public DeletePatientVisitCommand() { }
        public DeletePatientVisitCommand(Guid visitId)
        {
            VisitId = visitId;
        }

        public Guid VisitId { get; set; }
    }
}
