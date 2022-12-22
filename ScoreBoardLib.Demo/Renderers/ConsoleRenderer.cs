using ScoreBoardLib;
using ScoreBoardLib.Abstractions;

namespace ScoreBoardLibDemo.Renderers
{
    internal class ColorfulConsoleRenderer : IScoreBoardRenderer
    {
        private ScoreBoard scoreBoard;

        public void Initialize(ScoreBoard scoreBoard)
        {
            this.scoreBoard = scoreBoard;
        }

        public void Render()
        {  
        }
    }
}