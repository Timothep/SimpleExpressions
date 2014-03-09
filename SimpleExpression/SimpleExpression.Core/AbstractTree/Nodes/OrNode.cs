using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Nodes
{
    public class OrNode : BlockNode
    {
        public OrNode(IConverter converter) : base(converter) { }

        public override string Generate()
        {
            var concat = "";
            foreach (var child in this.Children)
            {
                if (concat != "")
                    concat += "|";

                concat += child.Generate();
            }

            return string.Format("({0})", concat);
        }
    }
}
