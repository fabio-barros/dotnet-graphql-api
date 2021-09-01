using CommanderGQL.Models;
using Microsoft.EntityFrameworkCore;

namespace CommanderGQL.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Plataform> Plataforms { get; set; }
        public DbSet<Command> Commands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plataform>(entity =>
           {
               entity.HasMany(p => p.Commands).WithOne(p => p.Plataform!).HasForeignKey(p => p.PlataformId);
           });

            modelBuilder.Entity<Command>(entity =>
           {
               entity.HasOne(p => p.Plataform).WithMany(p => p.Commands!).HasForeignKey(p => p.PlataformId);
           });


        }
    }
}