using System.ComponentModel.DataAnnotations.Schema;

namespace GCGuildManager.Models
{
    [Table("registro_poder")]
    public class RegistroPoder : Registro
    {
        public long poder { get; set; }
    }
}