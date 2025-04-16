using AutoMapper;
using Domain.DTOs;
using Domain.Models;

namespace Memoteca.Mapping 
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PensamentoDto, PensamentoModel>();
        }
    }
}
