namespace API_VidaPlus.Models
{
    public class Prescricoes
    {
        public int Id { get; set; }
        public string Descricao {  get; set; }
        public Usuarios MedicoId { get; set; }

    }
}
