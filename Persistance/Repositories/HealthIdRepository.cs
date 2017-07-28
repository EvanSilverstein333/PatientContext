using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using System.Data.Entity;

namespace Persistance.Repositories
{
    public class HealthIdRepository : Repository<HealthIdentification,Guid>//, ISearchableByPatientId<Identification>
    {
        public HealthIdRepository(DbContext context) : base(context)
        {
        }

        public HealthIdentification GetByPatientId(Guid patientId)
        {
            return _context.Set<HealthIdentification>().Where(x => x.Patient.Id == patientId).SingleOrDefault();
        }
    }
}
