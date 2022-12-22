using System;

namespace ScoreBoardLib.Models
{
    public class Game
    {
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public DateTime StartTime { get; set; }        
    }
}