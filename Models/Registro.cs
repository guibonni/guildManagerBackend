using System;

namespace GCGuildManager.Models
{
    public abstract class Registro
    {
        public long id { get; set; }
        public Membro membro { get; set; }
        public DateTime data { get; set; }
    }
}