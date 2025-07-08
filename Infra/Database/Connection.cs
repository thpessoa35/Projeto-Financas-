
using Npgsql;

public class ConnectionPostgres
{
    private readonly string _connectionString;

    public ConnectionPostgres()
    {
        DotNetEnv.Env.Load();
        
        _connectionString = $"Host=postgres;Port=5432;Username=user;Password=701226;Database=financas;";
    }

    public NpgsqlConnection GetConnection()
    {
        try
        {
            return new NpgsqlConnection(_connectionString);
           
            
        }
        catch (Exception error)
        {
            Console.WriteLine($"Erro ao conectar no banco de dados: {error.Message}");
            throw;
        }
    }
}
