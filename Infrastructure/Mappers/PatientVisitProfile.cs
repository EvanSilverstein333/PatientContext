using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration.Conventions;
using AutoMapper.Mappers;
using Domain.Entities;
using PatientManager.Contract.Dto;

namespace Infrastructure.Mappers
{
    public class PatientVisitProfile:Profile
    {
        public PatientVisitProfile()
        {
            CreateMap<PatientVisit, PatientVisitDto>();
            CreateMap<PatientVisitDto, PatientVisit>();
        }
    }
}
