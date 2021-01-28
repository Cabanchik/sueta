using System;
using System.Linq;
using static FootballDataSource.FootballData;
using FootballModels;
using System.Collections.Generic;

namespace sosci
{
    class Program
    {
        static void Main(string[] args)
        {
            #region(Тут первое)
            //var attakersInCountry = from p in Players
            //                        where p.Position == "Forward"
            //                        group p by p.Country into k
            //                        select new
            //                        {
            //                            Country = k.Key, Count = k.Count()
            //                        };


            //foreach (var item in attakersInCountry)
            //{
            //    Console.WriteLine($"Country = {item.Country} , Количество футбольщиков = {item.Count}");
            //}
            //var attackersInCountry2 = Players.Where(p => p.Position == "Forward").GroupBy(p => p.Country).Select(p => new { Country = p.Key, Count = p.Count() });

            //foreach (var item in attackersInCountry2)
            //{
            //    Console.WriteLine($"Country = {item.Country} , Количество футбольщиков = {item.Count}");
            //}
            #endregion
            #region(Тут второе)
            //var groupedGoals = from s in Stadiums
            //                   group s.Name by s.Id into s
            //                   select new
            //                   {
            //                      Stadium = s.Key
            //                   };

            //var goalsInStadiums = (from s in groupedGoals
            //                      join m in Matches on s.Stadium equals m.StadionId
            //                      select new
            //                      {
            //                         Stadium = s.Stadium,
            //                         Match = m.Id,
            //                         Goals = m.HomeTeamGoals+m.GuestTeamGoals


            //                      }).ToList();
            //var StadiumsWithName = (from g in goalsInStadiums
            //                       join s in Stadiums on g.Stadium equals s.Id
            //                       select new
            //                       {
            //                           Stadium = s.Name,
            //                           City = s.City,
            //                           Match = g.Match,
            //                           Goals = g.Goals
            //                       }).ToList();

            //foreach (var item in StadiumsWithName)
            //{
            //    Console.WriteLine($"Стадион:{item.Stadium}, Город: {item.City}," +
            //        $" Матч: {item.Match} ,Голы: {item.Goals}"  );
            //}

            //var groupedGoals2 = Stadiums.GroupBy(s => s.Id).Select(s => new { Stadium = s.Key });
            //var goalsInStadiums2 = groupedGoals2.Join(Matches, s => s.Stadium, m => m.StadionId, (s, m) =>
            //      new
            //      {
            //          Stadium = s.Stadium,
            //          Match = m.Id,
            //          Goals = m.HomeTeamGoals + m.GuestTeamGoals
            //      });
            //var stadiumWithName = goalsInStadiums2.Join(Stadiums, g => g.Stadium, s => s.Id, (g, s) =>
            //  new
            //  {
            //      Stadium = s.Name,
            //      City = s.City,
            //      Match = g.Match,
            //      Goals = g.Goals
            //  });
            //foreach (var item in stadiumWithName)
            //{
            //    Console.WriteLine($"Стадион:{item.Stadium}, Город: {item.City}," +
            //        $" Матч: {item.Match} ,Голы: {item.Goals}"  );
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

            //Console.WriteLine(stadiumGoalsMax);

            //var stadiumGoalsMax1 = Matches.Join(Stadiums, m => m.StadionId, s => s.Id, (m, s) => new { s.Name, m.GuestTeamGoals, m.HomeTeamGoals })
            //.GroupBy(m => m.Name)
            //.Select((ma) => new
            //{
            //    Name = ma.Key,
            //    MaxCount = ma.Sum(g => g.GuestTeamGoals + g.HomeTeamGoals)
            //}).OrderBy(m => m.MaxCount).ToList().Last();
            //Console.WriteLine(stadiumGoalsMax1);
            #endregion
            #region(Тут четвертое)

            //var grouppedByTeams = from t in Teams
            //                      group t.Title by t.Id into t
            //                      select new
            //                      {
            //                          Team = t.Key
            //                      };
            //var workerInTeams = from t in grouppedByTeams
            //                    join w in Workers on t.Team equals w.TeamId
            //                    select new
            //                    {
            //                        Team = t.Team,
            //                        WorkerName = w.FirstName,
            //                        WorkerSurname = w.LastName,
            //                        Post = w.Position
            //                    };

            //var playersInTeams = from t in workerInTeams
            //                     join p in Players on t.Team equals p.TeamId
            //                     select new
            //                     {
            //                         Team = t.Team,
            //                         WorkerName = t.WorkerName,
            //                         WorkerSurname = t.WorkerSurname,
            //                         Post = t.Post,
            //                         PlayerName = p.FirstName,
            //                         PlayerLastname = p.LastName

            //                     };
            //foreach (var item in playersInTeams)
            //{
            //    Console.WriteLine($"Команда - {item.Team}\n" +
            //    $" Имя сотрудника - {item.WorkerName}\n " +
            //    $"Фамилия сотрудника - {item.WorkerSurname}\n " +
            //    $"Должность сотрудника - {item.Post}\n " +
            //    $"Имя игрока - {item.PlayerName}\n " +
            //    $"Фамилия игрока - {item.PlayerLastname}\n "); ;
            //}

            //var grouppedByTeams1 = Teams.GroupBy(t => t.Id).Select((t) => new { Team = t.Key });
            //var workerInTeams1 = grouppedByTeams1.Join(Workers, t => t.Team, w => w.TeamId, (t, w) => new
            //{
            //    Team = t.Team,
            //    WorkerName = w.FirstName,
            //    WorkerSurname = w.LastName,
            //    Post = w.Position
            //});
            //var playersInTeams1 = workerInTeams1.Join(Players, t => t.Team, p => p.TeamId, (t, p) => new
            //{
            //    Team = t.Team,
            //    WorkerName = t.WorkerName,
            //    WorkerSurname = t.WorkerSurname,
            //    Post = t.Post,
            //    PlayerName = p.FirstName,
            //    PlayerLastname = p.LastName
            //});
            //foreach (var item in playersInTeams1)
            //{
            //    Console.WriteLine($"Команда - {item.Team}\n" +
            //    $" Имя сотрудника - {item.WorkerName}\n " +
            //    $"Фамилия сотрудника - {item.WorkerSurname}\n " +
            //    $"Должность сотрудника - {item.Post}\n " +
            //    $"Имя игрока - {item.PlayerName}\n " +
            //    $"Фамилия игрока - {item.PlayerLastname}\n ");
            //}

            #endregion
            #region(тут пятое)

            //var grouppedReferee = from r in Referees
            //                      group r.FirstName by r.Id into r
            //                      select new
            //                      {
            //                          Reeferee = r.Key
            //                      };
            //var gefereesInMatches = from r in grouppedReferee
            //                        join m in MatchesAndReferees on r.Reeferee equals m.RefereeId
            //                        select new
            //                        {
            //                            Reeferee = r.Reeferee,
            //                            Match = m.MatchId
            //                        };
            //var refereeAndMatches = from r in gefereesInMatches
            //                        join m in Matches on r.Match equals m.Id
            //                        select new
            //                        {
            //                            Referee = r.Reeferee,
            //                            Match = m.Id,
            //                            Matchdate = m.MatchDate,
            //                            LIVE = m.IsFinished,
            //                            Stadium = m.StadionId,
            //                            HomeTeam = m.HomeTeamId,
            //                            GuestTeam = m.GuestTeamId
            //                        };
            //var matchesInStadiums = from m in refereeAndMatches
            //                        join s in Stadiums on m.Stadium equals s.Id
            //                        select new
            //                        {
            //                            HomeTeam = m.HomeTeam,
            //                            GuestTeam = m.GuestTeam,
            //                            Referee = m.Referee,
            //                            Match = m.Match,
            //                            Matchdate = m.Matchdate,
            //                            LIVE = m.LIVE,
            //                            Stadium = s.Name

            //                        };
            //var homePlayersInMatches = from m in matchesInStadiums
            //                           join t in Teams on m.HomeTeam equals t.Id
            //                           select new
            //                           {
            //                               HomeTeam = t.Title,
            //                               GuestTeam = m.GuestTeam,
            //                               Referee = m.Referee,
            //                               Match = m.Match,
            //                               Matchdate = m.Matchdate,
            //                               LIVE = m.LIVE,
            //                               Stadium = m.Stadium,

            //                           };
            //var guestPlayersInMatches = from m in homePlayersInMatches
            //                            join t in Teams on m.GuestTeam equals t.Id
            //                            select new
            //                            {
            //                                HomeTeam = m.HomeTeam,
            //                                GuestTeam = t.Title,
            //                                Referee = m.Referee,
            //                                Match = m.Match,
            //                                Matchdate = m.Matchdate,
            //                                LIVE = m.LIVE,
            //                                Stadium = m.Stadium,

            //                            };
            //var refereesInMatches = from m in guestPlayersInMatches
            //                        join r in Referees on m.Referee equals r.Id
            //                        select new
            //                        {
            //                            HomeTeam = m.HomeTeam,
            //                            GuestTeam = m.GuestTeam,
            //                            RefereeName = r.FirstName,
            //                            RefereeLastName = r.LastName,
            //                            Match = m.Match,
            //                            Matchdate = m.Matchdate,
            //                            LIVE = m.LIVE,
            //                            Stadium = m.Stadium,
            //                        };

            //foreach (var item in refereesInMatches)
            //{
            //    Console.WriteLine(
            //                      $"Судья: {item.RefereeName} {item.RefereeLastName}\n" +
            //                      $"ID Матча: {item.Match}\n" +
            //                      $"Дата проведения матча: {item.Matchdate}\n" +
            //                      $"Стадион проведения: {item.Stadium}\n" +
            //                      $"Домашняя команда: {item.HomeTeam},\n" +
            //                      $"Команда-Гость: {item.GuestTeam},\n" +
            //                      $"Закончился ли матч:{item.LIVE}\n");
            //}

            //var grouppedReferee = Referees.GroupBy(r => r.Id).Select(s => new
            //{
            //    Referee = s.Key
            //});
            //var refereeInMatches = MatchesAndReferees.Join(grouppedReferee, m => m.RefereeId, r => r.Referee, (m, r) => new 
            //{
            //    Match = m.MatchId,
            //    Referee = r.Referee
            //});
            //var refereesAndMatches = Matches.Join(refereeInMatches, m => m.Id, r => r.Match, (m, r) => new
            //{
            //    Referee = r.Referee,
            //    Match = m.Id,
            //    Matchdate = m.MatchDate,
            //    LIVE = m.IsFinished,
            //    Stadium = m.StadionId,
            //    HomeTeam = m.HomeTeamId,
            //    GuestTeam = m.GuestTeamId
            //});
            //var matchesInStadiums = Stadiums.Join(refereesAndMatches, s => s.Id, m => m.Stadium, (s, m) => new
            //{
            //    HomeTeam = m.HomeTeam,
            //    GuestTeam = m.GuestTeam,
            //    Referee = m.Referee,
            //    Match = m.Match,
            //    Matchdate = m.Matchdate,
            //    LIVE = m.LIVE,
            //    Stadium = s.Name
            //});
            //var homePlayersInMatch = Teams.Join(matchesInStadiums, t => t.Id, m => m.HomeTeam, (t, m) => new
            //{
            //    HomeTeam = t.Title,
            //    GuestTeam = m.GuestTeam,
            //    Referee = m.Referee,
            //    Match = m.Match,
            //    Matchdate = m.Matchdate,
            //    LIVE = m.LIVE,
            //    Stadium = m.Stadium,
            //});
            //var guestTeamInMatch = Teams.Join(homePlayersInMatch, t => t.Id, m => m.GuestTeam, (t, m) => new
            //{
            //    HomeTeam = m.HomeTeam,
            //    GuestTeam = t.Title,
            //    Referee = m.Referee,
            //    Match = m.Match,
            //    Matchdate = m.Matchdate,
            //    LIVE = m.LIVE,
            //    Stadium = m.Stadium,
            //});
            //var refereesInMatch = Referees.Join(guestTeamInMatch, r => r.Id, m => m.Referee, (r, m) => new
            //{
            //    HomeTeam = m.HomeTeam,
            //    GuestTeam = m.GuestTeam,
            //    RefereeName = r.FirstName,
            //    RefereeLastName = r.LastName,
            //    Match = m.Match,
            //    Matchdate = m.Matchdate,
            //    LIVE = m.LIVE,
            //    Stadium = m.Stadium,
            //});
            //foreach (var item in refereesInMatch)
            //{
            //    Console.WriteLine(
            //                      $"Судья: {item.RefereeName} {item.RefereeLastName}\n" +
            //                      $"ID Матча: {item.Match}\n" +
            //                      $"Дата проведения матча: {item.Matchdate}\n" +
            //                      $"Стадион проведения: {item.Stadium}\n" +
            //                      $"Домашняя команда: {item.HomeTeam},\n" +
            //                      $"Команда-Гость: {item.GuestTeam},\n" +
            //                      $"Закончился ли матч:{item.LIVE}\n");
            //}

            #endregion
            #region(тут шестое)
            var groupedTeams = from t in Teams
                               group t.Title by t.Id into t
                               select new
                               {
                                   Team = t.Key
                               };


            var playersInTeams = from t in groupedTeams
                                 join p in Players on t.Team equals p.TeamId
                                 select new
                                 {
                                     Team = t.Team,
                                     Position = p.Position,
                                     PlayerName = p.FirstName,
                                     PlayerSurname = p.LastName
                                 };
            var teamsInPlayers = from p in playersInTeams
                                 join t in Teams on p.Team equals t.Id
                                 select new
                                 {
                                     Team = t.Title,
                                     Position = p.Position,
                                     PlayerName = p.PlayerName,
                                     PlayerSurname = p.PlayerSurname,
                                     

                                 }into l 
                                 group l.PlayerName by l.Position;
            //var groupedPositions = from t in teamsInPlayers
            //                       group t by t.Position into sas
            //                       select new
            //                       {
            //                           Position = sas.Key,
            //                           Players = (from p in teamsInPlayers
            //                                      select new {
            //                                          Team = p.Team,
                                                      
            //                                          PlayerName = p.PlayerName,
            //                                          PlayerSurname = p.PlayerSurname,
            //                                      })
            //                       };





            foreach (var item in teamsInPlayers)
            {
                Console.WriteLine("\t\t" + item.Key);
                foreach (var item2 in item)
                {
                    Console.WriteLine("\t\t\t"+item2);
                }
            }

            #endregion
        }
    }
}
