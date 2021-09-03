using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace CommanderGQL.GraphQL
{
    public class Subscription
    {
        [Subscribe]
        [Topic]
        public Director OnDirectorAdded([EventMessage] Director director)
        {
            return director;
        }
    }
}