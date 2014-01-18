using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters
{
    public class AnyCharacter: BaseConverter
    {
        private readonly IList<string> functions = new List<string> { "AnyCharacter" };
        public override IList<string> Functions
        {
            get { return this.functions; }
        }

        public override IList<string> Generate(IList<Function> tokens, int currentIndex, IList<string> pattern)
        {
            pattern.Add(@".");
            return pattern;
        }
    }

    public class AnyCharacters : BaseConverter
    {
        private readonly IList<string> functions = new List<string> { "AnyCharacters" };
        public override IList<string> Functions
        {
            get { return this.functions; }
        }

        public override IList<string> Generate(IList<Function> tokens, int currentIndex, IList<string> pattern)
        {
            pattern.Add(@".*");
            return pattern;
        }
    }
}
