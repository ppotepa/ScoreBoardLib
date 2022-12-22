using System;
using System.Collections.Generic;
using System.Linq;
using ScoreBoardLib.Abstractions;
using ScoreBoardLib.Models;
using ScoreBoardLib.Validation;

namespace ScoreBoardLib
{
    public class ScoreBoardBuilder : IScoreBoardBuilder
    {
        internal List<Game> Games { get; set; } = new List<Game>();
        internal Type RendererImplementation { get; set; }

        public IScoreBoardBuilder AddGame(Team homeTeam, Team awayTeam, DateTime? timeStarted = null)
        {
            Games.Add(new Game { HomeTeam = homeTeam, AwayTeam = awayTeam, StartTime = timeStarted is null ? default : timeStarted.Value });
            return this;
        }

        public ScoreBoard Build()
        {
            ScoreBoardValidationResult result = new ScoreBoardBuilderValidator().Validate(this);

            if (result.Messages.Any())
            {
                throw new InvalidOperationException
                (
                   message: $"Validation failed. Following Errors occured. \n\n{result.MessagesString}"
                );
            }

            return new ScoreBoard
            {
                
            };
        }

        public IScoreBoardBuilder UseRenderer<TRendererImpl>() where TRendererImpl : IScoreBoardRenderer
        {
            RendererImplementation = typeof(TRendererImpl);
            return this;
        }
    }
}
