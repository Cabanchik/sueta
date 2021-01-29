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
            ///1. Количество нападающих по странам 
            //var attakersInCountry = from p in Players
            //                        where p.Position == "Forward"
            //                        group p by p.Country into k
            //                        select new
            //                        {
            //                            Country = k.Key,
            //                            Count = k.Count()
            //                        };


            //foreach (var item in attakersInCountry)
            //{
            //    Console.WriteLine($"Country = {item.Country} , Количество футбольщиков = {item.Count}");
            //}
            //var attackersInCountry2 = Players.Where(p => p.Position == "Forward")
            //    .GroupBy(p => p.Country)
            //    .Select(p => new { Country = p.Key, Count = p.Count() })
            //    .ToList();

            //foreach (var item in attackersInCountry2)
            //{
            //    Console.WriteLine($"Country = {item.Country} , Количество футбольщиков = {item.Count}");
            //}
            #endregion
            #region(Тут второе)
            ////2. Сколько было забито голов на каждом стадионе
            //var goalsInStadium = from match in Matches
            //                     join stad in Stadiums on match.StadionId equals stad.Id
            //                     group match by stad.Name + " - " + stad.City into p
            //                     let sum = p.Sum(g => g.GuestTeamGoals + g.HomeTeamGoals)
            //                     select new
            //                     {
            //                         Name = p.Key,
            //                         Count = sum
            //                     };
            //foreach (var item in goalsInStadium)
            //{
            //    Console.WriteLine($"{item.Name} - {item.Count}");
            //}

            //var goalsInStadium1 = Matches
            //    .Join(Stadiums, m => m.StadionId, s => s.Id, (m, s) => new
            //    {
            //        s.Name,
            //        s.City,
            //        m.GuestTeamGoals,
            //        m.HomeTeamGoals
            //    })
            //    .GroupBy(s => s.Name + " - " + s.City)
            //    .Select((s) => new
            //    {
            //        Name = s.Key,
            //        Count = s.Sum(g => g.GuestTeamGoals + g.HomeTeamGoals)
            //    }).ToList();
            //foreach (var item in goalsInStadium1)
            //{
            //    Console.WriteLine($"{item.Name} - {item.Count}");
            //}
            #endregion
            #region (Тут третье)
            //#3 стадион на котором было забито больше всего голов
            //var stadiumGoalsMax = (from matches in Matches
            //                       join stadiums in Stadiums on matches.StadionId equals stadiums.Id
            //                       group matches by stadiums.Name into allgoals
            //                       let goal = allgoals.Sum(g => (g.GuestTeamGoals + g.HomeTeamGoals))
            //                       orderby goal
            //                       select new
            //                       {
            //                           name = allgoals.Key,
            //                           maxGoal = goal
            //                       }).ToList().Last();

            //Console.WriteLine($"Максимальное количество голов: {stadiumGoalsMax}");


            //var stadiumGoalsMax1 = Matches
            //    .Join(Stadiums, m => m.StadionId, s => s.Id, (m, s) => new 
            //    {
            //        s.Name, 
            //        m.GuestTeamGoals, 
            //        m.HomeTeamGoals 
            //    })
            //    .GroupBy(m => m.Name)
            //    .Select((ma) => new
            //    {
            //        Name = ma.Key,
            //        MaxCount = ma.Sum(g => g.GuestTeamGoals + g.HomeTeamGoals)
            //    }).
            //    OrderBy(m => m.MaxCount).
            //    ToList().
            //    Last();
            //Console.WriteLine(stadiumGoalsMax1);
            #endregion
            #region(Тут четвертое)
            //4.Вывести всех людей относящихся к команде вместе с их должностями.
            //var workerInTeams = (from worker in Workers
            //                      select new
            //                      {
            //                          worker.FirstName,
            //                          worker.LastName,
            //                          worker.Position,
            //                          worker.TeamId
            //                      }).ToList();
            //var playersInTeams = (from player in Players
            //                     select new
            //                     {
            //                         player.FirstName,
            //                         player.LastName,
            //                         Position = "Игрок - " + player.Position,
            //                         player.TeamId
            //                     }).ToList();


            //var teamsAndPlayers = (from player in playersInTeams
            //                      join worker in workerInTeams on player.TeamId equals worker.TeamId
            //                      group player by worker.TeamId into result
            //                      select new
            //                      {
            //                          TeamID = result.Key,
            //                          People = (from p in result
            //                                   select new
            //                                   {
            //                                       p.FirstName,
            //                                       p.LastName,
            //                                       p.Position
            //                                   }).ToList()
            //                      }).ToList();
            //foreach (var item in teamsAndPlayers)
            //{
            //    Console.WriteLine($"{item.TeamID} люди: ");
            //    foreach (var person in item.People)
            //    {
            //        Console.WriteLine($"\t{person.FirstName} {person.LastName} Позиция: {person.Position}");
            //    }
            //}
            //foreach (var item in teamsAndPLayers1)
            //{
            //    Console.WriteLine($"Команда - {item.Team}\n" +
            //    $"Должность сотрудника - {item.Post}\n" +
            //    $"Сотрудник - {item.WorkerName} {item.WorkerSurname}\n" +

            //    $"Игрок - {item.PlayerName} {item.PlayerLastname}\n");

            //}

            #endregion
            #region(тут пятое)

            var refereesAndMatches = (from referee in Referees
                                      join match in MatchesAndReferees on referee.Id equals match.RefereeId
                                      select new
                                      {
                                          RefereeId = referee.Id,
                                          MatchId = match.MatchId,
                                          Name = referee.FirstName,
                                          Surname = referee.LastName
                                      }).ToList();
            var matchesAndReferees = (from match in Matches
                                      join referee in MatchesAndReferees on match.Id equals referee.MatchId
                                      join stadium in Stadiums on match.StadionId equals stadium.Id
                                      select new
                                      {
                                          IdMatch = match.Id,
                                          Date = match.MatchDate,
                                          HomeTeam = match.HomeTeamId,
                                          GuestTeam = match.GuestTeamId,
                                          isFinished = match.IsFinished,
                                          match.StadionId,
                                          Stadium = stadium.Name

                                      }).ToList();
            var group = (from referee in refereesAndMatches
                         join match in matchesAndReferees on referee.MatchId equals match.IdMatch
                         group referee by referee.Name + " " + referee.Surname into res
                         select new
                         {
                             RefereeName = res.Key,
                             InfoAboutMatch = (from match in matchesAndReferees
                                               select new
                                               {
                                                   IdMatch = match.IdMatch,
                                                   Date = match.Date,
                                                   Stadium = match.Stadium,
                                                   HomeTeam = match.HomeTeam,
                                                   GuestTeam = match.GuestTeam,
                                                   isFinished = match.isFinished
                                               }).ToList()

                         }).ToList();
            foreach (var item in group)
            {
                Console.WriteLine($"Судья: {item.RefereeName}\n");
                foreach (var i in item.InfoAboutMatch)
                {
                    Console.WriteLine($"ID Матча: {i.IdMatch}\n" +
                                        $"Дата проведения матча: {i.Date}\n" +
                                        $"Стадион проведения: {i.Stadium}\n" +
                                        $"Домашняя команда: {i.HomeTeam},\n" +
                                        $"Команда-Гость: {i.GuestTeam},\n" +
                                        $"Закончился ли матч:{i.isFinished}\n");
                }
            }

            #endregion
            #region(тут шестое)
            ////6.Сгруппировать игроков по командам и их позициям позициям
            //var playersInTeams2 = from t in Teams
            //                      join p in Players on t.Id equals p.TeamId
            //                      select new
            //                      {
            //                          Team = t.Id,
            //                          Position = p.Position,
            //                          PlayerName = p.FirstName,
            //                          PlayerSurname = p.LastName
            //                      };
            //var groppedPositions = from t in Teams
            //                       join p in playersInTeams2 on t.Id equals p.Team
            //                       group p by t.Title into ss
            //                       select new
            //                       {
            //                           Team = ss.Key,
            //                           Player = from l in ss
            //                                    select new
            //                                    {
            //                                        PlayerName = l.PlayerName + " " + l.PlayerSurname,
            //                                        l.Position
            //                                    } into k
            //                                    group k.PlayerName by k.Position
            //                       };
            //foreach (var item in groppedPositions)
            //{
            //    Console.WriteLine(item.Team);
            //    foreach (var item2 in item.Player)
            //    {
            //        Console.WriteLine("\t" + item2.Key);
            //        foreach (var item3 in item2)
            //        {
            //            Console.WriteLine("\t\t" + item3);
            //        }
            //    }
            //}

            //var playersInTeams3 = Teams.Join(Players, t => t.Id, p => p.TeamId, (t, p) => new
            //{
            //    Team = t.Id,
            //    Position = p.Position,
            //    PlayerName = p.FirstName,
            //    PlayerSurname = p.LastName
            //}).ToList();
            //var groppedPositions1 = Teams.Join(playersInTeams3, t => t.Id, p => p.Team, (t, p) => new
            //{
            //    Team = t.Title,
            //    Name = p.PlayerName,
            //    Surname = p.PlayerSurname,
            //    p.Position
            //}).GroupBy(p => p.Team).Select((p) => new
            //{
            //    Team = p.Key,
            //    Player = p.Select(l => new
            //    {
            //        PlayerName = l.Name + " " + l.Surname,
            //        l.Position
            //    }).GroupBy(k => k.Position)
            //}).ToList();
            //foreach (var item in groppedPositions1)
            //{
            //    Console.WriteLine(item.Team);
            //    foreach (var item2 in item.Player)
            //    {
            //        Console.WriteLine("\t" + item2.Key);
            //        foreach (var item3 in item2)
            //        {
            //            Console.WriteLine("\t\t" + item3.PlayerName);
            //        }
            //    }
            //}
            #endregion
        }
    }
}
