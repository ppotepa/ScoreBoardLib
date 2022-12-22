namespace ScoreBoardLib.Abstractions
{
    public interface IScoreBoardRenderer
    {
        void Render();
        void Initialize(ScoreBoard scoreBoard);
    }
}