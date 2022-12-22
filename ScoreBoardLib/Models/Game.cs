using System;
using ScoreBoardLib.Enumerations;

namespace ScoreBoardLib.Models
{
    public class Game
    {
        public Team AwayTeam { get; set; }
        public Team HomeTeam { get; set; }
        public GameProgess InProgress
        {
            get
            {
                if (StartTime == default) return GameProgess.NotStarted;
                if ((DateTime.Now - StartTime).Minutes <= 90) return GameProgess.InProgress;
                else return GameProgess.Ended;
            }
        }

        public DateTime StartTime { get; set; }
    }
}