using System.ComponentModel.DataAnnotations.Schema;

namespace GCGuildManager.Models
{
    [Table("registro_chefe")]
    public class RegistroChefe : Registro
    {
        public long dano { get; set; }
    }
}