using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleExpressions.Core.AbstractTree.Nodes;
using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Builders
{
    public class EitherOfBuilder : LeafBuilder
    {
        protected override INode GetNode(IConverter converter)
        {
            return new EitherOfNode(converter);
        }

        public override bool CanHandle(IConverter converter)
        {
            return converter is EitherOf;
        }
    }
}
