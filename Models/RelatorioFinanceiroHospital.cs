namespace API_VidaPlus.Models
{
    public class RelatorioFinanceiroHospital
    {
        public int Id { get; set; }
        public int HospitalId { get; set; }
        public Hospital? Hospital { get; set; }
        public ICollection<Produtos>? Produtos { get; set; }
        public int ProdutoId { get; set; }
        public float Total { get; set; } = 70000;
        public bool Desconto { get; set; }
        public bool Provento { get; set; }
        public float Preco { get; set; }
    }
}
