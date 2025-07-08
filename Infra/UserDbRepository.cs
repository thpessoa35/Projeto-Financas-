using Dapper;
using ProjectFinancas.Domain.Entities;
using ProjectFinancas.Domain.Repositories;
using user;

namespace ProjectFinancas.Infra
{
    public class UserDbRepository : IUserRepository
    {
        private readonly ConnectionPostgres _connectionPostgres;


        public UserDbRepository(ConnectionPostgres connectionPostgres)
        {
            _connectionPostgres = connectionPostgres;
        }

        public async Task Create(User data)
        {
            try
            {

                using (var connection = _connectionPostgres.GetConnection())
                {

                    await connection.OpenAsync();

                    var Query = "INSERT INTO users (id, name, email) VALUES(@id, @name, @email)";

                    await connection.ExecuteAsync(Query, data);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao criar usuario no banco de dados", ex);
            }
        }

        public async Task CreateClient(Clients client)
        {
            try
            {

                using (var connection = _connectionPostgres.GetConnection())
                {

                    await connection.OpenAsync();

                     const string query = "INSERT INTO clients (name, payments, date) VALUES(@name, @payments, @date)";
                     
                    await connection.ExecuteAsync(query, client);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao criar usuario no banco de dados", ex);
            }
        }

        public Task<List<User>> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> FindByEmail(string email)
        {
            try
            {
                using (var connection = _connectionPostgres.GetConnection())
                {
                    await connection.OpenAsync();

                    var query = "SELECT COUNT(*) FROM users WHERE email = @email";
                    var result = await connection.QueryFirstOrDefaultAsync<int>(query, new { email });

                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar usuários no banco de dados", ex);
            }
        }
        public async Task<bool> FindByCpf(string id)
        {
            try
            {
                using (var connection = _connectionPostgres.GetConnection())
                {
                    await connection.OpenAsync();

                    var Query = "SELECT Count(*) FROM users WHERE id = @id";

                    var result = await connection.QueryFirstOrDefaultAsync<int>(Query, new { id });

                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar Usuario no banco de dados", ex);
            }
        }
    }
}

