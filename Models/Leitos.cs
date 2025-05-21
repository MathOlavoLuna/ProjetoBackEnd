namespace API_VidaPlus.Models
{
    public class Leitos
    {
        public int Id { get; set; } 
        public bool Ocupado { get; set; }
        public int? PacienteId { get; set; }
        public Usuarios? Paciente { get; set; }
        public int HospitalId { get; set; }
        public Hospital? Hospital { get; set; }
    }
}
