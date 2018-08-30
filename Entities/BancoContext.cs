using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Entities
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options): base(options)
        { }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Financeiro> Financeiro { get; set; }
        public DbSet<PagSeguro> PagSeguro { get; set; }
        public DbSet<Revendedor> Revendedor { get; set; }
        public DbSet<Smtp> Smtp { get; set; }
        public DbSet<ModeloEmail> ModeloEmail { get; set; }
        public DbSet<Servidor> Servidor { get; set; }
        public DbSet<LogEventos> LogEventos { get; set; }
        
    }
}