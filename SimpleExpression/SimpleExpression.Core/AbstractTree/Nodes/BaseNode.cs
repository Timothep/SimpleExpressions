using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Nodes
{
    public abstract class BaseNode : INode
    {
        public INode Parent { get; set; }
        public Cardinality Cardinality { get; set; }
        public IConverter Converter { get; set; }
        public abstract string Generate();

        protected BaseNode(IConverter converter)
        {
            this.Converter = converter;
            this.Cardinality = new Cardinality();
        }
    }
}