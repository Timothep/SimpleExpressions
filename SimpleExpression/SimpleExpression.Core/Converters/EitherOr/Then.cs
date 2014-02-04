using System.Collections.Generic;
using NodeType = SimpleExpressions.Core.Parser.NodeType;

namespace SimpleExpressions.Core.Converters.EitherOr
{
    public class Then: BaseConverter
    {
        private readonly IList<string> functions = new List<string> { "Then" };
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
            pattern.Add("))");
            return pattern;
        }
    }
}
