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
    public class GetContactInfoByPatientQueryHandler : IQueryHandler<GetContactInfoByPatientQuery, ContactInfoDto>
    {

        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public GetContactInfoByPatientQueryHandler(IUnitOfWork unitOfWork, MapperConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _mapper = config.CreateMapper();
        }
        public ContactInfoDto Handle(GetContactInfoByPatientQuery query)
        {
            var contactInfo = _unitOfWork.ContactInformation.GetByPatientId(query.PatientId);
            var contactInfoDto = _mapper.Map<ContactInfo, ContactInfoDto>(contactInfo);
            return contactInfoDto;
        }
    }
}
