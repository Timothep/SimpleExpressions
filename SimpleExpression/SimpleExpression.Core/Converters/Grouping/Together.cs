using System.Collections.Generic;
using SimpleExpressions.Core.Parser;

namespace SimpleExpressions.Core.Converters.Grouping
{
    public class Together:BaseConverter
    {
        private readonly IList<string> functions = new List<string> { "Together" };
        public override IList<string> Functions
        {
            get { return this.functions; }
        }

        private const NodeType Type = NodeType.SilentNode;
        public override NodeType NodeType
        {
            get { return Type; }
        }

        public override IList<string> Generate(IList<Function> tokens, int currentIndex, IList<string> pattern)
        {
            pattern.Add(")");
            return pattern;
        }
    }
}
