using Microsoft.EntityFrameworkCore;

namespace GCGuildManager.Models
{
    public class GuildManagerContext : DbContext
    {
        public GuildManagerContext(DbContextOptions<GuildManagerContext> options) : base(options) {}

        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Classe> Classes { get; set; }
        public DbSet<Equipe> Equipes { get; set; }
        public DbSet<Mascote> Mascotes { get; set; }
        public DbSet<Membro> Membros { get; set; }
        public DbSet<Personagem> Personagens { get; set; }
        public DbSet<RegistroBatalha> RegistrosBatalha { get; set; }
        public DbSet<RegistroChefe> RegistrosChefe { get; set; }
        public DbSet<RegistroPoder> RegistrosPoder { get; set; }
    }
}