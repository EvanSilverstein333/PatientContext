using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientManager.Contract.Dto;

namespace PatientManager.Contract.Queries
{
    public class FindPatientsBySearchTextQuery : IQuery<PatientDto[]>
    {
        public FindPatientsBySearchTextQuery() { }
        public FindPatientsBySearchTextQuery(string searchText)
        {
            SearchText = searchText;
        }
        public string SearchText { get; set; }
    }
}
