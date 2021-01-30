using System;
using System.Linq;
using static FootballDataSource.FootballData;
using FootballModels;
using System.Collections.Generic;

namespace LinqRjaka2
{
    class Program
    {
        static void Main(string[] args)
        {
            #region(Тут первое)
            Console.WriteLine("\n1.Количество нападающих по странам\n");
            var attakersInCountry = from p in Players
                                    where p.Position == "Forward"
                                    group p by p.Country into k
                                    select new
                                    {
                                        Country = k.Key,
                                        Count = k.Count()
                                    };


            foreach (var item in attakersInCountry)
            {
                Console.WriteLine($"Country = {item.Country} , Количество футбольщиков = {item.Count}");
            }
            var attackersInCountry2 = Players
                .Where(p => p.Position == "Forward")
                .GroupBy(p => p.Country)
                .Select(p => new { Country = p.Key, Count = p.Count() })
                .ToList();

            foreach (var item in attackersInCountry2)
            {
                Console.WriteLine($"Country = {item.Country} , Количество футбольщиков = {item.Count}");
            }
            #endregion
            #region(Тут второе)
            Console.WriteLine("\n2. Сколько было забито голов на каждом стадионе\n");
            var goalsInStadium = from match in Matches
                                 join stad in Stadiums on match.StadionId equals stad.Id
                                 group match by stad.Name + " - " + stad.City into p
                                 let sum = p.Sum(g => g.GuestTeamGoals + g.HomeTeamGoals)
                                 select new
                                 {
                                     Name = p.Key,
                                     Count = sum
                                 };
            foreach (var item in goalsInStadium)
            {
                Console.WriteLine($"{item.Name} - {item.Count}");
            }

            var goalsInStadium1 = Matches
                .Join(Stadiums, m => m.StadionId, s => s.Id, (m, s) => new
                {
                    s.Name,
                    s.City,
                    m.GuestTeamGoals,
                    m.HomeTeamGoals
                })
                .GroupBy(s => s.Name + " - " + s.City)
                .Select((s) => new
                {
                    Name = s.Key,
                    Count = s.Sum(g => g.GuestTeamGoals + g.HomeTeamGoals)
                }).ToList();
            foreach (var item in goalsInStadium1)
            {
                Console.WriteLine($"{item.Name} - {item.Count}");
            }
            #endregion
            #region (Тут третье)
            Console.WriteLine("\n#3 стадион на котором было забито больше всего голов\n");
            var stadiumGoalsMax = (from match in Matches
                                   join stadiums in Stadiums on match.StadionId equals stadiums.Id
                                   group match by stadiums.Name into allgoals
                                   let goal = allgoals.Sum(g => (g.GuestTeamGoals + g.HomeTeamGoals))
                                   orderby goal
                                   select new
                                   {
                                       name = allgoals.Key,
                                       maxGoal = goal
                                   }).ToList().Last();

            Console.WriteLine($"Максимальное количество голов: {stadiumGoalsMax}");


            var stadiumGoalsMax1 = Matches
                .Join(Stadiums, m => m.StadionId, s => s.Id, (m, s) => new
                {
                    s.Name,
                    m.GuestTeamGoals,
                    m.HomeTeamGoals
                })
                .GroupBy(m => m.Name)
                .Select((ma) => new
                {
                    Name = ma.Key,
                    MaxCount = ma.Sum(g => g.GuestTeamGoals + g.HomeTeamGoals)
                }).
                OrderBy(m => m.MaxCount).
                ToList().
                Last();
            Console.WriteLine(stadiumGoalsMax1);
            #endregion
            #region(Тут четвертое)            
            Console.WriteLine("\n4.Вывести всех людей относящихся к команде вместе с их должностями.\n");

            var playersInTeams = (from player in Players
                                  select new
                                  {
                                      player.FirstName,
                                      player.LastName,
                                      Position = "Игрок - " + player.Position,
                                      player.TeamId
                                  }).ToList();

            var workerNew = (from w in Workers
                             select new
                             {
                                 w.FirstName,
                                 w.LastName,
                                 Position = "Работник - " + w.Position,
                                 w.TeamId
                             }).ToList();

            foreach (var worker in workerNew)
            {
                playersInTeams.Add(worker);
            }

            var teamsAndPlayers = from player in playersInTeams
                                  join team in Teams on player.TeamId equals team.Id
                                  select new
                                  {
                                      Team = team.Title,
                                      player.TeamId,
                                      player.FirstName,
                                      player.LastName,
                                      player.Position
                                  } into playerInTeams
                                  group playerInTeams by playerInTeams.TeamId into grouppedPlayers
                                  select new
                                  {
                                      Team = grouppedPlayers.ToList()[0].Team,
                                      Players = (from p in grouppedPlayers
                                                 select new
                                                 {
                                                     p.FirstName,
                                                     p.LastName,
                                                     p.Position
                                                 }).ToList()
                                  };
            foreach (var item in teamsAndPlayers)
            {
                Console.WriteLine($"{item.Team} ");
                foreach (var person in item.Players)
                {
                    Console.WriteLine($"\t{person.FirstName} {person.LastName} Позиция: {person.Position}");
                }
            }

            var NewPlayers = (Players
                .Select(p => new
                {
                    p.FirstName,
                    p.LastName,
                    Position = "Игрок - " + p.Position,
                    p.TeamId
                })).ToList();

            var NewWorkers = (Workers
                .Select(w => new
                {
                    w.FirstName,
                    w.LastName,
                    Position = "Работник - " + w.Position,
                    w.TeamId
                }).Union(NewPlayers)).ToList();



            var teamToList = (NewWorkers
            .Join(Teams, allteam => allteam.TeamId, team => team.Id,
            (allteam, team) => new
            {
                Team = team.Title,
                allteam.TeamId,
                allteam.FirstName,
                allteam.LastName,
                allteam.Position
            })
            .GroupBy(grouppedPlayers => grouppedPlayers.TeamId)
            .Select(grouppedPlayers => new
            {
                Key = grouppedPlayers.ToList()[0].Team,
                PlayersWorkers = (from players in grouppedPlayers
                                  select new
                                  {
                                      players.FirstName,
                                      players.LastName,
                                      players.Position
                                  }).ToList()
            })).ToList();

            foreach (var team in teamToList)
            {
                Console.WriteLine($"Команда - {team.Key} \n");
                foreach (var person in team.PlayersWorkers)
                {
                    Console.WriteLine($"Игрок - {person.FirstName} {person.LastName}\n " +
                        $"Позиция: {person.Position}");
                }
                Console.WriteLine("\n\n");
            }


            #endregion
            #region(тут пятое)
            Console.WriteLine("\n5.Судьи и их матчи, в формате группировки\n");
            var matches = (from match in Matches
                           join guestTeam in Teams on match.GuestTeamId equals guestTeam.Id
                           join homeTeam in Teams on match.HomeTeamId equals homeTeam.Id
                           join stadium in Stadiums on match.StadionId equals stadium.Id
                           select new
                           {
                               MatchId = match.Id,
                               MatchDate = match.MatchDate,
                               Stadium = stadium.Name,
                               HomeTeam = homeTeam.Title,
                               GuestTeam = guestTeam.Title,

                           }).ToList();

            var matchAndRefree = (from matchAndRef in MatchesAndReferees
                                  join referee in Referees on matchAndRef.RefereeId equals referee.Id
                                  join match in matches on matchAndRef.MatchId equals match.MatchId
                                  select new
                                  {
                                      Referee = referee.FirstName + " " + referee.LastName,
                                      Match = match
                                  }).ToList();

            var groupedMatchesAndRefrees = (from matchAndRef in matchAndRefree
                                            group matchAndRef.Match by matchAndRef.Referee);

            foreach (var item in groupedMatchesAndRefrees)
            {
                Console.WriteLine("\nСудья - " + item.Key + "\n");
                foreach (var match in item)
                {
                    Console.WriteLine($"Матч: {match.MatchId}\n" +
                        $"Время матча: {match.MatchDate}\n" +
                        $"Стадион: {match.Stadium}\n" +
                        $"Домашиняя команда: {match.HomeTeam}\n" +
                        $"Гостевая команда: {match.GuestTeam}\n");
                }
            }
            var matches2 = Matches
                .Join(Teams, m => m.GuestTeamId, t => t.Id, (m, t) => new
                {
                    m.Id,
                    GuestTeam = t.Title,
                    m.HomeTeamId,
                    m.IsFinished,
                    m.MatchDate,
                    m.StadionId
                }).Join(Teams, m => m.HomeTeamId, t => t.Id, (m, t) => new
                {
                    m.Id,
                    m.GuestTeam,
                    HomeTeam = t.Id,
                    m.IsFinished,
                    m.MatchDate,
                    m.StadionId
                }).Join(Stadiums, m => m.StadionId, s => s.Id, (m, s) => new
                {
                    m.Id,
                    m.GuestTeam,
                    m.HomeTeam,
                    m.IsFinished,
                    m.MatchDate,
                    Stadium = s.Name
                });
            var referee2 = Referees
                .Join(MatchesAndReferees, r => r.Id, m => m.RefereeId, (r, m) => new
                {
                    Referee = r.FirstName + " " + r.LastName,
                    m.MatchId
                }).Join(matches2, r => r.MatchId, m => m.Id, (r, m) => new
                {
                    Referee = r.Referee,
                    ID = m.Id,
                    LIVE = m.IsFinished,
                    Date = m.MatchDate,
                    Stadium = m.Stadium,
                    HomeTeam = m.HomeTeam,
                    GuestTeam = m.GuestTeam

                }).GroupBy(m => m.Referee);

            foreach (var item in referee2)
            {
                Console.WriteLine("\nСудья - " + item.Key + "\n");
                foreach (var match in item)
                {
                    Console.WriteLine($"Матч: {match.ID}\n" +
                        $"Время матча: {match.Date}\n" +
                        $"Стадион: {match.Stadium}\n" +
                        $"Домашиняя команда: {match.HomeTeam}\n" +
                        $"Гостевая команда: {match.GuestTeam}\n");
                }

            }

            #endregion
            #region(тут шестое)
            Console.WriteLine("\n6.Сгруппировать игроков по командам и их позициям позициям\n");
            var playerByTeamsAndPos = (from player in Players
                                       join team in Teams on player.TeamId equals team.Id
                                       group player by team.Title into playerByTitle
                                       select new
                                       {
                                           TeamTitle = playerByTitle.Key,
                                           Player = (from player in playerByTitle
                                                     select new
                                                     {
                                                         PlayerName = player.LastName + " " + player.FirstName,
                                                         Position = player.Position
                                                     }
                                                     into playerByTeamTitle
                                                     group playerByTeamTitle.PlayerName by playerByTeamTitle.Position)
                                       }).ToList();

            foreach (var team in playerByTeamsAndPos)
            {
                Console.WriteLine("Команда: " + team.TeamTitle + "\n");
                foreach (var pos in team.Player)
                {
                    Console.WriteLine("\tПозиция: " + pos.Key);
                    foreach (var player in pos)
                    {
                        Console.WriteLine("\t\t " + player + "\n");
                    }
                }
            }

            var teamPositionPlayers = Players
                .Join(Teams, p => p.TeamId, t => t.Id, (p, t) => new
                {
                    Team = t.Title,
                    PlayerAndTeam = p
                })
                .GroupBy(playerItTeams => playerItTeams.Team)
                .Select(playerItTeams => new
            {
                playerItTeams.Key,
                Grouping = playerItTeams.ToList().GroupBy(playerItTeams => playerItTeams.PlayerAndTeam.Position)
            }).ToList();
            foreach (var team in teamPositionPlayers)
            {
                Console.WriteLine("Команда: " + team.Key);
                foreach (var position in team.Grouping)
                {
                    Console.WriteLine("\tПозиция: " + position.Key);
                    foreach (var player in position)
                    {
                        Console.WriteLine($"\t\t {player.PlayerAndTeam.FirstName} {player.PlayerAndTeam.LastName}");
                    }
                }
                Console.WriteLine();
            }
            #endregion
        }
    }
}

