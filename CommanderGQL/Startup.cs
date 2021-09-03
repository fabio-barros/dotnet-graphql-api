using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommanderGQL.Db;
using CommanderGQL.GraphQL;
using CommanderGQL.GraphQL.Countries;
using CommanderGQL.GraphQL.Directors;
using CommanderGQL.GraphQL.Films;
using CommanderGQL.GraphQL.Languages;
using GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CommanderGQL
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddPooledDbContextFactory<AppDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("NpgConnectionString")));

            services.AddGraphQLServer()
            .AddQueryType<RootQuery>()
            .AddMutationType<RootMutation>()
            .AddSubscriptionType<Subscription>()
            .AddType<DirectorType>()
            .AddType<FilmType>()
            .AddType<CountryType>()
            .AddType<LanguageType>()
            .AddProjections()
            .AddFiltering()
            .AddSorting()
            .AddInMemorySubscriptions();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });

            app.UseWebSockets();

            app.UseGraphQLVoyager(new VoyagerOptions()
            {
                GraphQLEndPoint = "/graphql",

            }, "/graphql-voyager");
        }
    }
}
