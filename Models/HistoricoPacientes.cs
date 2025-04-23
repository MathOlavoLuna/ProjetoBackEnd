namespace API_VidaPlus.Models
{
    public class HistoricoPacientes
    {
        public int Id { get; set; }
        public Usuarios PacienteId { get; set; }
        public Exames Exames { get; set; }
        public Consultas Consultas { get; set; }   
    }
}
