using Microsoft.Extensions.DependencyInjection;
using ScoreBoardLib;
using ScoreBoardLib.Enumerations;
using ScoreBoardLib.Extensions.DependencyInjection;
using ScoreBoardLib.Models;
using ScoreBoardLibDemo.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ScoreBoardLibDemo
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();

            services.AddScoreBoard(builder =>
            {
                builder
                    .UseRenderer<ColorfulConsoleRenderer>()
                        .AddMatch(new Team(Country.PL, 0), new Team(Country.CO, 1), DateTime.Now.AddMinutes(-23))
                        .AddMatch(new Team(Country.DE, 1), new Team(Country.GE, 2), DateTime.Now.AddMinutes(-13))
                        .AddMatch(new Team(Country.ID, 2), new Team(Country.UA, 2), DateTime.Now.AddMinutes(-24))
                        .AddMatch(new Team(Country.WF, 1), new Team(Country.BE, 0), DateTime.Now.AddMinutes(-25))
                        .AddMatch(new Team(Country.EE, 0), new Team(Country.EG, 0), DateTime.Now.AddMinutes(-43))
                        .AddMatch(new Team(Country.FI, 0), new Team(Country.GG, 3), DateTime.Now.AddMinutes(-73));
            });

            IServiceProvider provider = services.BuildServiceProvider();
            IScoreBoard scoreBoard = provider.GetService<IScoreBoard>();

            scoreBoard.Start();

            List<Action> actions = new[]
            {
                () => scoreBoard.AddAndStartNewMatch(new Team(Country.PL, 0), new Team(Country.CO, 0)),
                () => scoreBoard.AddAndStartNewMatch(new Team(Country.PL, 0), new Team(Country.CO, 0)),
                () => scoreBoard.ChangeScore(new Team(Country.FM, 3), new Team(Country.FO, 3)),
                () => scoreBoard.ChangeScore(new Team(Country.PL, 2), new Team(Country.CO, 1)),
                () => scoreBoard.FinishTheMatch(new Team(Country.PL), new Team(Country.CO)),
                () => scoreBoard.AddAndStartNewMatch(new Team(Country.PL, 0), new Team(Country.CO, 0)),
                () => scoreBoard.AddAndStartNewMatch(new Team(Country.AD, 0), new Team(Country.KZ, 0)),
            }.ToList();


            actions.ForEach(action =>
            {
                action();
                Thread.Sleep(2000);
            });

            List<Match> descending = scoreBoard.GetMatchesByScoreDescending().ToList();
        }
    }
}
