using ScoreBoardLib.Abstractions;
using ScoreBoardLib.EventArgs;

namespace ScoreBoardLib.Renderers
{
    internal class VoidRenderer : IScoreBoardRenderer
    {
        public void Initialize()
        {
            //intenionally left empty
        }        

        public void OnScoreBoardChanged(object sender, ScoreBoardStateChangedEventArgs eventArgs)
        {
            //intenionally left empty
        }
    }
}
