using PatientManager.Contract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Contract.Commands
{
    public class UpdateContactInformationCommand : MessageNotifyOnCompletion, ICommand
    {
        
        public UpdateContactInformationCommand() { }
        public UpdateContactInformationCommand(Guid patientId, ContactInfoDto contactInfo)
        {
            PatientId = patientId;
            ContactInfo = contactInfo;
        }

        public Guid PatientId { get; set; }
        public ContactInfoDto ContactInfo { get; set; }
    }
}

