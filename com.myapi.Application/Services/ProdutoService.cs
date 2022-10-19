using AutoMapper;
using com.myapi.Application.DTO;
using com.myapi.Application.DTO.Validations;
using com.myapi.Application.Services.Interfaces;
using com.myapi.Domain.Entities;
using com.myapi.Domain.Repositories;

namespace com.myapi.Application.Services;

public class ProdutoService : IProdutoService
{
    private readonly IMapper _mapper;
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
    {
        _produtoRepository = produtoRepository;
        _mapper = mapper;
    }

    public async Task<ResultService<ProdutoDTO>> CreateAsync(ProdutoDTO produtoDto)
    {
        if (produtoDto == null)
            return ResultService.Fail<ProdutoDTO>("Objeto deve ser informado");

        var result = new ProdutoDTOValidator().Validate(produtoDto);
        if (!result.IsValid)
            return ResultService.RequestError<ProdutoDTO>("Problemas de validade", result);

        var produto = _mapper.Map<Produto>(produtoDto);
        var data = await _produtoRepository.CreateAsync(produto);
        return ResultService.Ok(_mapper.Map<ProdutoDTO>(data));
    }

    public async Task<ResultService<ICollection<ProdutoDTO>>> GetAllAsync()
    {
        var produtos = await _produtoRepository.GetAllAsync();
        return ResultService.Ok(_mapper.Map<ICollection<ProdutoDTO>>(produtos));
    }

    public async Task<ResultService<ProdutoDTO>> GetById(int id)
    {
        var produto = await _produtoRepository.GetByIdAsync(id);
        if (produto == null)
            return ResultService.Fail<ProdutoDTO>("Produto nao encontrado");
        return ResultService.Ok(_mapper.Map<ProdutoDTO>(produto));
    }

    public async Task<ResultService> UpdateAsync(ProdutoDTO produtoDto)
    {
        if (produtoDto == null)
            return ResultService.Fail("Objeto deve ser informado");

        var validation = new ProdutoDTOValidator().Validate(produtoDto);
        if (!validation.IsValid)
            return ResultService.RequestError("Problema com a validação dos campos", validation);

        var produto = await _produtoRepository.GetByIdAsync(produtoDto.Id);
        if (produto == null)
            return ResultService.Fail("Produto não encontrado");

        produto = _mapper.Map(produtoDto, produto); // edição
        await _produtoRepository.EditAsync(produto);
        return ResultService.Ok("Produto editado");
    }

    public async Task<ResultService> RemoveAsync(int id)
    {
        var produto = await _produtoRepository.GetByIdAsync(id);
        if (produto == null)
            return ResultService.Fail<ProdutoDTO>("Produto nao encontrado");

        await _produtoRepository.DeleteAsync(produto);
        return ResultService.Ok($"O produto do id {id} foi deletado");
    }
}