using ScoreBoardLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScoreBoardLib.Validation
{
    internal class ScoreBoardBuilderValidator
    {
        internal ScoreBoardValidationResult Validate(ScoreBoardBuilder scoreBoardBuilder)
        {
            List<string> validationMessages = new List<string>();
            IEnumerable<IGrouping<string, Team>> anyDuplicates = scoreBoardBuilder.Games.SelectMany(game => new[] { game.HomeTeam, game.AwayTeam })
                                                                .GroupBy(game => game.Country.Name)
                                                                .Where(game => game.Count() > 1);

            if (anyDuplicates.Any())
            {
                validationMessages.Add($"Duplicate Teams found - [{string.Join(", ", anyDuplicates.Select(grouping => grouping.First().Country.Name))}]");
            }

            return new ScoreBoardValidationResult
            {
                Messages = validationMessages
            };
        }
    }
}
