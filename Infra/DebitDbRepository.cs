using debit;
using idebitRepository;
using Dapper;

namespace debitDbRepository
{
    public class DebitDbRepository : IDebitRepository
    {
        private readonly ConnectionPostgres _connectionPostgres;

        public DebitDbRepository(ConnectionPostgres connectionPostgres)
        {
            _connectionPostgres = connectionPostgres;
        }

        public async Task create(Debit debit)
        {
            using (var connection = _connectionPostgres.GetConnection())
            {
                try
                {
                    await connection.OpenAsync();

                    var query = "INSERT INTO debit(value, description, type, idUser, module) VALUES ( @Value, @Description, @Type, @IdUser, @Module)";

                    await connection.ExecuteAsync(query, debit);
                }
                catch (Exception error)
                {
                    Console.WriteLine("error:", error);
                    throw new Exception("Erro ao inserir dados na tabela", error);
                }
            }
        }
        public async Task<IEnumerable<Debit>> FindByData(DateTime startDate, DateTime endDate)
        {
            try
            {
                using (var connection = _connectionPostgres.GetConnection())
                {
                    await connection.OpenAsync();

                    var query = "SELECT * FROM debit WHERE date BETWEEN @StartDate AND @EndDate";
                    var parameters = new { StartDate = startDate, EndDate = endDate };

                    return await connection.QueryAsync<Debit>(query, parameters);
                }
            }
            catch (Exception error)
            {
                throw new Exception("Erro ao consultar dados na tabela", error);
            }
        }

        public async Task<IEnumerable<Debit>> FindBySaida(string iduser, DateTime startDate, DateTime endDate)
        {
            try
            {

                using (var connection = _connectionPostgres.GetConnection())
                {
                    await connection.OpenAsync();

                    var query = "SELECT d.id, d.iduser, d.value, d.description, d.date, d.type FROM debit AS d INNER JOIN users AS u ON d.idUser = u.id WHERE d.type = 'Saida' AND  u.id = @iduser AND d.date BETWEEN @startDate AND @endDate";


                    return await connection.QueryAsync<Debit>(query, new { iduser, startDate, endDate });
                }
            }
            catch (Exception error)
            {
                throw new Exception("Erro ao inserir dados na tabela", error);
            }
        }
        public async Task<IEnumerable<Debit>> FindByEntrada(string iduser, DateTime startDate, DateTime endDate)
        {
            try
            {

                using (var connection = _connectionPostgres.GetConnection())
                {
                    await connection.OpenAsync();

                    var query = "SELECT d.id, d.iduser, d.value, d.description, d.date, d.type, d.module FROM debit AS d INNER JOIN users AS u ON d.idUser = u.id WHERE d.type = 'Entrada' AND u.id = @iduser AND d.date BETWEEN @startDate AND @endDate";

                    return await connection.QueryAsync<Debit>(query, new { iduser, startDate, endDate });
                }
            }
            catch (Exception error)
            {
                throw new Exception("Erro ao inserir dados na tabela", error);
            }
        }
        public async Task<IEnumerable<Debit>> GetFunctionEntradaModule(string iduser, string module, DateTime startDate, DateTime endDate)
        {
            using (var connection = _connectionPostgres.GetConnection())
            {
                try
                {

                    await connection.OpenAsync();

                    var query = "SELECT d.id, d.iduser, d.value, d.description, d.date, d.type, d.module FROM debit AS d INNER JOIN users AS u ON d.idUser = u.id WHERE d.type = 'Entrada' AND d.module = @module AND u.id = @iduser AND d.date BETWEEN @startDate AND @endDate";



                    Console.WriteLine($"Executing SQL Query: {query}");
                    Console.WriteLine($"Parameters: module = {module}, iduser = {iduser}");

                    var result = await connection.QueryAsync<Debit>(query, new { module, iduser, startDate, endDate });


                    Console.WriteLine($"Number of Results: {result?.Count()}");

                    return result;
                }
                catch (Exception error)
                {
                    throw new Exception("Erro ao inserir dados na tabela", error);
                }
            }
        }
        public async Task<IEnumerable<Debit>> GetFunctionBySaida(string iduser, string module, DateTime startDate, DateTime endDate)
        {
            using (var connection = _connectionPostgres.GetConnection())
            {
                try
                {

                    await connection.OpenAsync();

                    var query = "SELECT * FROM debit WHERE module = @module AND type = 'Saida' AND idUser = @iduser AND d.date BETWEEN @startDate AND @endDate";


                    Console.WriteLine($"Executing SQL Query: {query}");
                    Console.WriteLine($"Parameters: module = {module}, iduser = {iduser}");

                    var result = await connection.QueryAsync<Debit>(query, new { module, iduser, startDate, endDate });


                    Console.WriteLine($"Number of Results: {result?.Count()}");

                    return result;
                }
                catch (Exception error)
                {

                    throw new Exception("Erro ao inserir dados na tabela", error);
                }
            }
        }


    }
}

