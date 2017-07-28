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
    public class InvalidateGetContactInfoByPatientIdCache : IDomainEventHandler<ContactInfoChangedEvent>, IDomainEventHandler<PatientRemovedEvent>

    {
        private ObjectCache _cache;

        public InvalidateGetContactInfoByPatientIdCache(ObjectCache cache)
        {
            _cache = cache;
        }


        public void Handle(ContactInfoChangedEvent e)
        {
            InvalidateCache(e.ContactInfoId);
        }

        public void Handle(PatientRemovedEvent e)
        {
            InvalidateCache(e.PatientId);
        }

        private void InvalidateCache(Guid contactInfoId)
        {
            var queryType = typeof(GetContactInfoByPatientQuery);
            var key = queryType.Name + contactInfoId;
            if (_cache.Contains(key)) { _cache.Remove(key); }


        }
    }
}
