using ScoreBoardLib.EventArgs;
using ScoreBoardLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScoreBoardLib
{
    public interface IScoreBoard
    {
        event EventHandler<ScoreBoardStateChangedEventArgs> ScoreBoardStateChanged;
        void AddAndStartNewMatch(Team homeTeam, Team awayTeam);
        void IncreaseScore(Team homeTeam, Team awayTeam);
        IOrderedEnumerable<Match> GetMatchesByScoreDescending();
        void FinishTheMatch(Team homeTeam, Team awayTeam);
        void Start();
    }
}
