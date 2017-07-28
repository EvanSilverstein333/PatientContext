using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using PatientManager.Contract.Dto;

namespace Infrastructure.Mappers
{
    public class ContactInfoProfile : Profile
    {
        public ContactInfoProfile()
        {
            CreateMap<ContactInfo, ContactInfoDto>();
            //CreateMap<PatientDto, Patient>();
        }
    }
}
