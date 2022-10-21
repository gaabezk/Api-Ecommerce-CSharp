using AutoMapper;
using com.myapi.Application.DTO;
using com.myapi.Application.DTO.Validations;
using com.myapi.Application.Services.Interfaces;
using com.myapi.Domain.Entities;
using com.myapi.Domain.Repositories;
using com.myapi.Infra.Data.Repositories;

namespace com.myapi.Application.Services;

public class CompraService : ICompraService
{
    private readonly ICompraRepository _compraRepository;
    private readonly IMapper _mapper;
    private readonly IPessoaRepository _pessoaRepository;
    private readonly IProdutoRepository _produtoRepository;
    private readonly IUnityOfWork _unityOfWork;


    public CompraService(IProdutoRepository produtoRepository, IPessoaRepository pessoaRepository,
        ICompraRepository compraRepository, IMapper mapper,IUnityOfWork unityOfWork)
    {
        _produtoRepository = produtoRepository;
        _pessoaRepository = pessoaRepository;
        _compraRepository = compraRepository;
        _mapper = mapper;
        _unityOfWork = unityOfWork;
    }

    public async Task<ResultService<CompraDTO>> CreateAsync(CompraDTO compraDto)
    {
        if (compraDto == null)
            return ResultService.Fail<CompraDTO>("Objeto deve ser informado!");

        var validate = new ComprasDTOValidator().Validate(compraDto);
        if (!validate.IsValid)
            return ResultService.RequestError<CompraDTO>("Problemas de validação", validate);

        try
        {
            await _unityOfWork.BeginTransaction();
            var produtoId = await _produtoRepository.GetIdByCodigoErpAsync(compraDto.CodigoErp);
            if (produtoId == 0)
            {
                var produto = new Produto(compraDto.Nome, compraDto.CodigoErp, compraDto.QuantidadeEstoque ?? 0, compraDto.Preco ?? 0);
                await _produtoRepository.CreateAsync(produto);
                produtoId = produto.Id;
            }
            var pessoaId = await _pessoaRepository.GetIdByCpfAsync(compraDto.Cpf);
            var compra = new Compra(produtoId, pessoaId);

            var data = await _compraRepository.CreateAsync(compra);
            compraDto.Id = data.Id;
            await _unityOfWork.Commit();
            return ResultService.Ok(compraDto);
        }
        catch(Exception e)
        {
            await _unityOfWork.Rollback();
            return ResultService.Fail<CompraDTO>($"{e.Message}");
        }
        
        
    }

    public async Task<ResultService<ICollection<CompraDetalheDTO>>> GetAllAsync()
    {
        var compras = await _compraRepository.GetAllAsync();
        return ResultService.Ok(_mapper.Map<ICollection<CompraDetalheDTO>>(compras));
    }

    public async Task<ResultService<CompraDetalheDTO>> GetById(int id)
    {
        var compra = await _compraRepository.GetByIdAsync(id);
        if (compra == null)
            return ResultService.Fail<CompraDetalheDTO>("Compra não encontrada!");
        return ResultService.Ok(_mapper.Map<CompraDetalheDTO>(compra));
    }

    public async Task<ResultService<CompraDTO>> UpdateAsync(CompraDTO comprasDto)
    {
        if (comprasDto == null)
            return ResultService.Fail<CompraDTO>("Obejeto deve ser informado");

        var validation = new ComprasDTOValidator().Validate(comprasDto);
        if (!validation.IsValid)
            return ResultService.RequestError<CompraDTO>("Problema com validação dos campos", validation);

        var compras = await _compraRepository.GetByIdAsync(comprasDto.Id);
        if (compras == null)
            return ResultService.Fail<CompraDTO>("Compra não encontrada!");

        var produtoId = await _produtoRepository.GetIdByCodigoErpAsync(comprasDto.CodigoErp);
        var pessoaId = await _pessoaRepository.GetIdByCpfAsync(comprasDto.Cpf);
        compras.Edit(compras.Id, produtoId, pessoaId);
        await _compraRepository.EditAsync(compras);
        return ResultService.Ok(comprasDto);
    }

    public async Task<ResultService> RemoveAsync(int id)
    {
        var compra = await _compraRepository.GetByIdAsync(id);
        if (compra == null)
            return ResultService.Fail("Compra não encontrada");
        await _compraRepository.DeleteAsync(compra);
        return ResultService.Ok($"Compra do id {compra.Id} deletada com sucesso!");
    }
}