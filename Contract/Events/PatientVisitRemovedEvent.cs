using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Contract.Events
{
    public class PatientVisitRemovedEvent : IDomainEvent
    {
        public PatientVisitRemovedEvent() { }
        public PatientVisitRemovedEvent(Guid patientId, Guid visitId)
        {
            PatientId = patientId;
            VisitId = visitId;
        }

        public Guid PatientId { get; set; }
        public Guid VisitId { get; set; }

    }
}
