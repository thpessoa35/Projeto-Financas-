namespace ProjectFinancas.Controllers.Dtos;

public class ClientsDto
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public bool Payments { get; set; }
    
    public DateTime Date { get; set; }
}