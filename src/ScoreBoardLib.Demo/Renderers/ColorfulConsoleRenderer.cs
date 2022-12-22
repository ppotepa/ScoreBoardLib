using Colorful;
using ScoreBoardLib.Abstractions;
using ScoreBoardLib.EventArgs;
using System.Drawing;

namespace ScoreBoardLibDemo.Renderers
{
    /// <summary>
    /// Example use of another IRenderer implementation
    /// In this case we're using ColorFulConsole library
    /// </summary>
    internal class ColorfulConsoleRenderer : IScoreBoardRenderer
    {
        public void Initialize()
        {
            Colorful.Console.Clear();
        }
      
        public void OnScoreBoardChanged(object sender, ScoreBoardStateChangedEventArgs eventArgs)
        {
            Colorful.Console.Clear();
            StyleSheet styleSheet = new StyleSheet(Color.White);
            styleSheet.AddStyle("[A-Z]", Color.MediumSlateBlue);

            eventArgs.Matches.ForEach(match =>
            {
                string text = match.ToString();
                Colorful.Console.SetCursorPosition((Colorful.Console.WindowWidth - text.Length) / 2, Colorful.Console.CursorTop);
                Colorful.Console.WriteLineStyled(styleSheet, text);
            });
        }
    }
}