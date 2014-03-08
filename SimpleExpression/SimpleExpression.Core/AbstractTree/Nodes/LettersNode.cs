using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Nodes
{
    public class LettersNode : ExtensibleNode
    {
        public LettersNode(IConverter converter) : base(converter)
        {
            this.Pattern = "[a-zA-Z]";
        }
    }

    public abstract class ExtensibleNode:ValueNode
    {
        protected ExtensibleNode(IConverter converter) : base(converter) { }

        public INode ExtensionNode { get; set; }

        protected string Pattern { get; set; }

        public override string Generate()
        {
            var result = Pattern;

            // if an AND node was attached
            if (this.ExtensionNode != null)
                result = result.Insert(result.Length - 1, this.ExtensionNode.Generate());

            if (this.Cardinality.Min == null && this.Cardinality.Min == this.Cardinality.Max)
                result += "*";

            return string.IsNullOrEmpty(this.Cardinality.ToString()) ? result : string.Format("[{0}]{1}", result, this.Cardinality);
        }
    }
}
