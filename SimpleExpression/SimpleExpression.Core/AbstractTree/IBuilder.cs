using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree
{
    public interface IBuilder
    {
        INode AddNode(INode currentParent, IConverter converter);
        bool CanHandle(IConverter converter);
    }
}