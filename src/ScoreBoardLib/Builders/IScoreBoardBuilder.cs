using ScoreBoardLib.Abstractions;
using ScoreBoardLib.Models;
using System;

namespace ScoreBoardLib.Builders
{
    public interface IScoreBoardBuilder
    {
        IScoreBoardBuilder AddMatch(Team homeTeam, Team awayTeam);
        IScoreBoardBuilder UseRenderer<TRendererImpl>() where TRendererImpl : IScoreBoardRenderer;        
    }
}