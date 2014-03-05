using SimpleExpressions.Core.AbstractTree.Nodes;
using SimpleExpressions.Core.Converters;
using SimpleExpressions.Core.Converters.Grouping;

namespace SimpleExpressions.Core.AbstractTree.Builders
{
    public class TogetherBuilder: BaseBuilder
    {
        public override INode AddNode(INode currentParent, IConverter converter)
        {
            //Navigate back to the last group in the chain
            while (currentParent != null && !(currentParent is GroupNode))
                currentParent = currentParent.Parent;

            //Make its parent the new root
            if(currentParent != null && currentParent.Parent != null)
                currentParent = currentParent.Parent;

            return currentParent;
        }

        public override bool CanHandle(IConverter converter)
        {
            return converter is Together;
        }
    }
}