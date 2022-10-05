using com.myapi.Application.DTO;
using com.myapi.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace com.myapi.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PessoaController : ControllerBase
{
    private readonly IPessoaService _pessoaService;

    public PessoaController(IPessoaService pessoaService)
    {
        _pessoaService = pessoaService;
    }

    [HttpPost]
    public async Task<ActionResult> PostAsync([FromBody] PessoaDTO pessoaDto)
    {
        var result = await _pessoaService.CreateAsync(pessoaDto);
        if (result.IsSuccess)
            return Ok(result);

        return BadRequest(result);
    }

    [HttpGet]
    public async Task<ActionResult> GetAllAsync()
    {
        var result = await _pessoaService.GetAllAsync();
        if (result.IsSuccess)
            return Ok(result);

        return BadRequest(result);
    }
}