using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using PatientManager.Contract.Queries;
using PatientManager.Contract.Events;
using PatientManager.Contract.Commands;

namespace ApplicationServices.EventHandlers
{
    public class InvalidateGetAllPatientsCache : IDomainEventHandler<PatientIdentityChangedEvent>, IDomainEventHandler<NewPatientRegisteredEvent>, IDomainEventHandler<PatientRemovedEvent>
    {

        private ObjectCache _cache;

        public InvalidateGetAllPatientsCache(ObjectCache cache)
        {
            _cache = cache;
        }


        public void Handle(PatientRemovedEvent e)
        {
            InvalidateCache();
        }

        public void Handle(NewPatientRegisteredEvent e)
        {
            InvalidateCache();
        }

        public void Handle(PatientIdentityChangedEvent e)
        {
            InvalidateCache();
        }

        private void InvalidateCache()
        {
            var queryType = typeof(GetAllPatientsQuery);
            var key = queryType.Name;
            if (_cache.Contains(key)) { _cache.Remove(key); }

        }
    }
}
