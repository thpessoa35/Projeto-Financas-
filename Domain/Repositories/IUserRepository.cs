using ProjectFinancas.Domain.Entities;
using user;

namespace ProjectFinancas.Domain.Repositories
{
    public interface IUserRepository
    {
        Task Create(User data);
        Task <bool> FindByEmail(string email);
        Task<bool> FindByCpf(string id);

        Task CreateClient(Clients client);

    }
}
