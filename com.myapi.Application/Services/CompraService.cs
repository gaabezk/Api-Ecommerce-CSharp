using com.myapi.Application.DTO;
using com.myapi.Application.DTO.Validations;
using com.myapi.Application.Services.Interfaces;
using com.myapi.Domain.Entities;
using com.myapi.Domain.Repositories;
using com.myapi.Infra.Data.Repositories;

namespace com.myapi.Application.Services;

public class CompraService : ICompraService
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IPessoaRepository _pessoaRepository;
    private readonly ICompraRepository _compraRepository;

    public CompraService(IProdutoRepository produtoRepository, IPessoaRepository pessoaRepository, ICompraRepository compraRepository)
    {
        _produtoRepository = produtoRepository;
        _pessoaRepository = pessoaRepository;
        _compraRepository = compraRepository;
    }

    public async Task<ResultService<CompraDTO>> CreateAsync(CompraDTO compraDto)
    {
        if (compraDto == null)
            return ResultService.Fail<CompraDTO>("Objeto deve ser informado!");

        var validate = new ComprasDTOValidator().Validate(compraDto);
        if(!validate.IsValid)
            return ResultService.RequestError<CompraDTO>("Problemas de validação",validate);

        var produtoId = await _produtoRepository.GetIdByCodigoErpAsync(compraDto.CodigoErp);
        var pessoaId = await _pessoaRepository.GetIdByCpfAsync(compraDto.Cpf);
        var compra = new Compra(produtoId, pessoaId);

        var data = await _compraRepository.CreateAsync(compra);
        compraDto.Id = data.Id;
        return ResultService.Ok<CompraDTO>(compraDto);


    }

    public Task<ResultService<ICollection<CompraDTO>>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ResultService<CompraDTO>> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ResultService> UpdateAsync(CompraDTO comprasDto)
    {
        throw new NotImplementedException();
    }

    public Task<ResultService> RemoveAsync(int id)
    {
        throw new NotImplementedException();
    }
}