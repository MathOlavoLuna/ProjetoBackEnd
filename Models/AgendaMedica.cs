namespace API_VidaPlus.Models
{
    public class AgendaMedica
    {
        public int Id { get; set; }
        public int MedicoId { get; set; } = 0;
        public required Usuarios Medico { get; set; }
        public int ExameId { get; set; } = 0;
        public Exames? Exames { get; set; }
        public int ConsultaId { get; set; } = 0;
        public Consultas? Consultas { get; set; }


        public ICollection<Exames>? ExamesAgenda { get; set; }
        public ICollection<Consultas>? ConsultasAgenda { get; set; }
    }
}
