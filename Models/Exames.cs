namespace API_VidaPlus.Models
{
    public class Exames
    {
        public int Id { get; set; }
        public TiposExames Tipo { get; set; }
        public DateTime MarcadoPara { get; set; }
        public bool Compareceu { get; set; }
    }
}
