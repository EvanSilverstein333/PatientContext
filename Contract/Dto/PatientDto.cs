using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObjects.Health;

namespace PatientManager.Contract.Dto
{
    public class PatientDto
    {
        public PatientDto() { }
        public PatientDto(Guid id)
        {
            Id = id;
        }

        [Browsable(false)]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public GenderType Gender { get; set; }
        [Browsable(false)]
        public byte[] RowVersion { get; set; }



    }
}
