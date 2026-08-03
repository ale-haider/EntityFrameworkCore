using EntityFrameworkCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();

//builder.Services
//builder.Services.AddDbContext<FootballLeagueDbContext>( )

var sqliteDatabaseName = builder.Configuration
    .GetConnectionString("SqliteDatabaseConnectionString");

var folder = Environment.SpecialFolder.LocalApplicationData;
var path = Environment.GetFolderPath(folder);
var dbPath = Path.Combine(path, "FootballLeague_EfCore.db");

var connectionStrin = $"Data Source = {dbPath}";

builder.Services.AddDbContext<FootballLeagueDbContext>
    (options =>
    {
        options.UseSqlite($" Data Source={connectionStrin}")
                //.UseLazyLoadingProxies()
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)  //// enabling this stops updates in data
                .LogTo(Console.WriteLine, LogLevel.Information);

            if (!builder.Environment.IsProduction())
        {

            options.EnableSensitiveDataLogging();
            options.EnableDetailedErrors();
        }

            

    }); 


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


