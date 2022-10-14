using com.myapi.Application.DTO;
using com.myapi.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace com.myapi.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoService _produtoService;

    public ProdutoController(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpPost]
    public async Task<ActionResult> PostAsync([FromBody] ProdutoDTO produtoDto)
    {
        var result = await _produtoService.CreateAsync(produtoDto);
        if (result.IsSuccess)
            return Ok(result);

        return BadRequest(result);
    }
}