using debit;
using idebitRepository;
using Dapper;
using credit;
using iCreditRepository;

namespace debitDbRepository
{
    public class CreditDbRepository : ICreditRepository
    {
        private readonly ConnectionPostgres _connectionPostgres;

        public CreditDbRepository(ConnectionPostgres connectionPostgres)
        {
            _connectionPostgres = connectionPostgres;
        }

        public async Task create(Credit data)
        {
            using (var connection = _connectionPostgres.GetConnection())
            {
                try
                {
                    await connection.OpenAsync();

                    var query = "INSERT INTO credit(value, description, iduser) VALUES (@Value, @Description, @iduser)";

                    await connection.ExecuteAsync(query, data);
                }
                catch (Exception error)
                {
                    Console.WriteLine("error:", error);
                    throw new Exception("Erro ao inserir dados na tabela", error);
                }
            }
        }
        public async Task<IEnumerable<Credit>> FindAll(string iduser)
        {
            try
            {
                using (var connection = _connectionPostgres.GetConnection())
                {
                    await connection.OpenAsync();

                    var query = "SELECT * FROM credit WHERE iduser = @iduser";

                    return await connection.QueryAsync<Credit>(query, new { iduser });

                }
            }
            catch (Exception error)
            {
                throw new Exception("Erro ao consultar dados na tabela", error);
            }
        }
    }
}
