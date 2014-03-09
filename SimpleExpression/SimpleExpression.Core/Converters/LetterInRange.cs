using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters
{
    public class LetterInRange : InRangeAbstractConverter
    {
        public LetterInRange()
        {
            this.supportedFunctionNames = new List<string> { "LetterInRange" };
        }
    }
}