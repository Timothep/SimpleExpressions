using System;
using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters
{
    public class Match : BaseConverter
    {
        private readonly IList<string> functions = new List<string> { "Match" };
        public override IList<string> Functions
        {
            get { return this.functions; }
        }

        public override IList<string> Generate(IList<Function> tokens, int currentIndex, IList<string> pattern)
        {
            throw new NotImplementedException();
        }
    }
}
