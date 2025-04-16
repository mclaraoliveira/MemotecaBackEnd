using Dapper;
using Domain.DTOs;
using Domain.Models;
using Infrastructure.Interfaces;
using System.Data;


namespace Infrastructure.Repositories
{
    public class PensamentoRepository : IPensamentoRepository
    {
        private readonly IDbConnection _connection;

        public PensamentoRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<bool> CriarPensamentoAsync(PensamentoDto pensamento)
        {
            try
            {
                var query = @"INSERT INTO Pensamentos (Pensamento, Autor, Modelo)
                              VALUES (@Pensamento, @Autor, @Modelo)";

                var result = await _connection.ExecuteAsync(query, pensamento);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar pensamento.", ex);
            }
        }

        public async Task<bool> AtualizarPensamentoAsync(int id, PensamentoDto pensamento)
        {
            try
            {
                var query = @"UPDATE Pensamentos
                              SET Pensamento = @Pensamento, Autor = @Autor, Modelo = @Modelo
                              WHERE Id = @Id";

                var parameters = new
                {
                    Id = id,
                    pensamento.Pensamento,
                    pensamento.Autor,
                    pensamento.Modelo
                };

                var result = await _connection.ExecuteAsync(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar pensamento.", ex);
            }
        }

        public async Task<bool> ExcluirPensamentoAsync(int id)
        {
            try
            {
                var query = "DELETE FROM Pensamentos WHERE Id = @Id";
                var result = await _connection.ExecuteAsync(query, new { Id = id });
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir pensamento.", ex);
            }
        }

        public async Task<PensamentoModel> BuscarPensamentoPorIdAsync(int id)
        {
            try
            {
                var query = "SELECT * FROM Pensamentos WHERE Id = @Id";
                var pensamento = await _connection.QueryFirstOrDefaultAsync<PensamentoModel>(query, new { Id = id });
                return pensamento;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar pensamento por Id.", ex);
            }
        }

        public async Task<List<PensamentoModel>> BuscarTodosPensamentosAsync()
        {
            try
            {
                var query = "SELECT * FROM Pensamentos";
                var pensamentos = await _connection.QueryAsync<PensamentoModel>(query);
                return pensamentos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar pensamentos.", ex);
            }
        }

        public async Task<RetornoPaginado<PensamentoModel>> BuscarPensamentosPaginadosAsync(int pagina, int quantidade)
        {
            try
            {
                var offset = (pagina - 1) * quantidade;

                var query = @"
            SELECT * FROM Pensamentos
            ORDER BY Id
            OFFSET @Offset ROWS FETCH NEXT @Quantidade ROWS ONLY;

            SELECT COUNT(*) FROM Pensamentos;
        ";

                using (var multi = await _connection.QueryMultipleAsync(query, new { Offset = offset, Quantidade = quantidade }))
                {
                    var pensamentos = (await multi.ReadAsync<PensamentoModel>()).ToList();
                    var total = await multi.ReadFirstAsync<int>();

                    return new RetornoPaginado<PensamentoModel>(
                        itens: pensamentos,
                        totalRegistros: total,
                        pagina: pagina,
                        qtdPagina: quantidade
                    );
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar alunos paginados.", ex);
            }
        }

    }
}
