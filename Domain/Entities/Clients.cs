namespace ProjectFinancas.Domain.Entities;

public sealed class Clients
{
    public int Id { get; private set; }
    
    public string Name { get; private set; } = string.Empty;
    
    public bool Payments { get; private set; } 
    
    public DateTime Date { get; private set; }


    public Clients(string name, bool payments, DateTime date)
    {
        SetName(name);
        SetPayments(payments);
        SetDate(date);
    }

    public static Clients Create(string name, bool payments)
    {
        return new Clients(name, payments, DateTime.Now);   
    }
    
    private void SetName(string name)
    {
        Name = name;
    }

    private void SetPayments(bool payments)
    {
        Payments = payments;
    }

    public void SetDate(DateTime date)
    {
        Date = date;
    }
}