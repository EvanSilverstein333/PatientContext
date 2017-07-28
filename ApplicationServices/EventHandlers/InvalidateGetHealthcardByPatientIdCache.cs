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
    public class InvalidateGetHealthcardByPatientIdCache : IDomainEventHandler<HealthcardChangedEvent>, IDomainEventHandler<PatientRemovedEvent>
    {
        private ObjectCache _cache;

        public InvalidateGetHealthcardByPatientIdCache(ObjectCache cache)
        {
            _cache = cache;
        }



        public void Handle(HealthcardChangedEvent e)
        {
            InvalidateCache(e.HealthcardId);
        }

        public void Handle(PatientRemovedEvent e)
        {
            InvalidateCache(e.PatientId);
        }

        public void InvalidateCache(Guid healthcardId)
        {
            var queryType = typeof(GetHealthIdByPatientQuery);
            var key = queryType.Name + healthcardId;
            if (_cache.Contains(key)) { _cache.Remove(key); }
        }
    }
}
