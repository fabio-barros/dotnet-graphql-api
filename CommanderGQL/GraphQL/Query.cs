using System.Linq;
using CommanderGQL.Db;
using CommanderGQL.Models;
using HotChocolate;

namespace CommanderGQL.GraphQL
{
    public class Query
    {
        public IQueryable<Plataform> GetPlataform([Service] AppDbContext context)
        {
            return context.Plataforms;

        }
    }
}