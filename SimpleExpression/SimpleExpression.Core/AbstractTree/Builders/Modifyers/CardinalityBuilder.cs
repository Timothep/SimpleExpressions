using System;
using System.Linq;
using SimpleExpressions.Core.AbstractTree.DomainObjects;
using SimpleExpressions.Core.AbstractTree.Nodes;
using SimpleExpressions.Core.Converters;
using SimpleExpressions.Core.Converters.Repetitions;
using SimpleExpressions.Core.Exceptions;

namespace SimpleExpressions.Core.AbstractTree.Builders.Modifyers
{
    public class CardinalityBuilder : BaseBuilder
    {
        public override INode AddNode(INode currentParent, IConverter converter)
        {
            //Qualify the preceding item
            var container = currentParent as IMotherNode;
            if (container != null)
            {
                var last = container.Children.Last();
                if (last == null)
                    throw new SyntaxException(
                        "Could not find an element to qualify with the cardinality information. Please check your syntax, elements like 'AtLeast', 'AtMost' & 'Exactly' are to be placed after the elements they qualify.");

                // Modify the item
                var card = last.Cardinality ?? new Cardinality();

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
            }

            return currentParent;
        }

        public override bool CanHandle(IConverter converter)
        {
            return converter is AtLeast
                   || converter is AtMost
                   || converter is Exactly;
        }
    }
}