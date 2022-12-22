using System.Collections.Generic;

namespace ScoreBoardLib.Validation
{
    internal class ScoreBoardValidationResult
    {
        internal List<string> Messages { get; set; }
        internal string MessagesString => string.Join("\\n", Messages);
        
    }
}