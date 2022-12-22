using Microsoft.Extensions.DependencyInjection;
using ScoreBoardLib;
using ScoreBoardLib.Enumerations;
using ScoreBoardLib.Extensions.DependencyInjection;
using ScoreBoardLib.Models;
using ScoreBoardLibDemo.Renderers;
using System;

namespace ScoreBoardLibDemo
{
    internal static class Program
    {
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoreBoard(builder =>
            {
                builder
                    .UseRenderer<ColorfulConsoleRenderer>()
                        .AddGame(new Team(Country.PL), new Team(Country.CO))
                        .AddGame(new Team(Country.DE), new Team(Country.GE))
                        .AddGame(new Team(Country.ID), new Team(Country.UA))
                        .AddGame(new Team(Country.WF), new Team(Country.BE))
                        .AddGame(new Team(Country.EE), new Team(Country.EG))
                        .AddGame(new Team(Country.FI), new Team(Country.PL))
                        .AddGame(new Team(Country.CW), new Team(Country.CW));
            });
        }

        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            IServiceProvider provider = services.BuildServiceProvider();
        }
    }
}
