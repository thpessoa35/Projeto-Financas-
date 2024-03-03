using credit;

namespace iCreditRepository
{
    public interface ICreditRepository
    {
        Task create(Credit data);
        Task<IEnumerable<Credit>> FindAll(string iduser);
    }
}