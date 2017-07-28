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
    public class GetAllPatientVisitsQueryHandler : IQueryHandler<GetAllPatientVisitsQuery, PatientVisitDto[]>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public GetAllPatientVisitsQueryHandler(IUnitOfWork unitOfWork, MapperConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _mapper = config.CreateMapper();
        }

        public PatientVisitDto[] Handle(GetAllPatientVisitsQuery query)
        {
            var patientVisits = _unitOfWork.PatientVisits.GetAll();
            var patientVisitDtos = _mapper.Map<IEnumerable<PatientVisit>, IEnumerable<PatientVisitDto>>(patientVisits);
            return patientVisitDtos.ToArray();
        }
    }
}
