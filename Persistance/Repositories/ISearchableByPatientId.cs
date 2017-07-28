using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Persistance.Repositories
{
    public interface ISearchableByPatientId<TReturn>
    {
        TReturn GetByPatientId(int patientId);
    }
}
