using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistance.UnitOfWork;
using AutoMapper;
using Domain.Entities;
using PatientManager.Contract.Queries;
using PatientManager.Contract.Dto;

namespace ApplicationServices.QueryHandlers
{
    public class GetHealthIdByPatientQueryHandler : IQueryHandler<GetHealthIdByPatientQuery, HealthIdentificationDto>
    {

        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public GetHealthIdByPatientQueryHandler(IUnitOfWork unitOfWork, MapperConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _mapper = config.CreateMapper();
        }

        public HealthIdentificationDto Handle(GetHealthIdByPatientQuery query)
        {
            var healthId = _unitOfWork.HealthIdentification.GetByPatientId(query.PatientId);
            var healthIdDto = _mapper.Map<HealthIdentification, HealthIdentificationDto>(healthId);
            return healthIdDto;

        }
    }
}
