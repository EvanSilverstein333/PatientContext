using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PatientVisit : IEntity<Guid>
    {
        internal PatientVisit() { }

        public PatientVisit(Guid id, DateTime? date, string notes, string diagnosis, Patient patient)
        {
            Id = id;
            Date = date;
            Diagnosis = diagnosis;
            Notes = notes;
            Patient = patient;
        }
        public Guid Id { get; private set; }
        public DateTime? Date { get; private set; }
        public string Notes { get; private set; }
        public string Diagnosis { get; private set; }
        public virtual Patient Patient { get; private set; }
        public byte[] RowVersion { get; private set; }

        public void EditMedicalInfo(DateTime date, string diagnosis, string notes, byte[] rowVersion)
        {
            Date = date;
            Diagnosis = diagnosis;
            Notes = notes;
            RowVersion = rowVersion;
        }

    }
}
