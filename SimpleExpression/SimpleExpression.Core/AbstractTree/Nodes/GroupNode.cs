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
            var alias = "";          //todo
            var childrenAggregate = this.AggregateChildren();
            var cardinality = "";    //todo

            return string.Format("({0}{1}{2})", alias, childrenAggregate, cardinality);
        }
    }
}