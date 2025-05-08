using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public Usuarios? Paciente { get; set; }
        [JsonIgnore]
        public int? ProntuarioId { get; set; }
        [JsonIgnore]
        public Prontuarios? ParticipaProntuario { get; set; }

        public int? MedicoId { get; set; }
        [JsonIgnore]
        public Usuarios? Medico { get; set; }


    }
}
