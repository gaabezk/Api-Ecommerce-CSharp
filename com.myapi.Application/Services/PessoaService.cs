using System.Collections;
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

        var pessoa = _mapper.Map<Pessoa>(pessoaDto);
        var data = await _pessoaRepository.CreateAsync(pessoa);
        return ResultService.Ok(_mapper.Map<PessoaDTO>(data));
    }

    public async Task<ResultService<ICollection<PessoaDTO>>> GetAllAsync()
    {   
        var result = await _pessoaRepository.GetAllAsync();
        return ResultService.Ok(_mapper.Map<ICollection<PessoaDTO>>(result));

    }
}