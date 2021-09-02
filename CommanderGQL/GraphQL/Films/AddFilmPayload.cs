using CommanderGQL.Models;
using Microsoft.AspNetCore.Routing.Constraints;

namespace CommanderGQL.GraphQL.Films
{
    public record AddFilmPayload(Film film);

}