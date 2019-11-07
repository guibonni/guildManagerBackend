namespace GCGuildManager.Models
{
    public class Personagem
    {
        public long id { get; set; }
        public string nome { get; set; }
        public Classe classe { get; set; }
    }
}