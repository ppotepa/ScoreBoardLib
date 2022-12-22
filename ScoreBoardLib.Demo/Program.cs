using Colorful;
using ScoreBoardLib;
using ScoreBoardLib.Enumerations;
using ScoreBoardLib.Models;
using ScoreBoardLibDemo.Renderers;
using System.Globalization;

namespace ScoreBoardLibDemo
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Country.TC.ToString());

            ScoreBoard scoreBoard = new ScoreBoardBuilder()
                .UseRenderer<ColorfulConsoleRenderer>()
                .AddGame(new Team(Country.PL), new Team(Country.CO))
                .AddGame(new Team(Country.PL), new Team(Country.CO))
                .Build();
        }
    }
}
