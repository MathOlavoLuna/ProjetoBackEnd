namespace API_VidaPlus.Models
{
    public class AgendaMedica
    {
        public int Id { get; set; }
        public Usuarios MedicoId { get; set; }
        public Exames Exames { get; set; }
        public Consultas Consultas { get; set; }
        public DateTime Compromisso { get; set; }
    }
}
