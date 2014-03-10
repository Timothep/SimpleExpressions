using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Nodes
{
    public class EitherNode : BlockNode
    {
        public EitherNode(IConverter converter) : base(converter) { }

        public override string Generate()
        {
            var expression = (this.Converter.Function.Arguments[0] as SimpleExpression).Expression;
            return string.Format("({0})|", expression);
        }
    }
}
