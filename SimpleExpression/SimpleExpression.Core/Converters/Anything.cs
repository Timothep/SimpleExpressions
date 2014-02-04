using System.Collections.Generic;
using SimpleExpressions.Core.Parser;

namespace SimpleExpressions.Core.Converters
{
    public class Anything : BaseConverter
    {
        private readonly IList<string> functions = new List<string> { "Anything" };
        public override IList<string> Functions
        {
            get { return this.functions; }
        }

        private const NodeType Type = NodeType.SimpleNode;
        public override NodeType NodeType
        {
            get { return Type; }
        }

        public override IList<string> Generate(IList<Function> tokens, int currentIndex, IList<string> pattern)
        {
            pattern.Add(@".*");
            return pattern;
        }
    }
}
