using System.Linq;
using CommanderGQL.Db;
using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Data;

namespace CommanderGQL.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        public IQueryable<Plataform> GetPlataform([ScopedService] AppDbContext context)
        {
            return context.Plataforms;

        }
    }
}