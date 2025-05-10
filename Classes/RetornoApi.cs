using API_VidaPlus.Models;

namespace API_VidaPlus.Classes
{
    public class RetornoApi<T> where T : class
    {
        public bool Sucesso { get; set; } = false;
        public List<T> Data { get; set; } = [];
        public string Mensagem { get; set; } = string.Empty;
        public string Erro { get; set; } = string.Empty;
    }

    public class RetornoProntuario
    {
        public int Id { get; set; }
        public string NomePaciente { get; set; }
        public ICollection<Exames> ExamesPaciente { get; set; }
        public ICollection<Consultas> ConsultasPaciente { get; set; }
    }

    public class RetornoAgendaMedica()
    {
        public int Id { get; set; }
        public int MedicoId { get; set; }
        public string MedicoNome { get; set; }
        public int MedicoIdade { get; set; }
        public ICollection<Exames> ExamesMedico { get; set; }
        public ICollection<Consultas> ConsultasMedico { get; set; }
    }

    public class RetornoAgendaConsulta { 
        public int? Id { get; set; }
        public TiposConsultas TipoConsulta { get; set; }
        public string PacienteNome { get; set; }
        public DateTime MarcadoPara { get; set; }
        public bool? Compareceu { get; set; }
    }
}
