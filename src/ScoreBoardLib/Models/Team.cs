using ScoreBoardLib.Enumerations;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ScoreBoardLib.Models
{
    public sealed class Team : IEquatable<Team>
    {
        internal readonly Country CountryCodeEnumValue;

        public Team(Country country, int score)
        {
            Country = new RegionInfo(country.ToString());
            Score = score;
            CountryCodeEnumValue = country;
        }

        public Team(Country country)
        {
            Country = new RegionInfo(country.ToString());            
            CountryCodeEnumValue = country;
        }

        public RegionInfo Country { get; private set; }
        public int Score { get; internal set; }
        public static bool operator !=(Team left, Team right)
        {
            return !(left == right);
        }

        public static bool operator ==(Team left, Team right)
        {
            return EqualityComparer<Team>.Default.Equals(left, right);
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Team);
        }

        public bool Equals(Team other)
        {
            return other is not null &&
                   EqualityComparer<RegionInfo>.Default.Equals(this.Country, other.Country);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.CountryCodeEnumValue, this.Country, this.Score);
        }
    }
}