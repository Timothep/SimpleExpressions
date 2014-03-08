using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleExpressions.Core.AbstractTree.Nodes;
using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Builders
{
    class NumbersInRangeBuilder: LeafBuilder
    {
        protected override INode GetNode(IConverter converter)
        {
            return new NumbersInRangeNode(converter);
        }

        public override bool CanHandle(IConverter converter)
        {
            return converter is NumbersInRange;
        }
    }
}
