using ScoreBoardLib.Enumerations;
using System;
using System.Collections.Generic;

namespace ScoreBoardLib.Models
{
    public sealed class Match : IEquatable<Match>
    {
        public int AbsoluteScore => AwayTeam.Score + HomeTeam.Score;

        public Team AwayTeam { get; set; }
        public double ElapsedMinutes => (DateTime.Now - StartTime).Minutes;
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
        public static bool operator !=(Match left, Match right)
        {
            return !(left == right);
        }

        public static bool operator ==(Match left, Match right)
        {
            return EqualityComparer<Match>.Default.Equals(left, right);
        }

        public bool Equals(Match other)
        {
            if (other is null) return false;
            else return this.HomeTeam.Country.GeoId == other.HomeTeam.Country.GeoId ||
                        this.AwayTeam.Country.GeoId == other.AwayTeam.Country.GeoId ||
                        this.HomeTeam.Country.GeoId == other.AwayTeam.Country.GeoId ||
                        this.AwayTeam.Country.GeoId == other.HomeTeam.Country.GeoId;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Match);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.AbsoluteScore, this.AwayTeam, this.HomeTeam, this.InProgress, this.StartTime);
        }

        public override string ToString() =>
                            $"[HOME] {HomeTeam.Country.Name} {HomeTeam.Score} : {AwayTeam.Score} {AwayTeam.Country.Name} [AWAY] - {ElapsedMinutes} minutes";
    }
}