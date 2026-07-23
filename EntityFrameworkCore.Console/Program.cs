//Console.WriteLine("Hello, World!");

using EntityFrameworkCore.Data;
using Microsoft.EntityFrameworkCore;

using var context = new FootballLeagueDbContext();

//select * from teams
GetAllTeams();

var team1 = await context.Teams.FirstAsync();

var tema2 = await context.Teams.FirstAsync(team => team.Id == 1);

var team3 =  context.Teams.FirstOrDefault(team => team.Id == 2);

void GetAllTeams()
{

    var teams = context.Teams.ToList();


    foreach (var t in teams)
    {
        Console.WriteLine($"these are the names of teams; {t.Name}");
    }

}