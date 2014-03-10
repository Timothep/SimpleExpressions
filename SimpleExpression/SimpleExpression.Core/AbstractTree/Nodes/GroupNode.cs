using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Nodes
{
    /// <summary>
    ///     Represents a group, e.g. a block that might have a name
    /// </summary>
    public class GroupNode : BlockNode
    {
        public string Name { get; set; }

        public GroupNode(IConverter converter, string name = "")
            : base(converter)
        {
            this.Name = name;
        }

        public override string Generate()
        {
            //var childrenAggregate = this.AggregateChildren();

            var alias = string.IsNullOrEmpty(this.Name) ? "" : string.Format("?<{0}>", this.Name);
            var cardinality = string.IsNullOrEmpty(this.Cardinality.ToString()) ? "" : this.Cardinality.ToString();

            var expression = (this.Converter.Function.Arguments[0] as SimpleExpression).Expression;
            return string.Format("({0}{1}){2}", alias, expression, cardinality);
        }
    }
}