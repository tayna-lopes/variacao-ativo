using Microsoft.AspNetCore.Mvc;
using variacao_ativo.Models;
using variacao_ativo.Services.Interface;

namespace variacao_ativo.Controllers;

[ApiController]
[Route("[controller]")]
public class VariacaoAtivoController : ControllerBase
{
    private readonly ILogger<VariacaoAtivoController> _logger;
    private readonly IFinanceApiService _financeApiService;

    public VariacaoAtivoController(ILogger<VariacaoAtivoController> logger, IFinanceApiService financeApiService)
    {
        _logger = logger;
        _financeApiService = financeApiService;
    }
    /// <summary>
    /// Lista os itens da To-do list.
    /// </summary>
    [HttpGet]
    [Route("ObterChart")]

    public async Task<ActionResult<string>> ObterChart(string NomeAtivo)
    {
        try
        {
            if (String.IsNullOrEmpty(NomeAtivo)) 
            {
                return BadRequest();
            }
            return await _financeApiService.ObterChart(NomeAtivo);

        }catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}



