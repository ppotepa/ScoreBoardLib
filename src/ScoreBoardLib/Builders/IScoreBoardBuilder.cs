using ScoreBoardLib.Abstractions;
using ScoreBoardLib.Models;
using System;

namespace ScoreBoardLib.Builders
{
    public interface IScoreBoardBuilder
    {
        IScoreBoardBuilder AddMatch(Team homeTeam, Team awayTeam, DateTime startTime = default);
        IScoreBoardBuilder UseRenderer<TRendererImpl>() where TRendererImpl : IScoreBoardRenderer;        
    }
}