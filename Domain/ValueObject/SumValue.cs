using debit;
using System.Linq;

namespace sumvalue
{
    public class SumValue
    {
        public decimal FilterValue(IEnumerable<Debit> debits, string type)
        {
            decimal sum = 0;

            foreach (var debit in debits)
            {
                if (debit.Type == type)
                {
                    sum += debit.Value;
                }
            }
            return sum;
        }
    }
}
