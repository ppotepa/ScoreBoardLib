using System;
using System.Collections.Generic;
using System.Linq;
using ScoreBoardLib.Abstractions;
using ScoreBoardLib.Models;

namespace ScoreBoardLib
{
    public class ScoreBoardBuilder
    {
        private List<Game> _games { get; set; } = new List<Game>();
        private Type _rendererImplementation { get; set; }

        public ScoreBoardBuilder AddGame(Team homeTeam, Team awayTeam, DateTime? timeStarted = null)
        {
            if (homeTeam == awayTeam)
                throw new InvalidOperationException("Home Team and Away Team cannot be the same country.");

            List<Game> overlappingGames = _games.Where(x => x.AwayTeam == awayTeam || x.HomeTeam == homeTeam || x.AwayTeam == homeTeam || x.HomeTeam == awayTeam).ToList();

            if (overlappingGames.Any())
                throw new InvalidOperationException("Home Team and Away Team cannot be the same country.");

            _games.Add(new Game { HomeTeam = homeTeam, AwayTeam = awayTeam, StartTime = timeStarted is null ? default : timeStarted.Value });
            return this;
        }

        public ScoreBoard Build()
        {
            return new ScoreBoard();
        }

        public ScoreBoardBuilder UseRenderer<TRendererImpl>() where TRendererImpl : IScoreBoardRenderer
        {
            _rendererImplementation = typeof(TRendererImpl);
            return this;
        }
    }
}
