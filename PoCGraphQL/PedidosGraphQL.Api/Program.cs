using Microsoft.EntityFrameworkCore;
using PedidosGraphQL.Api.Data;
using PedidosGraphQL.Api.GraphQL;

var builder = WebApplication.CreateBuilder(args);

const string FrontendCorsPolicy = "FrontendCorsPolicy";

var connectionString = builder.Configuration.GetConnectionString("PostgresConnection")
    ?? throw new InvalidOperationException("No se ha configurado la cadena de conexión 'PostgresConnection'.");

builder.Services.AddDbContext<PedidosDbContext>(options => options.UseNpgsql(connectionString));

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddFiltering()
    .AddSorting();

builder.Services.AddCors(options =>
{
    options.AddPolicy(FrontendCorsPolicy, policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors(FrontendCorsPolicy);

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PedidosDbContext>();
    db.Database.Migrate();
}

app.MapGraphQL();

app.Run();
