namespace ProjectFinancas.Controllers.Dtos
{
    public class DataDto
    {
        public string iduser { get; set; } = string.Empty;
        public DateTime StartDate { get; set; } = DateTime.Now.Date;
        public DateTime EndDate { get; set; } = DateTime.Now.Date;
        public string? Module {  get; set; } 
    }
}
