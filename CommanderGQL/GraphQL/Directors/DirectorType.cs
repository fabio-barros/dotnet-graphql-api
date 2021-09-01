using System.Linq;
using CommanderGQL.Db;
using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;

namespace CommanderGQL.GraphQL.Directors
{
    public class DirectorType : ObjectType<Director>
    {
        protected override void Configure(IObjectTypeDescriptor<Director> descriptor)
        {

            descriptor.Field(d => d.Films).ResolveWith<Resolvers>(d => d.GetFilms(default!, default!))
            .UseDbContext<AppDbContext>()
            .Description("This is the list o films by this director.");

        }

        private class Resolvers
        {
            public IQueryable<Film> GetFilms(Director director, [ScopedService] AppDbContext context)
            {
                return context.Films
                .Where(e => e.Director.Id == director.Id)
                .Include(f => f.Languages)
                .Include(f => f.Countries)
                .Include(f => f.Actors).Include(f => f.CrewMembers);

            }
        }

    }
}