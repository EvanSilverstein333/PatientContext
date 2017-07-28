using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Contract.Events
{
    public class PatientRemovedEvent : IDomainEvent
    {
        public PatientRemovedEvent() { }
        public PatientRemovedEvent(Guid patientId)
        {
            PatientId = patientId;
        }
        public Guid PatientId { get; set; }
    }
}
