using Microsoft.AspNetCore.Mvc;
using variacao_ativo.Models;
using variacao_ativo.Services.Interface;
using variacao_ativo.Views;

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

    [HttpGet]
    [Route("ObterVariacaoAtivos")]

    public async Task<ActionResult<List<VariacaoDoAtivoViewModel>>> ObterChart(string NomeAtivo)
    {
        try
        {
            if (String.IsNullOrEmpty(NomeAtivo)) 
            {
                return BadRequest();
            }
            return await _financeApiService.ObterVariacaoAtivos(NomeAtivo);

        }catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}



