
namespace credit
{
    public class Credit
    {
        public string? Id { get; set; }
        public string Iduser { get; set; }
        public decimal Value { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }


        public Credit()
        {
            Value = decimal.Zero;
            Id = string.Empty;
            Description = string.Empty;
            Iduser = string.Empty;
            Date = DateTime.Now;

        }

        public Credit(decimal value, string? description, string iduser)
        {
            Value = value;
            Description = description;
            Iduser = iduser;

        }
    }
}
