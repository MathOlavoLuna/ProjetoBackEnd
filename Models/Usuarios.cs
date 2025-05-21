
using System.Text.Json.Serialization;

namespace API_VidaPlus.Models
{
    public class Usuarios(string Nome, int Idade, string Senha, string Cpf, string Email, TiposUsuarios Tipo)
    {
        public int Id { get; set; }
        public string Nome { get; set; } = Nome;
        public int Idade { get; set; } = Idade;
        public string Senha { get; set; } = Senha;
        public string Cpf { get; set; } = Cpf;
        public string Email { get; set; } = Email;
        public TiposUsuarios Tipo { get; set; } = Tipo;

        [JsonIgnore]
        public ICollection<Consultas>? ConsultasPaciente { get; set; }
        [JsonIgnore]
        public ICollection<Consultas>? ConsultasMedico { get; set; }
        [JsonIgnore]
        public int? ProntuarioId { get; set; }
        [JsonIgnore]
        public Prontuarios? ParticipaProntuario { get; set; }
        [JsonIgnore]
        public ICollection<Exames>? ExamesPaciente { get; set; }
        [JsonIgnore]
        public ICollection<Exames>? ExamesMedico { get; set; }
        [JsonIgnore]
        public AgendaMedica? AgendaMedica { get; set; }
        [JsonIgnore]
        public Leitos? Internado { get; set; }
    }
}
