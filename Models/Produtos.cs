namespace API_VidaPlus.Models
{
    public class Produtos
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Preco { get; set; }
        public int? RelatorioId { get; set; }
        public RelatorioFinanceiroHospital? PertenceRelatorioHospital { get; set; }
    }
}
