using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Nodes
{
    /// <summary>
    ///     A simple node having a text value
    /// </summary>
    public class TextNode : BaseNode
    {
        public TextNode(IConverter converter)
            : base(converter)
        {
            if (converter.Function != null && converter.Function.Arguments != null)
                this.Value = converter.Function.Arguments[0].ToString();
            else
                this.Value = "";
        }

        public string Value { get; set; }

        public override string Generate()
        {
            return this.Value;
        }
    }
}