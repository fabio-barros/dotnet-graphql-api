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

    }
}