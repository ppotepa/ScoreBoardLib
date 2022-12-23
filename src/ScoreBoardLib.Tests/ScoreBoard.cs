using NUnit.Framework;
using ScoreBoardLib;
using ScoreBoardLib.Builders;
using ScoreBoardLib.Enumerations;
using ScoreBoardLib.Models;
using ScoreBoardLib.Renderers;
using System;
using System.Linq;

namespace ScoreBoardLibTests
{
    public class Tests
    {
        [Test]
        public void Fetching_Scores_Returns_Them_In_Right_Order()
        {
            ScoreBoardBuilder builder = new ScoreBoardBuilder();
            builder.UseRenderer<VoidRenderer>()
                    .AddMatch(new Team(Country.EC, 5), new Team(Country.EE, 1), DateTime.Now.AddMinutes(-20))
                    .AddMatch(new Team(Country.PL, 5), new Team(Country.AD, 1), DateTime.Now.AddMinutes(-10))
                    .AddMatch(new Team(Country.QA, 1), new Team(Country.AR, 1), DateTime.Now.AddMinutes(-30))
                    .AddMatch(new Team(Country.NU, 2), new Team(Country.AX, 1), DateTime.Now.AddMinutes(-50));

            IScoreBoard board = builder.Build();
            System.Collections.Generic.List<Match> scores = board.GetMatchesByScoreDescending().ToList();

            bool pass =
                scores[0].HomeTeam.Country.Name == "PL" &&
                scores[1].HomeTeam.Country.Name == "EC" &&
                scores[2].HomeTeam.Country.Name == "NU" &&
                scores[3].HomeTeam.Country.Name == "QA";

            Assert.True(pass);

        }

        [Test]
        public void Increase_Score_Test()
        {
            ScoreBoardBuilder builder = new ScoreBoardBuilder();
            builder.UseRenderer<VoidRenderer>()
                    .AddMatch(new Team(Country.PL, 0), new Team(Country.CO, 0), DateTime.Now.AddMinutes(-23));

            ScoreBoard board = builder.Build() as ScoreBoard;
            board.IncreaseScore(new Team(Country.PL, 1), new Team(Country.CO, 0));
            Assert.True(board[(Country.PL, Country.CO)].HomeTeam.Score == 1);
        }

        [Test]
        public void Removing_A_Match_Test()
        {
            ScoreBoardBuilder builder = new ScoreBoardBuilder();
            builder.UseRenderer<VoidRenderer>()
                    .AddMatch(new Team(Country.PL, 0), new Team(Country.CO, 1), DateTime.Now.AddMinutes(-23));

            IScoreBoard board = builder.Build();
            board.FinishTheMatch(new Team(Country.PL, 0), new Team(Country.CO, 1));
            Assert.True(!board.GetMatchesByScoreDescending().Any());
        }

        [Test]
        public void ScoreBoard_Builder_Should_Not_Add_Duplicate_Teams()
        {
            ScoreBoardBuilder builder = new ScoreBoardBuilder();
            builder.AddMatch(new Team(Country.PL, 0), new Team(Country.CO, 1), DateTime.Now.AddMinutes(-23))
                   .AddMatch(new Team(Country.CO, 1), new Team(Country.PL, 2), DateTime.Now.AddMinutes(-13));

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

        [Test]
        public void ScoreBoard_Builder_Should_Not_Add_Duplicate_Teams_In_Same_Match_When_Not_Using_A_Builder()
        {
            ScoreBoardBuilder builder = new ScoreBoardBuilder();
            builder.UseRenderer<VoidRenderer>()
                    .AddMatch(new Team(Country.PL, 0), new Team(Country.PL, 1), DateTime.Now.AddMinutes(-23));

            IScoreBoard board;

            try
            {
                board = builder.Build();
                board.AddAndStartNewMatch(new Team(Country.PL, 0), new Team(Country.PL, 1));
            }
            catch (InvalidOperationException)
            {
                Assert.Pass();
            }
        }
        [SetUp]
        public void Setup()
        {
            //intentionally left-empty
        }
    }
}