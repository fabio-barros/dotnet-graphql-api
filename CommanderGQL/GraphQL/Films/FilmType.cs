using System.Linq;
using CommanderGQL.Models;
using HotChocolate.Types;

namespace CommanderGQL.GraphQL.Films
{
    public class FilmType : ObjectType<Film>
    {
        protected override void Configure(IObjectTypeDescriptor<Film> descriptor)
        {
            descriptor.Description("Represents a motion picture, work of visual art.");

            descriptor.Field(d => d.DirectorConnection).Ignore();
        }

    }
}