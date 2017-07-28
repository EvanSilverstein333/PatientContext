using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObjects.ContactInformation;
using System.Net.Mail;

namespace Domain.Entities
{
    public class ContactInfo : IEntity<Guid>
    {

        internal ContactInfo() { } // required for entityFramework
        public ContactInfo(Guid id, Address address, PhoneNumber primaryNumber, PhoneNumber secondaryNumber, string email)
        {
            //SetAddressProps(address);
            Id = id;
            Address = address;
            PrimaryPhoneNumber = primaryNumber;
            SecondaryPhoneNumber = secondaryNumber;
            Email = email;
        }

        public Guid Id { get; private set; }
        public Address Address { get; private set; }
        public PhoneNumber PrimaryPhoneNumber { get; private set; }
        public PhoneNumber SecondaryPhoneNumber { get; private set; }

        public string Email { get; private set; }

        public virtual Patient Patient { get; private set; }
        public byte[] RowVersion { get; private set; }

        public void ChangeInfo(Address address, PhoneNumber primaryPhoneNumber, PhoneNumber secondaryPhoneNumber, string email, byte[] rowVersion)
        {
            Address = address;
            PrimaryPhoneNumber = primaryPhoneNumber;
            SecondaryPhoneNumber = secondaryPhoneNumber;
            Email = email;
            RowVersion = rowVersion;
        }



    }
}
