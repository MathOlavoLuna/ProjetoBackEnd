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
}
