namespace SaborDoBrasil.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdPublicacao { get; set; }
        public string Comentarios { get; set; }
        public DateTime Data { get; set; }
        public string FotoPerfil { get; set; }
        public string Descricao { get; set; }
        public DateTime DataComentario { get; set; }
    }
}