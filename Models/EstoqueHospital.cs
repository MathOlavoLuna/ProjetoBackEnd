namespace API_VidaPlus.Models
{
    public class EstoqueHospital
    {
        public int Id { get; set; }
        public Hospital HospitalId { get; set; }
        public string NomeItem { get; set; }
        public int Quantidade { get; set; }
        public float preco { get; set; }
    }
}
