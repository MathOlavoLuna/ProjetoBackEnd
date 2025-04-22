namespace API_VidaPlus.Entities
{
    public class Usuarios
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public int? Idade { get; set; }
        public required string Cpf { get; set; }
        public required string Email { get; set; }
        public TiposUsuarios Tipo { get; set; }
    }
}
