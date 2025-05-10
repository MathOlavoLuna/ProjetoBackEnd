using System.Text.Json.Serialization;

namespace API_VidaPlus.Models
{
    public class Consultas
    {
        public int Id { get; set; }
        public TiposConsultas Tipo { get; set; }

        public  int PacienteId { get; set; } = 0;
        [JsonIgnore]
        public Usuarios? Paciente { get; set; }

        public int MedicoId { get; set; } = 0;

        [JsonIgnore]
        public Usuarios? Medico { get; set; }

        public DateTime MarcadoPara { get; set; }
        [JsonIgnore]
        public Prescricoes? Prescricao { get; set; }
        public bool? Compareceu { get; set; }


        [JsonIgnore]
        public int? ProntuarioId { get; set; }
        [JsonIgnore]
        public Prontuarios? ParticipaProntuario { get; set; }
    }
}
