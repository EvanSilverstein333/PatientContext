using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObjects.Health;
using PatientManager.Contract.Dto;
using System.Net.Mail;


namespace PatientManager.Contract.Commands
{
    public class AddPatientCommand : MessageNotifyOnCompletion, ICommand
    {
        public AddPatientCommand() { }
        public AddPatientCommand(PatientDto patient, ContactInfoDto contactInfo, HealthIdentificationDto healthId)
        {
            Patient = patient;
            ContactInfo = contactInfo;
            HealthId = healthId;

        }
        public PatientDto Patient { get; set; }
        public ContactInfoDto ContactInfo { get; set; }
        public HealthIdentificationDto HealthId { get; set; }
        
    }
}
