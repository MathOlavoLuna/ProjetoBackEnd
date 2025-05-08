namespace API_VidaPlus.Models
{
    public class AgendaMedica
    {
        public int Id { get; set; }
        public int MedicoId { get; set; } = 0;
        public required Usuarios Medico { get; set; }
        
    }
}
