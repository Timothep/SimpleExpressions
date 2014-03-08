using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Nodes
{
    public class NumbersInRangeNode : ValueNode
    {
        public NumbersInRangeNode(IConverter converter) : base(converter) { }

        public override string Generate()
        {
            var range = InRangeStaticHelper.CreateRange(this.Converter.Function.Arguments[0].ToString());
            return range;
        }
    }
}
