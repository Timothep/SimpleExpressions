using System.Linq;

namespace SimpleExpressions.Core.AbstractTree.Nodes
{
    public class RootNode: BlockNode
    {
        public RootNode() : base(null) { }

        public override string Generate()
        {
            return this.Children.First().Generate();
        }
    }
}
