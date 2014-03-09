using SimpleExpressions.Core.AbstractTree.Nodes;
using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Builders.Modifyers
{
    public class AndBuilder : BaseBuilder
    {
        public override INode AddNode(INode currentParent, IConverter converter)
        {
            var andNode = new AndNode(converter);

            //Qualify the parent
            var extensibleNode = currentParent as ExtensibleNode;
            if (extensibleNode != null)
                extensibleNode.ExtensionNode = andNode;

            return currentParent;
        }

        public override bool CanHandle(IConverter converter)
        {
            return converter is And;
        }
    }
}