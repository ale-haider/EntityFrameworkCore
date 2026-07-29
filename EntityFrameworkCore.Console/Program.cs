//Console.WriteLine("Hello, World!");

using EntityFrameworkCore.Data;
using EntityFrameworkCore.Domain;
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
/* //ML Stanford
 *
 * z-score
 plot the trainng data 
aim for abou -1 to 1 acceptable range
-100 to 100  not acceptable

 G-D FOR CONVERGENCE
 curve j is leveing up and then flatened out 
epsilon be 10^3
found parameters w,b to get close to global minimum

 //OVERFITTINF
overfitting == high variance
underfitting == high bias

// ADDRESSING OVERFITTING
1. collect more training examples

2.select features to include that are only relavent
by feature selection

3. reduce the size by using regulalization

//REGULARIZATION
set a parameter to zero == eliminating a feature

Cost function with regularization
increasing size of lamda  => decrease the features of the data

Gradient descent with regularization

Regularized logistic regression

///NERUAL NETWORK LAYER
layers 
pridicts based on what is provided

layer dont include the input layer 0

aj[l] = g (wj[l] . a->a[l-1] + bj[l]

//// MAKING PREDICTION (FORWARD PROPAGATION) 
1ST layer 25 units
2nd layer 15 units 
3rd layer 1 unit

*/
////INFERENCE IN CODE
/// X = mnp.array ([[200.0 , 17.0]])
/// layer_1 = Dense(units = 3, activation = 'sigmoid')
/// a1 = layer1(x)
/// 2*3 matrix 
/// x = np.array ([[1 2],
///                 [3 4],
///                 [5 6]])
///  2D Matrix
///  forward propagation or infrence
///  tf.Tensor 9[[ 27 3]], shape = (1,3 ), dtype = float = 32)
///  a1.numpy()
///  tensorflow can string the layers directly to neural netwrok
///  model = sequential*[ layer_1 , layer_2])
/// model.fit(x,y)
/// model.predict
/// def dense(a_in ,w, b):
///     w - np.array([[ ],[ ], [ ] ,])
///     imots = w.shape [1]
///     a-out = np.zwros(units)
///     for j in range(units) :
///     w = 2[: , j]
///     z = np.dot(w , a_in)  + b[j]
///     a_out[j] = g(z)
///     return a_out
///  

////AGI
/// ANI( artificial narroow intellegence )=> can do a narrow task very well
/// AGI ( artificail general intellegence) => can do anything a human can do
////HOW NEURAL NEWWORK ARE IMPLEMETNED EFFICIENTLY
///

////TENSORFLOW IMPLEMENTAION 
/// 









//// NO TRACKTING -EF CORE TRACKS OBJECTS THAT ARE RETUREND BY QUERIES
///discontineous lik API

///var teams = await context.Teams
///    .AsNoTracking()
///    //for readonly
///   .ToListAsync();

///foreach (var t in teams)
///{
///    Console.WriteLine($"{t.Name}");
///}

async Task FindingFunction()
{

    Console.WriteLine("enter 1 for team id with 1 for teams that contain 'F C' type '2'");
    var option = Convert.ToInt32(Console.ReadLine());
    List<Team> teamAsList = new List<Team>();

    teamAsList = await context.Teams.ToListAsync();

    if (option == 1)
    {
        teamAsList = teamAsList.Where(q => q.Id == 1).ToList();
    }
    else if (option == 2)
    {
        teamAsList = teamAsList.Where(q => q.Name.Contains("F.C.")).ToList();
    }
    foreach (var t in teamAsList)
    {
        Console.WriteLine(t.Name);

    }
}

async Task FindingQuerable()
{
    Console.WriteLine("enter 1 for team id with 1 for teams that contain 'F C' type '2'");
    var option = Convert.ToInt32(Console.ReadLine());
    List<Team> teamAsList = new List<Team>();

    teamAsList = await context.Teams.ToListAsync();

    var teamAsQueryable = context.Teams.AsQueryable();
    if (option == 1)
    {
        teamAsQueryable = teamAsQueryable.Where(q => q.Id == 1);
    }
    else if (option == 2)
    {
        teamAsQueryable = teamAsQueryable.Where(q => q.Name.Contains("F.C."));
    }
    foreach (var t in teamAsQueryable)
    {
        Console.WriteLine(t.Name);
    }
}




 



async Task ProjectionAndSelection()
{

    var teamNames = await context.Teams
        //.Select(q => new(name = q.Name, Date = q.CreatedDate )
        .ToListAsync();
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
//
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


//📝CRUD OPOERATIONS

////EXECUTE DELETE
async Task ExecuteDelet()
{
    var coaches = await context.Coaches.Where(q => q.Name == "Theodore Whitmore")
        .ExecuteDeleteAsync();
}
//EXECUTE UPDATE
async Task ExecuteUpdate()
{
    var coaches = await context.Coaches.Where(q => q.Name == "Jose Mourineo")
        .ExecuteUpdateAsync(set => set
        .SetProperty(prop => prop.Name, "Pep Guardiola")
        //.SetProperty(prop => prop.CreatedDate, DateTime.Now)
        );
}

//DELETE OPERATION
async Task DeleteRecord()
{
    var coach = await context.Coaches.FindAsync(3);
    //context.Remove(coach);
    context.Entry(coach).State = EntityState.Deleted;
    await context.SaveChangesAsync();
}

//UPDATE OPERATION
async Task UpdateWithTracking()
{
    var coach = await context.Coaches.FindAsync(5);

    coach.Name = "Ali Haider";
    coach.CreatedDate = DateTime.Now;
    await context.SaveChangesAsync();
}
//if tracking not enabled then update
async Task UpdateWithNoTracking()
{
    var coach1 = await context.Coaches
        .AsNoTracking()
        .FirstOrDefaultAsync(q => q.Id == 5);
    coach1.Name = "testin no tracking"; 

    Console.WriteLine(context.ChangeTracker.DebugView.LongView);
    context.Update(coach1);
    Console.WriteLine(context.ChangeTracker.DebugView.LongView);
    await context.SaveChangesAsync();
    Console.WriteLine(context.ChangeTracker.DebugView.LongView);
}
//INSERTING DATA
//SIMPLE INSERT

//await InsertOneRecord();
async Task InsertOneRecord()
{
    var newCoach = new Coach
    {
        Name = "Jose Mourineo",
        CreatedDate = DateTime.Now,
    };
    await context.Coaches.AddAsync(newCoach);
    await context.SaveChangesAsync();
}


////LOOP INSERT
async Task InsertWithLoop()
{
    var newCoach1 = new Coach
    {
        Name = "Theodore Whitmore",
        CreatedDate = DateTime.Now,
    };
    var newCoach = new Coach
    {
        Name = " Jose Mourineo",
        CreatedDate = DateTime.Now,
    };

    List<Coach> coaches = new List<Coach>
{
    newCoach1,
    newCoach,
};

    foreach (var coach in coaches)
    {
        await context.Coaches.AddAsync(coach);

    }
    Console.WriteLine(context.ChangeTracker.DebugView.LongView);
    await context.SaveChangesAsync();
    Console.WriteLine(context.ChangeTracker.DebugView.LongView);

}
    //BATCH INSERT

async Task InsertRange()
{
    var newCoach1 = new Coach
    {
        Name = " Theodore Whitmore",
        CreatedDate = DateTime.Now,
    };
    var newCoach = new Coach
    {
        Name = " Jose Mourineo",
        CreatedDate = DateTime.Now,
    };

    List<Coach> coaches = new List<Coach>
{
    newCoach1,
    newCoach,
};

    await context.Coaches.AddRangeAsync(coaches);
    await context.SaveChangesAsync();
}


//MODULE 6
//HANDLING DATABASE CHANGES AND MIGRATIONS

//await context.Database.MigrateAsync(); //TO auto apply migrations that are pending


#region Related Data

#endregion
//// Lazy loading //  IT IS HIGHLY DISCOURGAED AS IT SLOWS DOWN DATA LOADING

//var league = await context.FindAsync<League>(1);

//foreach ( var team in league.Teams)
//{
//    Console.WriteLine(team.Name);
//}


//foreach (var league in  context.Leagues)
//{
//    foreach(var team in league.Teams)
//    {
//        Console.WriteLine($" {team.Name} - {team.Coach.Name}");
//    }

//}



////📝FILTRING INCLUDES
////GET ALL TEAMS AND ONLY HOME MATCHES WHERE THERY HAVE SCORED
//// AWAIT INSETMOREMATCHES();

//async Task getAllTeamsWithLeagueCoachAndScores();
//{
//    var teams = await context.Teams

//        .Include("Coach")
//        .Include(q => q.HomeMatches.Where(q => q.HomeTeamScore > 0))
//        .ToArrayAsync();


//    foreach (var team in teams)
//    {
//        Console.WriteLine($"{team.Name} - {team.Coach.Name}");
//        foreach (var match in team.HomeMatches)
//        {
//            Console.WriteLine($" Score {match.HomeTeamScore}");
//        }

//    }

//}


// explicit loading
async Task ExplicitLoading()
{
    var league = await context.FindAsync<League>(1);
    if (league.Teams.Any())
    {
        Console.WriteLine("Teams have not been loaded ");

    }

    await context.Entry(league)
        .Collection(q => q.Teams)
        .LoadAsync();

    if (league.Teams.Any())
    {
        Console.WriteLine("Teams have not been loaded ");

        foreach (var team in league.Teams)
        {
            Console.WriteLine($"Teams are: {team.Name}");
        }
    }

}




async Task EgerLoadingGetData()
{
    var leagues = await context.Leagues
        //.Include("Teams")    
        .Include(q => q.Teams)
            .ThenInclude(q => q.Coach)
        .ToListAsync();

    foreach (var league in leagues)
    {
        Console.WriteLine($"League: {league.Name}");
        foreach (var team in league.Teams)
        {
            Console.WriteLine($"Teams are: {team.Name} and Coach is {team.Coach.Name}");
        }
    }
}


async Task InsertMoreMatch()
{
    ////INSETTING RELATED DATA
    ////INSERT RECORD WITH FK
    var match1 = new Match
    {
        AwayTeamId = 2,
        HomeTeamId = 3,
        HomeTeamScore = 1,
        AwayTeamScore = 0,
        Date = new DateTime(2026, 10, 1),
        TicketPrice = 20,
    };


    var match2 = new Match
    {
        AwayTeamId = 2,
        HomeTeamId = 1,
        HomeTeamScore = 1,
        AwayTeamScore = 0,
        Date = new DateTime(2026, 10, 1),
        TicketPrice = 20,
    };


    var match3 = new Match
    {
        AwayTeamId = 1,
        HomeTeamId = 3,
        HomeTeamScore = 1,
        AwayTeamScore = 0,
        Date = new DateTime(2026, 10, 1),
        TicketPrice = 20,
    };


    var match4 = new Match
    {
        AwayTeamId = 4,
        HomeTeamId = 3,
        HomeTeamScore = 0,
        AwayTeamScore = 1,
        Date = new DateTime(2026, 10, 1),
        TicketPrice = 20,
    };

    await context.AddRangeAsync(match1,match2, match3, match4);
    await context.SaveChangesAsync();
}

async Task InsertTeam ()
{
    ////// insert parent/ Child
    //var team = new Team
    //{
    //    Name = "New Team",
    //    Coach = new Coach
    //    {
    //        Name = "Jhonson"
    //    },

    //};


    //await context.AddAsync(team);
    //await context.SaveChangesAsync();

}

async Task InsertLeague()
{ 
// insert parent with childre

var league = new League
{
    Name = "Serie A",

    Teams = new List<Team>
    {
        new Team{
        Name = "Juventus",
            Coach = new Coach
            {
                Name = "Juve Coach"
            }
        },
        new Team{
        Name = "AC MIlan",
            Coach = new Coach
            {
                Name = "William"
            }
        },
        new Team{
        Name = "AS Roma",
            Coach = new Coach
            {
                Name = "Roma Coach"
            }
        },
    }

};

await context.AddAsync(league);
await context.SaveChangesAsync();
}



#region RAW SQL
var details = await context.TeamsAndLeaguesView.ToListAsync();

#endregion



////PROJECTIONS AND ANONYMUS DATA TYPES

async Task Projection()
{

    var tesms = await context.Teams
        .Select(q => new TeamDetails
        {
            TeamId = q.Id,
            TeamName = q.Name,
            CoachName = q.Coach.Name,
            TotalHomeGoal = q.HomeMatches.Sum(x => x.HomeTeamScore),
            TotalAwayGoal = q.AwayMatches.Sum(x => x.AwayTeamScore),

        })
        .ToListAsync();

    foreach (var team in tesms)
    {
        Console.WriteLine($"{team.TeamName} - {team.CoachName} | Home Goals: {team.TotalHomeGoal} | Away Goals: {team.TotalAwayGoal}");

    }

}


