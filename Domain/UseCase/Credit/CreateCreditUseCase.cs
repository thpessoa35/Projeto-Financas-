using credit;

using iCreditRepository;
using idebitRepository;
using transactionValue;


public class CreateCreditUseCase
{
    private ICreditRepository _IcreditRepository;


    public CreateCreditUseCase(ICreditRepository icreditRepository)
    {
        _IcreditRepository = icreditRepository;
    }


    public async Task create(CreditDto data)
    {
        try
        {


            var validateValue = new TransactionValue();
            var newValue = validateValue.ValueValidate(data.Value);

            var newDebit = new Credit(
                iduser: data.Iduser,
                value: newValue,
                description: data.Description

            );

            await _IcreditRepository.create(newDebit);
        }
        catch (Exception)
        {
            throw;
        }
    }

    internal Task create(DebitDto debitDto)
    {
        throw new NotImplementedException();
    }
}