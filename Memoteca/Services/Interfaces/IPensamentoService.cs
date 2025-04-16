using Domain.DTOs;
using Domain.Models;

namespace Memoteca.Services.Interfaces
{
    public interface IPensamentoService
    {
        Task<List<PensamentoModel>> BuscarTodosPensamentosAsync();
        Task<PensamentoModel> BuscarPensamentoPorIdAsync(int id);
        Task<RetornoPaginado<PensamentoModel>> BuscarPensamentosPaginadosAsync(int pagina, int quantidade);
        Task<bool> CriarPensamentoAsync(PensamentoDto pensamento);
        Task<bool> AtualizarPensamentoAsync(int id, PensamentoDto pensamento);
        Task<bool> ExcluirPensamentoAsync(int id);

    }
}
