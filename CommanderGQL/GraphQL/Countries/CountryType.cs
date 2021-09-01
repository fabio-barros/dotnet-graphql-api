using CommanderGQL.Models;
using HotChocolate.Types;

namespace CommanderGQL.GraphQL.Countries
{
    public class CountryType : ObjectType<Country>
    {
        protected override void Configure(IObjectTypeDescriptor<Country> descriptor)
        {
            descriptor.Description("Represents the countries of origin.");


        }

    }
}