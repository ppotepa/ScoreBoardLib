using Microsoft.Extensions.DependencyInjection;
using System;

namespace ScoreBoardLib.Extensions.DependencyInjection
{
    public static class ServiceProviderExtensions
    {
        public static void AddScoreBoard(this IServiceCollection @this, Action<ScoreBoardBuilder> factory) 
        {
            ScoreBoardBuilder builder = new ScoreBoardBuilder();
            factory(builder);
            ScoreBoard build = builder.Build();
        }
    }
}
