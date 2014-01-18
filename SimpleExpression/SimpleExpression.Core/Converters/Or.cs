using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters
{
    public class Or: BaseConverter
    {
        private readonly IList<string> functions = new List<string> { "Or" };
        public override IList<string> Functions
        {
            get { return this.functions; }
        }

        public override IList<string> Generate(IList<Function> tokens, int currentIndex, IList<string> pattern)
        {
            //Find the bounds of the previous group to add "("

            //Find the bound of the next group to close the ")"... how?

            pattern.Add("|");
            return pattern;
        }
    }
}
