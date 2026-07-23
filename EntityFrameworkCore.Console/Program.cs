//Console.WriteLine("Hello, World!");

using EntityFrameworkCore.Data;
using Microsoft.EntityFrameworkCore;

using var context = new FootballLeagueDbContext();

Console.WriteLine(context.DbPath);
//select * from teams
//GetAllTeams();

//var team1 = await context.Teams.FirstAsync();

//var tema2 = await context.Teams.FirstAsync(team => team.Id == 1);

//var team3 =  context.Teams.FirstOrDefault(team => team.Id == 2);

//var teamBasedOnId = await context.Teams.FindAsync(3);


//filtering
//select all record that meet condition


//await GetFilteredTeams();

//await GetAllTeamsQuerySyntax();

//AGRIGATE METHODS
// COUNT
//var numberOfTeams = await context.Teams.CountAsync();
//Console.WriteLine($"Number of Teams: { numberOfTeams}");

//var numberofTeamWithCondition = await context.Teams.CountAsync(q => q.Id == 1);
//Console.WriteLine($"Number of Teams with condition above: { numberofTeamWithCondition}");


////MAX
//var maxTeams = await context.Teams.MaxAsync(q => q.Id);


//TOPIC: SKIP AND TAKE

//Console.WriteLine(await context.Teams.CountAsync());




async Task SkipAndTake()
{
    var recordCount = 3;
    var page = 0;
    var next = true;

    while (next)
    {
        var teams = await context.Teams.Skip(page * recordCount).Take(recordCount)
            .ToListAsync();
        foreach (var team in teams)
        {
            Console.WriteLine(team.Name);
        }
        Console.WriteLine("enter true for next set, and 'false' to exit");
        next = Convert.ToBoolean(Console.ReadLine());

        if (!next) break;
        page += 1;
    }

}

void GroupByMethod()
{
    var groupTeams = context.Teams

        .GroupBy(q => new { q.CreatedDate.Date });

    foreach (var group in groupTeams)
    {
        Console.WriteLine(group.Key);
        Console.WriteLine(group.Sum(q => q.Id));

        foreach (var team in group)
        {
            Console.WriteLine(team.Name);
        }
    }

}


async Task GetAllTeamsQuerySyntax()
{
    Console.WriteLine("enter team to find: ");
    var searchTerm = Console.ReadLine();

    var teams = await (from team in context.Teams 
                       where EF.Functions.Like(team.Name, $"{searchTerm}")
                       select team
                       ).ToListAsync();

    foreach(var t in teams)
    {
        Console.WriteLine(t.Name);
    }
}

async Task GetFilteredTeams()
{
    Console.WriteLine("enter team to find: ");
    var searchTerm = Console.ReadLine();
    var teamFiltered = await context.Teams.Where(q => q.Name == searchTerm)
    .ToListAsync();

    foreach (var item in teamFiltered)
    {
        Console.WriteLine(item.Name);
    }
    //var partialMatches = await context.Teams.Where(q => q.Name.Contains(searchTerm))
    //    .ToListAsync();
        var partialMatches = await context.Teams.Where(q => EF.Functions.Like(q.Name , $"{searchTerm}"))
        .ToListAsync();

    foreach (var item in partialMatches)
    {
        Console.WriteLine(item.Name);
    }
}

async Task GetAllTeams()
{

    var teams = await context.Teams.ToListAsync();


    foreach (var t in teams)
    {
        Console.WriteLine($"these are the names of teams; {t.Name}");
    }

}


async Task GetOneTeam()
{
    //Selecting a single record -First one in the list
    var teamFirst = await context.Coaches.FirstAsync();
    if (teamFirst != null)
    {
        Console.WriteLine(teamFirst.Name);
    }
    var teamFirstOrDefault = await context.Coaches.FirstOrDefaultAsync();
    if (teamFirstOrDefault != null)
    {
        Console.WriteLine(teamFirstOrDefault.Name);
    }

    //Selecting a single record -First one in the list that meets a condition
    var teamFirstWithCondition = await context.Teams.FirstAsync(team => team.Id == 1);
    if (teamFirstWithCondition != null)
    {
        Console.WriteLine(teamFirstWithCondition.Name);
    }
    var teamFirstOrDefaultWithCondition = await context.Teams.FirstOrDefaultAsync(team => team.Id == 1);
    if (teamFirstOrDefaultWithCondition != null)
    {
        Console.WriteLine(teamFirstOrDefaultWithCondition.Name);
    }

    //Selecting a single record -Only one record should be returned, or an exception will be thrown
    var teamSingle = await context.Teams.SingleAsync();
    if (teamSingle != null)
    {
        Console.WriteLine(teamSingle.Name);
    }
    var teamSingleWithCondition = await context.Teams.SingleAsync(team => team.Id == 2);
    if (teamSingleWithCondition != null)
    {
        Console.WriteLine(teamSingleWithCondition.Name);
    }
    var SingleOrDefault = await context.Teams.SingleOrDefaultAsync(team => team.Id == 2);
    if (SingleOrDefault != null)
    {
        Console.WriteLine(SingleOrDefault.Name);
    }

    //Selecting based on Primary Key Id value
    var teamBasedOnId = await context.Teams.FindAsync(3);
    if (teamBasedOnId != null)
    {
        Console.WriteLine(teamBasedOnId.Name);
    }
}


