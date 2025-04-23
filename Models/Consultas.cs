namespace API_VidaPlus.Models
{
    public class Consultas
    {
        public int Id { get; set; }
        public TiposConsultas Tipo { get; set; }
        public Usuarios PacienteId { get; set; }
        public Usuarios MedicoId { get; set; }
        public DateTime MarcadoPara { get; set; }
        public Prescricoes Prescricao { get; set; }
        public bool Compareceu { get; set; }    
    }
}
