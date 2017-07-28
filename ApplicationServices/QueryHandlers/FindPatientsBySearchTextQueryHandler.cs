using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistance.UnitOfWork;
using Domain.Entities;
using AutoMapper;
using PatientManager.Contract.Queries;
using PatientManager.Contract.Dto;

namespace ApplicationServices.QueryHandlers
{
    public class FindPatientsBySearchTextQueryHandler : IQueryHandler<FindPatientsBySearchTextQuery, PatientDto[]>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public FindPatientsBySearchTextQueryHandler(IUnitOfWork unitOfWork, MapperConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _mapper = config.CreateMapper();
        }

        public PatientDto[] Handle(FindPatientsBySearchTextQuery query)
        {
            var patients = _unitOfWork.Patients.Find((pt) => (pt.FirstName + " " + pt.LastName).ToLower().Contains(query.SearchText));
            var patientDtos = _mapper.Map<IEnumerable<Patient>, IEnumerable<PatientDto>>(patients);
            return patientDtos.ToArray();

        }
    }
}
