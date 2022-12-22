using ScoreBoardLib.Abstractions;
using ScoreBoardLib.EventArgs;
using System;

namespace ScoreBoardLib.Renderers
{
    internal class DefaultConsoleRenderer : IScoreBoardRenderer
    {
        public void Initialize()
        {
            Console.Clear();
        }

        public void OnScoreBoardChanged(object sender, ScoreBoardStateChangedEventArgs eventArgs)
        {
            Console.Clear();
            
            eventArgs.Matches.ForEach(match =>
            {
                string text = match.ToString();
                Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop);
                Console.WriteLine(text);
            });
        }
    }
}
