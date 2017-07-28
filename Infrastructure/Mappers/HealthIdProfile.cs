using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PatientManager.Contract.Dto;
using Domain.Entities;

namespace Infrastructure.Mappers
{
    public class HealthIdProfile : Profile
    {
        public HealthIdProfile()
        {
            CreateMap<HealthIdentification, HealthIdentificationDto>();
            //CreateMap<PatientDto, Patient>();
        }
    }
}
