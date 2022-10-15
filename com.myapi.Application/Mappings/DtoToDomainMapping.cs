using AutoMapper;
using com.myapi.Application.DTO;
using com.myapi.Domain.Entities;

namespace com.myapi.Application.Mappings;

public class DtoToDomainMapping : Profile
{
    public DtoToDomainMapping()
    {
        CreateMap<PessoaDTO, Pessoa>();
        CreateMap<ProdutoDTO, Produto>();
        CreateMap<CompraDTO, Compra>();
    }
}