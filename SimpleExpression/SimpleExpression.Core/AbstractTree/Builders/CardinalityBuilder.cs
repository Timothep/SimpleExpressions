using System;
using SimpleExpressions.Core.AbstractTree.Nodes;
using SimpleExpressions.Core.Converters;
using SimpleExpressions.Core.Converters.Repetitions;

namespace SimpleExpressions.Core.AbstractTree.Builders
{
    public class CardinalityBuilder : BaseBuilder
    {
        public override INode AddNode(INode currentParent, IConverter converter)
        {
            // Do not add a node but instead modify the parent
            var card = currentParent.Cardinality ?? new Cardinality();
            
            if (converter is AtLeast)
                card.Min = Convert.ToInt32(converter.Function.Arguments[0]);
            else if (converter is AtMost)
                card.Max = Convert.ToInt32(converter.Function.Arguments[0]);
            else if (converter is Exactly)
            {
                card.Min = Convert.ToInt32(converter.Function.Arguments[0]);
                card.Max = Convert.ToInt32(converter.Function.Arguments[0]);
            }
            else
                throw new NotImplementedException("Seriously not implemented");

            return currentParent;
        }

        public override bool CanHandle(IConverter converter)
        {
            return  converter is AtLeast 
                    || converter is AtMost
                    || converter is Exactly;
        }
    }
}