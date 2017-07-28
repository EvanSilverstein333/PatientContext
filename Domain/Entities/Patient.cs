using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObjects.Health;
using ValueObjects.ContactInformation;
using System.Net.Mail;

namespace Domain.Entities
{
    public class Patient : IEntity<Guid>
    {

        private DateTime? _dateOfBirth;

        internal Patient() { }
        //public Patient(Guid id, string firstName, string lastName, DateTime? dateOfBrith, GenderType gender)
        //{
        //    Id = id;
        //    FirstName = firstName;
        //    LastName = lastName;
        //    DateOfBirth = dateOfBrith;
        //    Gender = gender;
        //}

        public Patient(Guid id)
        {
            Id = id;
        }


        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime? DateOfBirth
        {
            get { return (_dateOfBirth != null) ? ((DateTime)_dateOfBirth).Date : _dateOfBirth; }
            private set { _dateOfBirth = value; }
        }
        public GenderType Gender { get; private set; }
        public virtual ContactInfo ContactInfo { get; set; }
        public virtual HealthIdentification Identification { get; set; }
        public byte[] RowVersion { get; private set; }

        public void EditIdentity(string firstName, string lastName, DateTime? dateOfBirth, GenderType gender, byte[] rowVersion)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            RowVersion = rowVersion;
        }

    }
}
