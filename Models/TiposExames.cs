namespace API_VidaPlus.Models
{
    public class TiposExames
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descritivo { get; set; } = string.Empty;
        public ICollection<Exames>? PertenceExames { get; set; }
    }
}
