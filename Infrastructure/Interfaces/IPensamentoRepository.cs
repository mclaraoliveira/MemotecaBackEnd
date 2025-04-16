using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs;
using Domain.Models;

namespace Infrastructure.Interfaces
{
    public interface IPensamentoRepository
    {
        Task<List<PensamentoModel>> BuscarTodosPensamentosAsync();
        Task<PensamentoModel> BuscarPensamentoPorIdAsync(int id);
        Task<RetornoPaginado<PensamentoModel>> BuscarPensamentosPaginadosAsync(int pagina, int quantidade);
        Task<bool> CriarPensamentoAsync(PensamentoDto pensamento);
        Task<bool> AtualizarPensamentoAsync(int id, PensamentoDto pensamento);
        Task<bool> ExcluirPensamentoAsync(int id);

    }
}
