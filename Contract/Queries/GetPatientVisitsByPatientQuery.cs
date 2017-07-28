using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientManager.Contract.Dto;

namespace PatientManager.Contract.Queries
{
    public class GetPatientVisitsByPatientQuery : IQuery<PatientVisitDto[]>
    {

        public GetPatientVisitsByPatientQuery() { }
        public GetPatientVisitsByPatientQuery(Guid patientId)
        {
            PatientId = patientId;
        }

        public Guid PatientId { get; set; }

    }
}
