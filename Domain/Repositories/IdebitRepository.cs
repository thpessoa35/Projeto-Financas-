using debit;

namespace idebitRepository
{
    public interface IDebitRepository
    {
        Task create(Debit debit);
        Task<IEnumerable<Debit>> FindByData(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Debit>> FindBySaida(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Debit>> FindByEntrada(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Debit>> GetFunctionEntradaModule(string module, string iduser, DateTime startDate, DateTime endDate);
        Task<IEnumerable<Debit>> GetFunctionBySaida(string iduser, string module, DateTime startDate, DateTime endDate);

        Task<IEnumerable<Debit>> GetALL();
    }
}