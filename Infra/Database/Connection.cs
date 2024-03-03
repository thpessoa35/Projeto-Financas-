
using Npgsql;

public class ConnectionPostgres
{
    private readonly string _connectionString;

    public ConnectionPostgres()
    {
        DotNetEnv.Env.Load();

        var dbHost = "localhost";
        var dbPort = "5432";
        var dbName = "financas";
        var dbUser = "user";
        var dbPassword = "701226";

        if (string.IsNullOrEmpty(dbHost) || string.IsNullOrEmpty(dbPort) || string.IsNullOrEmpty(dbName) || string.IsNullOrEmpty(dbUser) || string.IsNullOrEmpty(dbPassword))
        {
            Console.WriteLine("Erro: Alguma variável de ambiente necessária não está definida.");
            Console.WriteLine("Certifique-se de que DB_HOST, DB_PORT, DB_NAME, DB_USER e DB_PASSWORD estejam definidos.");
            throw new InvalidOperationException("Variáveis de ambiente não definidas corretamente.");
        }

        _connectionString = $"Host={dbHost};Port={dbPort};Database={dbName};Username={dbUser};Password={dbPassword}";
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
