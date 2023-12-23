using variacao_ativo.Models;
using variacao_ativo.Views;

namespace variacao_ativo.Services.Interface
{
    public interface IFinanceApiService
    {
        Task<List<VariacaoDoAtivoViewModel>> ObterVariacaoAtivos(string NomeAtivo);

    }
}
