using debit;

public class DebitDto
{
    public int? Id { get; set; }
    public string Iduser { get; set; } = string.Empty;
    public decimal Value { get; set; }
    public string? Description { get; set; }
    public string Type { get; set; } = string.Empty;
    public string? Module {  get; set; } = string.Empty;
    public DateTime StartDate { get; set; } 
    public DateTime EndDate { get; set; }
    public List<Debit>? Debits { get; set; }

}