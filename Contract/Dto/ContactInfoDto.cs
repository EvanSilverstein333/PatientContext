using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObjects.ContactInformation;
using System.Net.Mail;
using System.ComponentModel;

namespace PatientManager.Contract.Dto
{
    public class ContactInfoDto
    {
        [Browsable(false)]
        public Guid Id { get; set; }
        public Address Address { get; set; }
        public PhoneNumber PrimaryPhoneNumber { get; set; }
        public PhoneNumber SecondaryPhoneNumber { get; set; }
        public string Email { get; set; }

        [Browsable(false)]
        public byte[] RowVersion { get; set; }
    }
}
