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
    public class GetAllPatientsQueryHandler : IQueryHandler<GetAllPatientsQuery, PatientDto[]>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public GetAllPatientsQueryHandler(IUnitOfWork unitOfWork, MapperConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _mapper = config.CreateMapper();
        }

        public PatientDto[] Handle(GetAllPatientsQuery query)
        {
            var patients = _unitOfWork.Patients.GetAll();
            var patientDtos = _mapper.Map<IEnumerable<Patient>, IEnumerable<PatientDto>>(patients);
            return patientDtos.ToArray();

        }
    }
}
