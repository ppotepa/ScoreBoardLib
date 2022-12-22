using ScoreBoardLib.Enumerations;
using ScoreBoardLib.EventArgs;
using ScoreBoardLib.Models;
using System;

namespace ScoreBoardLib
{
    public interface IScoreBoard
    {
        event EventHandler<ScoreBoardStateChangedEventArgs> ScoreBoardStateChanged;
        void AddMatch(Team homeTeam, Team awayTeam);
        void IncreaseScore(Team homeTeam, Team awayTeam);
        void RemoveMatch(Team homeTeam, Team awayTeam);
        void Start();
    }
}
