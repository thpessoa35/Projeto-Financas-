using ProjectFinancas.Controllers.Dtos;
using ProjectFinancas.Domain.Repositories;

namespace ProjectFinancas.Domain.UseCase.Clients;

public class CreateClientsUseCase
{

    private readonly IUserRepository _userRepository;

    public CreateClientsUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<ClientsDto>> ExecuteAsync(List<ClientsDto> clients)
    {
        
        foreach (var client in clients)
        {   
            Entities.Clients entity = Entities.Clients.Create(client.Name, client.Payments);

            await _userRepository.CreateClient(entity);
        }   
        
        return clients;
    } 
}