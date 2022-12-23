using ScoreBoardLib.Builders;
using ScoreBoardLib.Models;
using System.Collections.Generic;
using System.Linq;

namespace ScoreBoardLib.Validation
{
    internal class ScoreBoardBuilderValidator
    {
        internal ScoreBoardValidationResult Validate(ScoreBoardBuilder scoreBoardBuilder)
        {
            List<string> validationMessages = new();

            IEnumerable<IGrouping<string, Team>> duplicates = scoreBoardBuilder.Matches
                .SelectMany(game => new[] { game.HomeTeam, game.AwayTeam })
                .GroupBy(game => game.Country.Name)
                .Where(game => game.Count() > 1)
                .ToArray();

            if (duplicates.Any())
            {
                validationMessages.Add($"Duplicate Teams found - [{string.Join(", ", duplicates.Select(grouping => grouping.First().Country.Name))}] - Builder has stopped.");
            }

            return new ScoreBoardValidationResult
            {
                Messages = validationMessages
            };
        }
    }
}
