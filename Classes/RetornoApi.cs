namespace API_VidaPlus.Classes
{
    public class RetornoApi<T> where T : class
    {
        public bool Sucesso { get; set; } = false;
        public List<T> Data { get; set; } = [];
        public string Mensagem { get; set; } = string.Empty;
        public string Erro { get; set; } = string.Empty;
    }
}
