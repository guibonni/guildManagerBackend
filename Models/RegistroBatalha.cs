using System.ComponentModel.DataAnnotations.Schema;

namespace GCGuildManager.Models
{
    [Table("registro_batalha")]
    public class RegistroBatalha : Registro
    {
        public int primeiroAtaque { get; set; }
        public int segundoAtaque { get; set; }
        public int defesa { get; set; }
        public Equipe equipeAtaque { get; set; }
        public Equipe equipeDefesa { get; set; }
    }
}