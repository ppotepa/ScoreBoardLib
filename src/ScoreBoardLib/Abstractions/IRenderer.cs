using System;
using ScoreBoardLib.EventArgs;

namespace ScoreBoardLib.Abstractions
{
    public interface IScoreBoardRenderer
    {
        void Initialize();
        void OnScoreBoardChanged(object sender, ScoreBoardStateChangedEventArgs eventArgs);
       
    }
}