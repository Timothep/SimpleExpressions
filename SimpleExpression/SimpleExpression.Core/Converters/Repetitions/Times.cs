using System.Collections.Generic;
using SimpleExpressions.Core.Parser;

namespace SimpleExpressions.Core.Converters.Repetitions
{
    public class Times : BaseConverter
    {
        private readonly IList<string> functions = new List<string> {"Times", "Time"};
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
            return pattern;
        }
    }
}
