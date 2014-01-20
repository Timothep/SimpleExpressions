using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters.EitherOr
{
    public class Then: BaseConverter
    {
        private readonly IList<string> functions = new List<string> { "Then" };
        public override IList<string> Functions
        {
            get { return this.functions; }
        }

        public override IList<string> Generate(IList<Function> tokens, int currentIndex, IList<string> pattern)
        {
            pattern.Add("))");
            return pattern;
        }
    }
}
