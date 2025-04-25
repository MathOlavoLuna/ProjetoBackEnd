namespace API_VidaPlus.Models
{
    public class Consultas
    {
        public int? Id { get; set; }
        public TiposConsultas Tipo { get; set; }

        public required int PacienteId { get; set; } = 0;
        public Usuarios Paciente { get; set; }

        public required int MedicoId { get; set; } = 0;
        public Usuarios Medico { get; set; }
        public DateTime MarcadoPara { get; set; }
        public Prescricoes? Prescricao { get; set; }
        public bool? Compareceu { get; set; }    
    }
}
