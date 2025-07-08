using Microsoft.VisualBasic;

namespace debit
{
    public class Debit
    {
        

        public string? Id { get; set; }
        public string Iduser { get; set; }
        public decimal Value { get; set; }
        public string? Description { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string? Module { get; set; }

    
        public Debit(){}

        public Debit(decimal value, string? description, string type, string iduser, DateTime date, string? module)
        {
            Iduser = iduser;
            Value = value;
            Id = string.Empty;
            Description = description;
            Type = type;
            Date = date;
            Module = module;  
        }

        public static Debit Create(decimal value, string? description, string type, string iduser, DateTime date, string? module)
        {
           return new Debit(value, description, type, iduser, date, module);
        }
    }
    
}

