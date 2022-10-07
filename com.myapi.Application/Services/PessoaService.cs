using AutoMapper;
using com.myapi.Application.DTO;
using com.myapi.Application.DTO.Validations;
using com.myapi.Application.Services.Interfaces;
using com.myapi.Domain.Entities;
using com.myapi.Domain.Repositories;

namespace com.myapi.Application.Services;

public class PessoaService : IPessoaService
{
    private readonly IMapper _mapper;
    private readonly IPessoaRepository _pessoaRepository;

    public PessoaService(IPessoaRepository pessoaRepository, IMapper mapper)
    {
        _pessoaRepository = pessoaRepository;
        _mapper = mapper;
    }

    public async Task<ResultService<PessoaDTO>> CreateAsync(PessoaDTO pessoaDto)
    {
        if (pessoaDto == null)
            return ResultService.Fail<PessoaDTO>("Objeto deve ser informado");

        var result = new PessoaDTOValidator().Validate(pessoaDto);
        if (!result.IsValid)
            return ResultService.RequestError<PessoaDTO>("Problemas de validade!", result);

        var pessoa = _mapper.Map<Pessoa>(pessoaDto); // criação
        var data = await _pessoaRepository.CreateAsync(pessoa);
        return ResultService.Ok(_mapper.Map<PessoaDTO>(data));
    }

    public async Task<ResultService<ICollection<PessoaDTO>>> GetAllAsync()
    {
        var pessoas = await _pessoaRepository.GetAllAsync();
        return ResultService.Ok(_mapper.Map<ICollection<PessoaDTO>>(pessoas));
    }

    public async Task<ResultService<PessoaDTO>> GetById(int id)
    {
        var pessoa = await _pessoaRepository.GetByIdAsync(id);
        if (pessoa == null)
            return ResultService.Fail<PessoaDTO>("Usuario nao encontrado");
        return ResultService.Ok(_mapper.Map<PessoaDTO>(pessoa));
    }

    public async Task<ResultService> UpdateAsync(PessoaDTO pessoaDto)
    {
        if (pessoaDto == null)
            return ResultService.Fail("Objeto deve ser informado");

        var validation = new PessoaDTOValidator().Validate(pessoaDto);
        if (!validation.IsValid)
            return ResultService.RequestError("Problema com a validação dos campos", validation);

        var pessoa = await _pessoaRepository.GetByIdAsync(pessoaDto.Id);
        if (pessoa == null)
            return ResultService.Fail("Usuario não encontrado");


        pessoa = _mapper.Map(pessoaDto, pessoa); // edicao
        await _pessoaRepository.EditAsync(pessoa);
        return ResultService.Ok("Usuario editado;");
    }

    public async Task<ResultService> RemoveAsync(int id)
    {
        var pessoa = await _pessoaRepository.GetByIdAsync(id);
        if (pessoa == null)
            return ResultService.Fail<PessoaDTO>("Usuario nao encontrado");

        await _pessoaRepository.DeleteAsync(pessoa);
        return ResultService.Ok($"Usuaro do id: {id}, foi deletado");
    }
}