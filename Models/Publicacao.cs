namespace SaborDoBrasil.Models
{
    public class Publicacao
    {
        public int Id { get; set; }
        public int IdUsuarios { get; set; }
        public int EmpresaId { get; set; }
        public string NomePrato { get; set; }
        public string PratosCol { get; set; }
        public string Foto { get; set; }
        public string Local { get; set; }
        public string CidadeEstado { get; set; }
    }
}