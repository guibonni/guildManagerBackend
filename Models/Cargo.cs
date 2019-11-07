using System.ComponentModel.DataAnnotations;

namespace GCGuildManager.Models
{
    public class Cargo
    {
        public long id { get; set; }
        [Required]
        public string nome { get; set; }
    }
}