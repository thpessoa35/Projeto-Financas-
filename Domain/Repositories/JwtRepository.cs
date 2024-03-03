using ProjectFinancas.Controllers.Dtos;


namespace ijwtRepository
{

    public interface IJwtRepository
    {
        string CreateToken(CodigoDto codigoDto);
    }
}