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
    public class GetPatientVisitsByPatientQueryHandler : IQueryHandler<GetPatientVisitsByPatientQuery, PatientVisitDto[]>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public GetPatientVisitsByPatientQueryHandler(IUnitOfWork unitOfWork, MapperConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _mapper = config.CreateMapper();
        }

        public PatientVisitDto[] Handle(GetPatientVisitsByPatientQuery query)
        {
            var patientVisits = _unitOfWork.PatientVisits.Find((visit) => visit.Patient.Id == query.PatientId);
            var patientVisitDtos = _mapper.Map<IEnumerable<PatientVisit>, IEnumerable<PatientVisitDto>>(patientVisits);
            return patientVisitDtos.ToArray();
        }
    }
}
