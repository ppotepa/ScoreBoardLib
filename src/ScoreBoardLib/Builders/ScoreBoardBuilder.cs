using ScoreBoardLib.Abstractions;
using ScoreBoardLib.Models;
using ScoreBoardLib.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScoreBoardLib.Builders
{
    public class ScoreBoardBuilder : IScoreBoardBuilder
    {
        internal List<Match> Matches { get; set; } = new List<Match>();
        internal Type RendererImplementation { get; set; }

        public IScoreBoardBuilder AddMatch(Team homeTeam, Team awayTeam, DateTime startTime = default)
        {
            Matches.Add(new Match { HomeTeam = homeTeam, AwayTeam = awayTeam, StartTime = startTime });
            return this;
        }

        public IScoreBoard Build()
        {
            ScoreBoardValidationResult result = new ScoreBoardBuilderValidator().Validate(this);

            if (result.Messages.Any())
            {
                throw new InvalidOperationException
                (
                   message: $"Validation failed. Following Errors occured. \n\n{result.MessagesString}"
                );
            }

            IScoreBoardRenderer Renderer = Activator.CreateInstance(RendererImplementation) as IScoreBoardRenderer;

            ScoreBoard scoreBoard = new ScoreBoard
            {
                Renderer = Renderer,
                Matches = Matches
            };
            
            scoreBoard.ScoreBoardStateChanged += Renderer.OnScoreBoardChanged;

            return scoreBoard;
        }

        public IScoreBoardBuilder UseRenderer<TRendererImpl>() where TRendererImpl : IScoreBoardRenderer
        {
            RendererImplementation = typeof(TRendererImpl);
            return this;
        }
    }
}
