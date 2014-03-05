using SimpleExpressions.Core.AbstractTree.Nodes;
using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Builders
{
    public interface IBuilder
    {
        INode AddNode(INode currentParent, IConverter converter);
        bool CanHandle(IConverter converter);
    }
}