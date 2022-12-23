using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using ScoreBoardLib;
using ScoreBoardLib.Builders;
using ScoreBoardLib.Enumerations;
using ScoreBoardLib.Extensions.DependencyInjection;
using ScoreBoardLib.Models;
using ScoreBoardLib.Renderers;
using System;
using System.Linq;

namespace ScoreBoardLibTests
{
    public class Tests
    {
        [Test]
        public void ScoreBoard_Builder_Should_Not_Add_Duplicate_Teams()
        {
            ScoreBoardBuilder builder = new ScoreBoardBuilder();
            builder.UseRenderer<VoidRenderer>()
                    .AddMatch(new Team(Country.PL, 0), new Team(Country.CO, 1), DateTime.Now.AddMinutes(-23))
                    .AddMatch(new Team(Country.PL, 1), new Team(Country.CO, 2), DateTime.Now.AddMinutes(-13));


            IScoreBoard board;            
            
            try
            {
                board = builder.Build();                
            }
            catch (InvalidOperationException)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void ScoreBoard_Builder_Should_Not_Add_Duplicate_Teams_In_Same_Match()
        {
            ScoreBoardBuilder builder = new ScoreBoardBuilder();
            builder.UseRenderer<VoidRenderer>()
                    .AddMatch(new Team(Country.PL, 0), new Team(Country.PL, 1), DateTime.Now.AddMinutes(-23));

            IScoreBoard board;            

            try
            {
                board = builder.Build();                
            }
            catch (InvalidOperationException)
            {
                Assert.Pass();
            }
        }

        [SetUp]
        public void Setup()
        {
            
        }
    }
}