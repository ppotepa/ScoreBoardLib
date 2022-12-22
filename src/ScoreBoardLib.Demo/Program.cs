using Microsoft.Extensions.DependencyInjection;
using ScoreBoardLib;
using ScoreBoardLib.Enumerations;
using ScoreBoardLib.Extensions.DependencyInjection;
using ScoreBoardLib.Models;
using ScoreBoardLibDemo.Renderers;
using System;
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
                        .AddMatch(new Team(Country.PL, 0), new Team(Country.CO, 1))
                        .AddMatch(new Team(Country.DE, 1), new Team(Country.GE, 2))
                        .AddMatch(new Team(Country.ID, 2), new Team(Country.UA, 2))
                        .AddMatch(new Team(Country.WF, 1), new Team(Country.BE, 0))
                        .AddMatch(new Team(Country.EE, 0), new Team(Country.EG, 0))
                        .AddMatch(new Team(Country.FI, 0), new Team(Country.GG, 3));
            });

            IServiceProvider provider = services.BuildServiceProvider();
            IScoreBoard scoreBoard = provider.GetService<IScoreBoard>();

            scoreBoard.Start();
            Thread.Sleep(2000);
            scoreBoard.AddMatch(new Team(Country.PL, 1), new Team(Country.CO, 1));
            Thread.Sleep(2000);
            scoreBoard.AddMatch(new Team(Country.FM, 2), new Team(Country.FO, 2));
            Thread.Sleep(2000);
            scoreBoard.IncreaseScore(new Team(Country.FM, 2), new Team(Country.FO, 3));
            Thread.Sleep(2000);
            scoreBoard.IncreaseScore(new Team(Country.FM, 3), new Team(Country.FO, 3));
            Thread.Sleep(2000);
            scoreBoard.IncreaseScore(new Team(Country.PL, 2), new Team(Country.CO, 1));
            Thread.Sleep(2000);
            scoreBoard.RemoveMatch(new Team(Country.PL), new Team(Country.CO));
        }
    }
}
