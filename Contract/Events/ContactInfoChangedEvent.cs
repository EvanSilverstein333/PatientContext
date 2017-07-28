using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Contract.Events
{
    public class ContactInfoChangedEvent : IDomainEvent
    {
        public ContactInfoChangedEvent() { }
        public ContactInfoChangedEvent(Guid contactInfoId)
        {
            ContactInfoId = contactInfoId;
        }
        public Guid ContactInfoId { get; set; }

    }
}
