using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Nodes
{
    public class InRangeAbstractNode : ValueNode
    {
        public InRangeAbstractNode(IConverter converter) : base(converter) { }

        public override string Generate()
        {
            var range = InRangeStaticHelper.CreateRange(this.Converter.Function.Arguments[0].ToString());
            return range;
        }
    }
}