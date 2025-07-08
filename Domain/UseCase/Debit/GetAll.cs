using debit;
using idebitRepository;
using sumvalue;

namespace ProjectFinancas.Domain.UseCase;

public class GetAll
{
    private readonly IDebitRepository _debitRepository;

    public GetAll(IDebitRepository debitRepository)
    {
        _debitRepository = debitRepository;
    }

    public async Task<(IEnumerable<Debit> Get, decimal Total)> GetAllAsync()
    {
        
            IEnumerable<Debit> debits = await _debitRepository.GetALL();
            
            var sumValue = new SumValue();

            List<Debit> enumerable = debits.ToList();
            
            var total = sumValue.FilterValue(enumerable.ToArray(), "Entrada");
    
            return (enumerable, total);
            
    }
 }