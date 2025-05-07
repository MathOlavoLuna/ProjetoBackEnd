namespace API_VidaPlus.Models
{
    public class Exames
    {
        public int Id { get; set; }
        public int TipoExameId { get; set; }
        public TiposExames Tipo { get; set; }
        public DateTime MarcadoPara { get; set; }
        public bool Compareceu { get; set; } = false;

        public int PacienteId { get; set; }
        public Usuarios? Paciente { get; set; }

        public int? ProntuarioId { get; set; }
        public Prontuarios? ParticipaProntuario { get; set; }

    }
}
