
using debit;
using idebitRepository;
using sumvalue;

namespace getDebitUseCase
{
    public class GetDebitDataUseCase
    {
        private IDebitRepository _IdebitRepository;

        public GetDebitDataUseCase(IDebitRepository idebitRepository)
        {
            _IdebitRepository = idebitRepository;
        }

        public async Task<object> FindByData(DateTime startDate, DateTime endDate)
        {
            try
            {
                var debits = await _IdebitRepository.FindByData(startDate, endDate);

                return  debits;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao consultar Dados: {ex}");
                throw;
            }
        }
    }
}
