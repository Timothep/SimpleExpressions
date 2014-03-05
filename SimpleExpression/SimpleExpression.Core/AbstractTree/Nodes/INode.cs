using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Nodes
{
    public interface INode
    {
        INode Parent { get; set; }
        Cardinality Cardinality { get; set; }
        string Generate();
        IConverter Converter { get; set; }
    }
}