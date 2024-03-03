using System;
using System.Threading.Tasks;
using debit;
using idebitRepository;

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

            var newDebit = new Debit(
                iduser: data.Iduser,
                value: valorProcessado,
                description: data.Description,
                type: data.Type,
                module: data.Module
            );

            await _IdebitRepository.create(newDebit);
        }
        catch (Exception ex)
        {
            
            throw new Exception("Erro ao criar transação", ex);
        }
    }
}
