using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }
        public DbSet<Cliente> Tb_cliente { get; set; }
        public DbSet<Endereco> Tb_endereco { get; set; }
        public DbSet<ClienteEndereco> Tb_cliente_endereco { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClienteEndereco>()
                .HasKey(ce => new { ce.Id });
            modelBuilder.Entity<Endereco>()
                .HasKey(ce => new { ce.Id });
            modelBuilder.Entity<ClienteEndereco>()
                .HasOne(ce => ce.cliente)
                .WithMany(c => c.clienteEndereco)
                .HasForeignKey(ce => ce.Tb_cliente_id)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ClienteEndereco>()
                .HasOne(ce => ce.endereco)
                .WithMany(c => c.clienteEndereco)
                .HasForeignKey(ce => ce.Tb_endereco_id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
