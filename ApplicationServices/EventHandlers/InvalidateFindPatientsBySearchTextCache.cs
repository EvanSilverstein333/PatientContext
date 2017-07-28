using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using PatientManager.Contract.Events;
using PatientManager.Contract.Queries;
using Persistance.UnitOfWork;

namespace ApplicationServices.EventHandlers
{
    public class InvalidateFindPatientsBySearchTextCache //: IDomainEventHandler<PatientIdentityChangedEvent>
    {
        private ObjectCache _cache;

        public InvalidateFindPatientsBySearchTextCache(ObjectCache cache)
        {
            _cache = cache;
        }

        public void Handle(PatientIdentityChangedEvent e)
        {
            //var queryType = typeof(FindPatientsBySearchTextQuery);
            //var keys = queryType.Name + e.Patient.;
            //_cache.Remove(key);
        }
    }
}
