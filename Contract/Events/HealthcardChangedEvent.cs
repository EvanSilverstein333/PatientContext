using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Contract.Events
{
    public class HealthcardChangedEvent : IDomainEvent
    {
        public HealthcardChangedEvent() { }
        public HealthcardChangedEvent(Guid healthcardId)
        {
            HealthcardId = healthcardId;
        }
        public Guid HealthcardId { get; set; }

    }
}
