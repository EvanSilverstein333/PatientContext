using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Contract.Commands
{
    public class DeletePatientCommand : MessageNotifyOnCompletion, ICommand
    {
        public DeletePatientCommand() { }
        public DeletePatientCommand(Guid patientId)
        {
            PatientId = patientId;
        }

        public Guid PatientId { get; set; }
    }
}
