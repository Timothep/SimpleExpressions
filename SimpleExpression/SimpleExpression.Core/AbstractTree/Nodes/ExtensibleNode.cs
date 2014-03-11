using System.Collections.Generic;
using System.Linq;
using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Nodes
{
    public abstract class ExtensibleNode:ValueNode
    {
        protected ExtensibleNode(IConverter converter) : base(converter)
        {
            ExtensionNodesToAdd = new List<INode>(0);
            ExtensionNodesToSubstract = new List<INode>(0);
        }

        public IList<INode> ExtensionNodesToAdd { get; set; }
        public IList<INode> ExtensionNodesToSubstract { get; set; }

        protected string Pattern { get; set; }

        public override string Generate()
        {
            var result = this.Pattern;

            // if an AND node was attached
            if (this.ExtensionNodesToAdd != null && ExtensionNodesToAdd.Count > 0)
                result = result.Insert(result.Length - 1, this.ExtensionNodesToAdd.Aggregate("", (current, ext) => current + ext.Generate()));

            // if an EXCEPT node was attached
            if (this.ExtensionNodesToAdd != null && ExtensionNodesToSubstract.Count > 0)
            {
                var aggregate = string.Format("-[{0}]", this.ExtensionNodesToSubstract.Aggregate("", (current, ext) => current + ext.Generate()));
                result = result.Insert(result.Length - 1, aggregate);
            }

            // Default cardinality is "nothing", otherwise compute it:
            if (this.Cardinality.Min != null && this.Cardinality.Min != this.Cardinality.Max)
            {
                result += this.Cardinality;
            }

            return result;
        }
    }
}