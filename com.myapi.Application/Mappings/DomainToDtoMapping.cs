using AutoMapper;
using com.myapi.Application.DTO;
using com.myapi.Domain.Entities;

namespace com.myapi.Application.Mappings;

public class DomainToDtoMapping : Profile
{
    public DomainToDtoMapping()
    {
        CreateMap<Pessoa, PessoaDTO>();
    }
}