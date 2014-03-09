using SimpleExpressions.Core.AbstractTree.Nodes;
using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Builders.Modifyers
{
    public class ExceptBuilder : BaseBuilder
    {
        public override INode AddNode(INode currentParent, IConverter converter)
        {
            var exceptNode = new ExceptNode(converter);

            //Qualify the parent
            var extensibleNode = currentParent as ExtensibleNode;
            if (extensibleNode != null)
                extensibleNode.ExtensionNodesToSubstract.Add(exceptNode);

            return currentParent;
        }

        public override bool CanHandle(IConverter converter)
        {
            return converter is Except;
        }
    }
}