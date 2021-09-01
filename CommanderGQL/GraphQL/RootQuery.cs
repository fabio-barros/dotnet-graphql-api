using System.Linq;
using CommanderGQL.Db;
using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Data;
using Microsoft.EntityFrameworkCore;

namespace CommanderGQL.GraphQL
{
    public class RootQuery
    {

        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Director> GetDirectors([ScopedService] AppDbContext context)
        {
            return context.Directors;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Language> GetLanguages([ScopedService] AppDbContext context)
        {
            return context.Languages;
        }

    }
}