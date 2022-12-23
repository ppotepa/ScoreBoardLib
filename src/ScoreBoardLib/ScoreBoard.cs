using ScoreBoardLib.Abstractions;
using ScoreBoardLib.Enumerations;
using ScoreBoardLib.EventArgs;
using ScoreBoardLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScoreBoardLib
{
    public class ScoreBoard : IScoreBoard
    {
        public event EventHandler<ScoreBoardStateChangedEventArgs> ScoreBoardStateChanged;

        internal List<Match> Matches { get; set; }

        internal IScoreBoardRenderer Renderer { get; set; }

        private ScoreBoardStateChangedEventArgs DefaultArgs => new ScoreBoardStateChangedEventArgs { Matches = GetMatchesByScoreDescending().ToList() };

        public Match this[(Country home, Country away) index]
        {
            get
            {
                return this.Matches.FirstOrDefault(match => match.HomeTeam.CountryCodeEnumValue == index.home && match.AwayTeam.CountryCodeEnumValue == index.away);
            }

            set
            {
                Match targetMatch = this.Matches.FirstOrDefault(match => match.HomeTeam.CountryCodeEnumValue == index.home && match.AwayTeam.CountryCodeEnumValue == index.away);

                if (targetMatch is null)
                {
                    throw new InvalidOperationException("Match not found");
                }
                else
                {
                    targetMatch.HomeTeam.Score = value.HomeTeam.Score;
                    targetMatch.AwayTeam.Score = value.AwayTeam.Score;
                }
            }

        }
        public void AddAndStartNewMatch(Team homeTeam, Team awayTeam)
        {
            Match newMatch = new Match { HomeTeam = homeTeam, AwayTeam = awayTeam };

            try
            {
                if (homeTeam != awayTeam && Matches.Any(match => match == newMatch) is false)
                {
                    newMatch.StartTime = DateTime.Now;
                    Matches.Add(newMatch);
                    ScoreBoardStateChanged?.Invoke(this, DefaultArgs);
                }
                else
                {
                    throw new InvalidOperationException("Duplicate Teams on the ScoreBoard");
                }
            }
            catch (InvalidOperationException)
            {
                //intentionally left-empty
            }
        }

        public void FinishTheMatch(Team homeTeam, Team awayTeam)
        {
            Match targetMatch = Matches.FirstOrDefault(match => match.HomeTeam == homeTeam && match.AwayTeam == awayTeam);
            try
            {
                if (targetMatch is null)
                {
                    throw new InvalidOperationException("Match not found.");
                }
                else
                {
                    Matches.Remove(targetMatch);
                    ScoreBoardStateChanged?.Invoke(this, DefaultArgs);
                }
            }
            catch (InvalidOperationException)
            {
                //intentionally left empty
            }
        }

        public IOrderedEnumerable<Match> GetMatchesByScoreDescending()
            => Matches.OrderByDescending(match => match.AbsoluteScore).ThenBy(match => match.ElapsedMinutes);

        public void IncreaseScore(Team homeTeam, Team awayTeam)
        {
            Match targetMatch = Matches.FirstOrDefault(match => match.HomeTeam == homeTeam && match.AwayTeam == awayTeam);

            try
            {
                if (targetMatch is null)
                {
                    throw new InvalidOperationException("Match not found.");
                }
                else
                {
                    targetMatch.HomeTeam.Score = homeTeam.Score;
                    targetMatch.AwayTeam.Score = awayTeam.Score;
                    ScoreBoardStateChanged?.Invoke(this, DefaultArgs);
                }
            }
            catch (InvalidOperationException)
            {
                //intentionally left empty
            }
        }

        public void Start()
        {
            Renderer.Initialize();
            Matches.ToList().ForEach(pair =>
            {
                if (pair.StartTime == default)
                {
                    pair.StartTime = DateTime.Now;
                }

                ScoreBoardStateChanged?.Invoke(this, DefaultArgs);
            });
        }
    }
}
