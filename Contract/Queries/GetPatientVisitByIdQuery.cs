using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientManager.Contract.Dto;


namespace PatientManager.Contract.Queries
{
    public class GetPatientVisitByIdQuery : IQuery<PatientVisitDto>
    {
        public GetPatientVisitByIdQuery() { }
        public GetPatientVisitByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
