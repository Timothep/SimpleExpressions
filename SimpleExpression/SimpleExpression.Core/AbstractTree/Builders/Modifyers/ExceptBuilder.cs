using System.Linq;
using SimpleExpressions.Core.AbstractTree.Nodes;
using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Builders.Modifyers
{
    public class ExceptBuilder : BaseBuilder
    {
        public override INode AddNode(INode currentParent, IConverter converter)
        {
            var newNode = new ExceptNode(converter);

            //Qualify the preceding item
            var container = currentParent as IMotherNode;
            if (container != null)
            {
                var last = container.Children.Last() as ExtensibleNode;
                if (last != null) last.ExtensionNodesToSubstract.Add(newNode);
            }

            return currentParent;
        }

        public override bool CanHandle(IConverter converter)
        {
            return converter is Except;
        }
    }
}