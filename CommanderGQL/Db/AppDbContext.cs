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
        public DbSet<Director> Directors { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<CrewMember> CrewMembers { get; set; }

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

            modelBuilder.Entity<Director>(entity =>
           {
               entity.HasMany(d => d.Films).WithOne(d => d.Director!).HasForeignKey(d => d.DirectorConnection);
           });

            modelBuilder.Entity<Film>(entity =>
           {
               entity.HasOne(d => d.Director).WithMany(d => d.Films).HasForeignKey(d => d.DirectorConnection);

               //    entity.HasMany(d => d.Languages).WithOne(d => d.Film).HasForeignKey(d => d.FilmConnection);
           });

            //     modelBuilder.Entity<Language>(entity =>
            //    {
            //        entity.HasOne(d => d.Film).WithMany(d => d.Languages).HasForeignKey(d => d.FilmConnection);


            //    });

        }
    }
}