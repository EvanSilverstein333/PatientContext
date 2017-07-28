using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PatientManager.Contract.Dto
{
    public class PatientVisitDto
    {

        public PatientVisitDto() { }
        public PatientVisitDto(Guid id)
        {
            Id = id;
        }

        [Browsable(false)]
        public Guid Id { get; set; }
        public DateTime? Date { get; set; }
        public string Diagnosis { get; set; }
        public string Notes { get; set; }

        [Browsable(false)]
        public byte[] RowVersion { get; set; }


    }
}
