using ScoreBoardLib.Abstractions;
using ScoreBoardLib.Models;
using System;

namespace ScoreBoardLib
{
    public interface IScoreBoardBuilder
    {
        IScoreBoardBuilder AddGame(Team homeTeam, Team awayTeam, DateTime? timeStarted = null);
        IScoreBoardBuilder UseRenderer<TRendererImpl>() where TRendererImpl : IScoreBoardRenderer;        
    }
}