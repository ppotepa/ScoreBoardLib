using ScoreBoardLib.Models;
using System.Collections.Generic;

namespace ScoreBoardLib.EventArgs
{
    public class ScoreBoardStateChangedEventArgs
    {
        public List<Match> Matches { get; internal set; }
    }
}