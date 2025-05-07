namespace API_VidaPlus.Models
{
    public class Prontuarios
    {
        public int Id { get; set; } 
        public string Descritivo { get; set; } = string.Empty;
        public int PacienteId {  get; set; }
        public Usuarios? Paciente { get; set; }

        public int ConsultaId { get; set; }
        public ICollection<Consultas>? ConsultasPaciente { get; set; }

        public int ExameId { get; set; }
        public ICollection<Exames>? ExamesPaciente { get; set; }
    }
}
