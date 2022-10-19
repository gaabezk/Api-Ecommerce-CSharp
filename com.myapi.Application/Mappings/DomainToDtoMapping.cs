using AutoMapper;
using com.myapi.Application.DTO;
using com.myapi.Domain.Entities;

namespace com.myapi.Application.Mappings;

public class DomainToDtoMapping : Profile
{
    public DomainToDtoMapping()
    {
        CreateMap<Pessoa, PessoaDTO>();
        CreateMap<Produto, ProdutoDTO>();
        CreateMap<Compra, CompraDetalheDTO>()
            .ForMember(x => x.Pessoa, opt => opt.Ignore())
            .ForMember(x => x.Produto, opt => opt.Ignore())
            .ConstructUsing((model, context) =>
            {
                var dto = new CompraDetalheDTO
                {
                    Produto = model.Produto.Nome,
                    Id = model.Id,
                    Data = model.Date,
                    Pessoa = model.Pessoa.Nome
                };
                return dto;
            });
    }
}