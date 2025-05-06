using System.Text.Json.Serialization;

namespace API_VidaPlus.Models
{
    public class Prescricoes
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public int MedicoId { get; set; }
        public int HospitalId { get; set; }

        [JsonIgnore]
        public int? ConsultaId { get; set; }

        [JsonIgnore]
        public Consultas? PertenceConsulta { get; set; }
    }
}
