using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientManager.Contract.Dto;

namespace PatientManager.Contract.Events
{
    public class PatientIdentityChangedEvent : IDomainEvent
    {
        public PatientIdentityChangedEvent() { }
        public PatientIdentityChangedEvent(Guid patientId)
        {
            PatientId = patientId;
        }

        public Guid PatientId { get; set; }
    }
}
