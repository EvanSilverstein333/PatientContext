using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientManager.Contract.Dto;


namespace PatientManager.Contract.Queries
{
    public class GetContactInfoByPatientQuery : IQuery<ContactInfoDto>
    {

        public GetContactInfoByPatientQuery() { }
        public GetContactInfoByPatientQuery(Guid patientId)
        {
            PatientId = patientId;
        }

        public Guid PatientId { get; set; }

    }
}
