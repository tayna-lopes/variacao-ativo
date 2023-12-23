using Microsoft.AspNetCore.Mvc;

namespace variacao_ativo.Controllers;

[ApiController]
[Route("[controller]")]
public class VariacaoAtivoController : ControllerBase
{
    private readonly ILogger<VariacaoAtivoController> _logger;

    public VariacaoAtivoController(ILogger<VariacaoAtivoController> logger)
    {
        _logger = logger;
    }

    //[HttpGet(Name = "GetWeatherForecast")]
    //public IEnumerable<WeatherForecast> Get()
    //{
    //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //    {
    //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
    //        TemperatureC = Random.Shared.Next(-20, 55),
    //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    //    })
    //    .ToArray();
    //}
}



