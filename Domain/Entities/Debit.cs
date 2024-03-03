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

   

        public Debit()
        {
            Iduser = string.Empty;
            Value = decimal.Zero;
            Id = string.Empty;
            Description = string.Empty;
            Type = string.Empty;
            Date = DateTime.Now;
            Module = string.Empty;  
        }

        public Debit(decimal value, string? description, string type, string iduser, string? module)
        {
            Iduser = iduser;    
            Value = value;
            Description = description;
            Type = type;
            Module = module;
        }
    }
}
