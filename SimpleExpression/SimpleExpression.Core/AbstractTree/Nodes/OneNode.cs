using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Nodes
{
    public class OneNode : ValueNode
    {
        public OneNode(IConverter converter) : base(converter) { }

        public override string Generate()
        {
            if(this.Value == ".")
                this.Value = this.Value.Insert(0,@"\");

            return base.Generate();
        }
    }
}