namespace API_VidaPlus.Models
{
    public class RelatorioFinanceiroHospital
    {
        public int Id { get; set; }
        public Hospital HospitalId { get; set; }
        public Produtos ProdutoId { get; set; }
        public bool Desconto { get; set; }
        public bool Provento { get; set; }
        public float Preco { get; set; }
    }
}
