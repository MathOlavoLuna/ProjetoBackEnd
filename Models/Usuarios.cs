
namespace API_VidaPlus.Models
{
    public class Usuarios
    {
        public int Id { get; set; } 
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public TiposUsuarios Tipo { get; set; }

        public Usuarios(string Nome, int Idade, string Cpf, string Email, TiposUsuarios Tipo) {
            this.Nome = Nome;  
            this.Idade = Idade;
            this.Cpf = Cpf;
            this.Email = Email;
            this.Tipo = Tipo;
        }
    }
}
