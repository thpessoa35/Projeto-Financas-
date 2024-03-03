
using debit;

namespace ProjectFinancas.Domain.ValueObject
{
    public class FilterDate
    {
        public DateTime StartDate { get; set; } = DateTime.Now.Date;
        public DateTime EndDate { get; set; } = DateTime.Now.Date;

        public FilterDate(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public IEnumerable<Debit> FilterDebits(IEnumerable<Debit> debits)
        {
            
            var filteredDebits = debits.Where(debit => debit.Date.Date >= StartDate && debit.Date.Date <= EndDate);

            return filteredDebits;
        }
    }   
}

