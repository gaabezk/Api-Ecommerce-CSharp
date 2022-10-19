using com.myapi.Application.DTO;
using com.myapi.Application.Services;
using com.myapi.Application.Services.Interfaces;
using com.myapi.Domain.Validations;
using Microsoft.AspNetCore.Mvc;

namespace com.myapi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompraController : ControllerBase
{
    private readonly ICompraService _compraService;

    public CompraController(ICompraService compraService)
    {
        _compraService = compraService;
    }

    [HttpPost]
    public async Task<ActionResult> PostAsync([FromBody] CompraDTO compraDto)
    {
        try
        {
            var result = await _compraService.CreateAsync(compraDto);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
        catch (DomainValidationException e)
        {
            var result = ResultService.Fail(e.Message);
            return BadRequest(result);
        }
    }

    [HttpGet]
    public async Task<ActionResult> GetAllAsync()
    {
        var result = await _compraService.GetAllAsync();
        if (result.IsSuccess)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult> GetByIdAsync(int id)
    {
        var result = await _compraService.GetById(id);
        if (result.IsSuccess)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpPut]
    public async Task<ActionResult> EditAsync([FromBody] CompraDTO compraDto)
    {
        try
        {
            var result = await _compraService.UpdateAsync(compraDto);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
        catch (DomainValidationException e)
        {
            var result = ResultService.Fail(e.Message);
            return BadRequest(result);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> RemoveAsync(int id)
    {
        var result = await _compraService.RemoveAsync(id);
        if (result.IsSuccess)
            return Ok(result);
        return BadRequest(result);
    }
}