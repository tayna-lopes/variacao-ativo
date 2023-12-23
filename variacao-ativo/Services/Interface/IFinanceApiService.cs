using variacao_ativo.Models;

namespace variacao_ativo.Services.Interface
{
    public interface IFinanceApiService
    {
        Task<string> ObterChart(string NomeAtivo);

    }
}
