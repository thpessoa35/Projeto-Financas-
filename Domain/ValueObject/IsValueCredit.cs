
namespace transactionValue
{
    public class TransactionValue
    {
        public decimal Value { get; private set; }
        public decimal ValueValidate(decimal value)
        {
            
            if (value == 0m)
            {
                throw new Exception("Valor não pode ser 0");
            }

            Value = value * -1;
            return Value;
        }
    }
}