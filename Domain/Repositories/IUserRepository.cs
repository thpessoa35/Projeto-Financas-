using debit;
using user;

namespace iUserRepository
{
    public interface IUserRepository
    {
        Task Create(User data);
        Task <bool> FindByEmail(string email);
        Task<bool> FindByCpf(string id);
    }
}
