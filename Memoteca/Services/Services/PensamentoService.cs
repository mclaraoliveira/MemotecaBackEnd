using Domain.DTOs;
using Domain.Models;
using Infrastructure.Interfaces;
using Memoteca.Services.Interfaces;

namespace Memoteca.Services.Services
{
    public class PensamentoService : IPensamentoService
    {
        private readonly IPensamentoRepository _repository;

        public PensamentoService(IPensamentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AtualizarPensamentoAsync(int id, PensamentoDto pensamento)
        {
            try
            {
                return await _repository.AtualizarPensamentoAsync(id, pensamento);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar pensamento", ex);
            }
        }

        public async Task<PensamentoModel> BuscarPensamentoPorIdAsync(int id)
        {
            try
            {
                return await _repository.BuscarPensamentoPorIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar pensamento por ID", ex);
            }
        }

        public async Task<RetornoPaginado<PensamentoModel>> BuscarPensamentosPaginadosAsync(int pagina, int quantidade)
        {
            try
            {
                return await _repository.BuscarPensamentosPaginadosAsync(pagina, quantidade);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar pensamentos paginados", ex);
            }
        }

        public async Task<List<PensamentoModel>> BuscarTodosPensamentosAsync()
        {
            try
            {
                return await _repository.BuscarTodosPensamentosAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar todos os pensamentos", ex);
            }
        }

        public async Task<bool> CriarPensamentoAsync(PensamentoDto pensamento)
        {
            try
            {
                return await _repository.CriarPensamentoAsync(pensamento);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar pensamento", ex);
            }
        }

        public async Task<bool> ExcluirPensamentoAsync(int id)
        {
            try
            {
                return await _repository.ExcluirPensamentoAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir pensamento", ex);
            }
        }
    }
}
