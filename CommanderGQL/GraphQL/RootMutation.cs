using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CommanderGQL.Db;
using CommanderGQL.GraphQL.Directors;
using CommanderGQL.GraphQL.Films;
using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;

namespace CommanderGQL.GraphQL
{
    public class RootMutation
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddDirectorPayload> AddDirectorAsync(
            AddDirectorInput input, [ScopedService] AppDbContext context,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            var director = new Director
            {
                Name = input.Name

            };

            context.Directors.Add(director);
            await context.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(nameof(Subscription.OnDirectorAdded), director, cancellationToken);

            return new AddDirectorPayload(director);

        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddFilmPayload> AddFilm(AddFilmInput input, [ScopedService] AppDbContext context)
        {
            var film = new Film
            {
                Name = input.name,
                Year = input.year,
                Length = input.length,
                Color = input.color,
                Aspect = input.aspect,
                Director = await context.Directors.FindAsync(input.directorId),
            };

            context.Films.Add(film);
            await context.SaveChangesAsync();

            return new AddFilmPayload(film);

        }
    }
}
