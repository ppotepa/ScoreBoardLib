using Microsoft.Extensions.DependencyInjection;
using ScoreBoardLib.Builders;
using ScoreBoardLib.Renderers;
using System;

namespace ScoreBoardLib.Extensions.DependencyInjection
{
    public static class ServiceProviderExtensions
    {
        static readonly Action<ScoreBoardBuilder> DefaultAction = (ScoreBoardBuilder builder) 
            => builder.RendererImplementation = typeof(DefaultConsoleRenderer);       

        public static void AddScoreBoard(this IServiceCollection @this, Action<ScoreBoardBuilder> buildingAction = default)
        {
            buildingAction ??= DefaultAction;

            ScoreBoardBuilder builder = new();
            buildingAction(builder);            
            IScoreBoard scoreBoard = builder.Build();
            @this.AddSingleton(scoreBoard);
        }
    }
}
