using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters
{
    public class NumberInRange : InRangeAbstractConverter
    {
        public NumberInRange()
        {
            this.supportedFunctionNames = new List<string> { "NumberInRange" };
        }
    }
}