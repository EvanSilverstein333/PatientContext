using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientManager.Contract.Dto;

namespace PatientManager.Contract.Commands
{
    public class UpdateHealthIdCommand : MessageNotifyOnCompletion, ICommand
    {
        public UpdateHealthIdCommand() { }
        public UpdateHealthIdCommand(Guid patientId, HealthIdentificationDto healthId)
        {
            PatientId = patientId;
            HealthId = healthId;
        }

        public Guid PatientId { get; set; }
        public HealthIdentificationDto HealthId { get; set; }
    }
}
