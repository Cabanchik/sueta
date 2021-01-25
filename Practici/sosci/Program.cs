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
            #region(Тут третье)
            var grouppedByTeams = from t in Teams
                                  group t.Title by t.Id into t
                                  select new
                                  {
                                      Team = t.Key
                                  };
            var workerInTeams = from t in grouppedByTeams
                                join w in Workers on t.Team equals w.TeamId
                                select new
                                 {
                                     Team = t.Team,
                                     WorkerName = w.FirstName,
                                     WorkerSurname = w.LastName,
                                     Post = w.Position
                                 };
        
            var playersInTeams = from t in workerInTeams
                                 join p in Players on t.Team equals p.TeamId
                                 select new
                                 {
                                     Team = t.Team,
                                     WorkerName = t.WorkerName,
                                     WorkerSurname = t.WorkerSurname,
                                     Post = t.Post,
                                     PlayerName = p.FirstName,
                                     PlayerLastname = p.LastName

                                 };
            foreach (var item in playersInTeams)
            {
                Console.WriteLine($"Команда - {item.Team}, " +
                    $" Имя сотрудника - {item.WorkerName} " +
                    $"Фамилия сотрудника - {item.WorkerSurname} " +
                    $"Должность сотрудника - {item.Post} " +
                    $"Имя игрока - {item.PlayerName} " +
                    $"Фамилия игрока - {item.PlayerLastname} " );
            }


            #endregion
        }
    }
}
