using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientManager.Contract.Events;
using System.Runtime.Caching;
using PatientManager.Contract.Queries;

namespace ApplicationServices.EventHandlers
{
    public class InvalidateGetPatientVisitsByPatientIdCache : IDomainEventHandler<PatientVisitedEvent>, IDomainEventHandler<PatientVisitChangedEvent>, IDomainEventHandler<PatientVisitRemovedEvent>
    {
        private ObjectCache _cache;

        public InvalidateGetPatientVisitsByPatientIdCache(ObjectCache cache)
        {
            _cache = cache;
        }

        public void Handle(PatientVisitRemovedEvent e)
        {
            InvalidateCache(e.PatientId);
        }

        public void Handle(PatientVisitChangedEvent e)
        {
            InvalidateCache(e.PatientId);
        }

        public void Handle(PatientVisitedEvent e)
        {
            InvalidateCache(e.PatientId);
        }

        private void InvalidateCache(Guid patientId)
        {
            var queryType = typeof(GetPatientVisitsByPatientQuery);
            var key = queryType.Name + patientId;
            if (_cache.Contains(key)) { _cache.Remove(key); }

        }
    }
}
