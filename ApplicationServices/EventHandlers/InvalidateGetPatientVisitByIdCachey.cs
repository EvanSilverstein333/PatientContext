using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using PatientManager.Contract.Events;
using PatientManager.Contract.Queries;
using PatientManager.Contract.Commands;

namespace ApplicationServices.EventHandlers
{
    public class InvalidateGetPatientVisitByIdCache : IDomainEventHandler<PatientVisitChangedEvent>, IDomainEventHandler<PatientVisitRemovedEvent>
    {
        private ObjectCache _cache;

        public InvalidateGetPatientVisitByIdCache(ObjectCache cache)
        {
            _cache = cache;
        }


        public void Handle(PatientVisitChangedEvent e)
        {
            InvalidateCache(e.VisitId);
        }

        public void Handle(PatientVisitRemovedEvent e)
        {
            InvalidateCache(e.VisitId);

        }

        private void InvalidateCache(Guid visitId)
        {
            var queryType = typeof(GetPatientVisitByIdQuery);
            var key = queryType.Name + visitId;
            if (_cache.Contains(key)) { _cache.Remove(key); }


        }
    }
}
