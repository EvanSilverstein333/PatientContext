using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.Entities;

namespace Persistance.Repositories
{
    public class PatientVisitRepository: Repository<PatientVisit,Guid>
    {
        public PatientVisitRepository(DbContext context): base(context)
        {
        }

        public virtual PatientVisit GetWithPatient(Guid id)
        {
            return _context.Set<PatientVisit>()
               .Include(visit => visit.Patient)
               .Where(visit => visit.Id == id)
               .FirstOrDefault();
        }

        //public IEnumerable<PatientVisit> GetByPatientId(int patientId)
        //{
        //    return _context.Set<PatientVisit>().AsNoTracking().Where(x => x.Patient.Id == patientId).ToList();
        //}


    }
}
