using SimpleExpressions.Core.Converters;
using SimpleExpressions.Core.SpecializedSimpleExpression;

namespace SimpleExpressions.Core.AbstractTree.Nodes
{
    public class OrNode : BlockNode
    {
        public OrNode(IConverter converter) : base(converter) { }

        public override string Generate()
        {
            var expression = (this.Converter.Function.Arguments[0] as SimpleExpression).Expression;
            return string.Format("({0})", expression);
        }
    }
}
