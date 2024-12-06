using Microsoft.EntityFrameworkCore;

namespace NotificacoesApp.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Notificacao> Notificacoes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
