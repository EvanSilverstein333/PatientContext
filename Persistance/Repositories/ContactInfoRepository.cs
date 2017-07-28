using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using System.Data.Entity;

namespace Persistance.Repositories
{
    public class ContactInfoRepository : Repository<ContactInfo, Guid>//, ISearchableByPatientId<ContactInfo>
    {
        
        public ContactInfoRepository(DbContext context) : base(context)
        {

        }

        public ContactInfo GetByPatientId(Guid patientId)
        {
            return _context.Set<ContactInfo>().Where(x => x.Patient.Id == patientId).SingleOrDefault();
        }

    }
}
