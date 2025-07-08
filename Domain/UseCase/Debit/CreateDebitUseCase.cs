
using debit;
using idebitRepository;
using ProjectFinancas.Domain.ValueObject;

public class CreateDebitUseCase
{
    private IDebitRepository _IdebitRepository;

    public CreateDebitUseCase(IDebitRepository idebitRepository)
    {
        _IdebitRepository = idebitRepository;
    }

    public async Task create(DebitDto data)
    {
        try
        {
            var validate = new TransactionType(data.Type);

            decimal valorProcessado = validate.ProcessTransaction(data.Value);
           
            var newDebit = Debit.Create(valorProcessado, data.Description, data.Type, "ae5138d7-4d5b-475a-8584-17a62b5683a8", DateTime.Now, data.Module);
    
            await _IdebitRepository.create(newDebit);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw new Exception("Erro ao criar transação", ex);
        }
    }
}
