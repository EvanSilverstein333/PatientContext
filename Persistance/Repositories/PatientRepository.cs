using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using System.Data.Entity;

namespace Persistance.Repositories
{
    public class PatientRepository: Repository<Patient,Guid>
    {
        public PatientRepository(DbContext context) : base(context)
        {
        }

        public Patient GetWithDetails(Guid id)
        {
            return _context.Set<Patient>()
                .Include(pt => pt.ContactInfo)
                .Include(pt => pt.Identification)
                .Where(pt => pt.Id == id)
                .FirstOrDefault();
        }
        
    }
}
