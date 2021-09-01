using System.Linq;
using CommanderGQL.Db;
using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;

namespace CommanderGQL.GraphQL.Languages
{
    public class LanguageType : ObjectType<Language>
    {
        protected override void Configure(IObjectTypeDescriptor<Language> descriptor)
        {
            descriptor.Description("Represents the languages spoken in the movie.");

            descriptor.Field(d => d.Films).ResolveWith<Resolvers>(d => d.GetFilms(default!, default!))
          .UseDbContext<AppDbContext>()
          .Description("This is the list o films that includes this language.");


        }

        private class Resolvers
        {
            public IQueryable<Film> GetFilms(Language language, [ScopedService] AppDbContext context)
            {
                return context.Films.Where(film => film.Languages.Select(language => language.LanguageName).Contains(language.LanguageName))
                .Include(f => f.Countries)
                .Include(f => f.Actors)
                .Include(f => f.CrewMembers)
                .Include(f => f.Languages).Include(f => f.Director)
                ;

            }
        }


    }
}