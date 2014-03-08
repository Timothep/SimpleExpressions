using System;
using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Nodes
{
    public class OrNode : BlockNode
    {
        public OrNode(IConverter converter) : base(converter) { }

        public override string Generate()
        {
            var concat = "";
            foreach (var child in this.Children)
            {
                if (concat != "")
                    concat += "|";

                if (child == null || child.Converter == null || child.Converter.Function == null
                    || child.Converter.Function.Arguments == null || child.Converter.Function.Arguments.Length < 1)
                    throw new NotImplementedException("Oh Oh");

                concat += child.Converter.Function.Arguments[0];
            }

            return string.Format("({0})", concat);
        }
    }
}
