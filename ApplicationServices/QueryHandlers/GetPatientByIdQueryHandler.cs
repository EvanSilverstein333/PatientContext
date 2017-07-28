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
    public class GetPatientByIdQueryHandler : IQueryHandler<GetPatientByIdQuery, PatientDto>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public GetPatientByIdQueryHandler(IUnitOfWork unitOfWork, MapperConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _mapper = config.CreateMapper();
        }

        public PatientDto Handle(GetPatientByIdQuery query)
        {
            var patient = _unitOfWork.Patients.Get(query.Id);
            var patientDto = _mapper.Map<Patient, PatientDto>(patient);
            return patientDto;

        }
    }
}
