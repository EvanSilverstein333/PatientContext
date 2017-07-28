using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Contract.Events
{
    public class PatientVisitedEvent : IDomainEvent
    {
        public PatientVisitedEvent() { }
        public PatientVisitedEvent(Guid patientId, Guid visitId)
        {
            PatientId = patientId;
            VisitId = visitId;
        }

        public Guid VisitId { get; set; }
        public Guid PatientId { get; set; }
    }
}
