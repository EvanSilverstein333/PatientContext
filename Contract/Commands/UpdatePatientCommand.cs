using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObjects.Health;
using PatientManager.Contract.Dto;

namespace PatientManager.Contract.Commands
{
    public class UpdatePatientCommand : MessageNotifyOnCompletion, ICommand
    {
        UpdatePatientCommand() { }
        public UpdatePatientCommand(PatientDto patient)
        {
            Patient = patient;
            //ContactInfo = contactInfo;
            //HealthId = healthId;
        }

        public PatientDto Patient { get; set; }
        //public ContactInfoDto ContactInfo { get; set; }
        //public HealthIdentificationDto HealthId { get; set; }


    }
}
