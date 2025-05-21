namespace API_VidaPlus.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;
        public ICollection<Leitos>? Leitos { get; set; }
        public RelatorioFinanceiroHospital? RelatorioFinanceiroHospital { get; set; }
        public int? RelatorioId { get; set; }
    }
}
