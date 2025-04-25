namespace API_VidaPlus.Models
{
    public class Medico(string nome, int idade, string cpf, string email, TiposUsuarios tipo) : Usuarios(nome, idade, cpf, email, tipo)
    {
        public new int Id {  get; set; }
        public AgendaMedica AgendaMedica { get; set; } = new AgendaMedica();

    }
}
