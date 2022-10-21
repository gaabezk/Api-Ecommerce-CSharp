using com.myapi.Application.DTO;
using com.myapi.Application.Services.Interfaces;
using com.myapi.Domain.FiltersDb;
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

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult> GetById(int id)
    {
        var result = await _pessoaService.GetById(id);
        if (result.IsSuccess)
            return Ok(result);

        return BadRequest(result);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateAsync([FromBody] PessoaDTO pessoaDto)
    {
        var result = await _pessoaService.UpdateAsync(pessoaDto);
        if (result.IsSuccess)
            return Ok(result);

        return BadRequest(result);
    }


    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> RemoveAsync(int id)
    {
        var result = await _pessoaService.RemoveAsync(id);
        if (result.IsSuccess)
            return Ok(result);

        return BadRequest(result);
    }
    
    [HttpGet]
    [Route("paged")]
    public async Task<ActionResult> GetPagedAsync([FromQuery] PessoaFilterDb pessoaFilterDb)
    {
        var result = await _pessoaService.GetPagedAsync(pessoaFilterDb);
        if (result.IsSuccess)
            return Ok(result);

        return BadRequest(result);
    }
}