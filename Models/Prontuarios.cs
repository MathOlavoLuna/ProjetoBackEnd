namespace API_VidaPlus.Models
{
    public class Prontuarios
    {
        public int Id { get; set; } 
        public int PacienteId {  get; set; }
        public string Descritivo { get; set; } = string.Empty;
        public Usuarios? Paciente { get; set; }
        public ICollection<Consultas>? ConsultasPaciente { get; set; }
        public ICollection<Exames>? ExamesPaciente { get; set; }
    }
}
