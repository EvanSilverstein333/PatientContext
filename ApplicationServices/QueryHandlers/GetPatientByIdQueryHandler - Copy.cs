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
    public class GetPatientVisitByIdQueryHandler : IQueryHandler<GetPatientVisitByIdQuery, PatientVisitDto>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public GetPatientVisitByIdQueryHandler(IUnitOfWork unitOfWork, MapperConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _mapper = config.CreateMapper();
        }

        public PatientVisitDto Handle(GetPatientVisitByIdQuery query)
        {
            var visit = _unitOfWork.PatientVisits.Get(query.Id);
            var visitDto = _mapper.Map<PatientVisit, PatientVisitDto>(visit);
            return visitDto;

        }
    }
}
