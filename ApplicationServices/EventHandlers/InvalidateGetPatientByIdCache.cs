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
    public class InvalidateGetPatientByIdCache : IDomainEventHandler<PatientIdentityChangedEvent>, IDomainEventHandler<PatientRemovedEvent>
    {
        private ObjectCache _cache;

        public InvalidateGetPatientByIdCache(ObjectCache cache)
        {
            _cache = cache;
        }


        public void Handle(PatientRemovedEvent e)
        {
            InvalidateCache(e.PatientId);

        }

        public void Handle(PatientIdentityChangedEvent e)
        {
            InvalidateCache(e.PatientId);
        }

        private void InvalidateCache(Guid patientId)
        {
            var queryType = typeof(GetPatientByIdQuery);
            var key = queryType.Name + patientId;
            if (_cache.Contains(key)) { _cache.Remove(key); }


        }
    }
}
