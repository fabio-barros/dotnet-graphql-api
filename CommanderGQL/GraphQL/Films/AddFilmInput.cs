using System;
using CommanderGQL.GraphQL.Actors;
using CommanderGQL.GraphQL.Countries;
using CommanderGQL.GraphQL.CrewMembers;
using CommanderGQL.GraphQL.Directors;
using CommanderGQL.GraphQL.Languages;

namespace CommanderGQL.GraphQL.Films
{
    public record AddFilmInput(string name, int year, int length, string color, string aspect, Guid directorId);
}