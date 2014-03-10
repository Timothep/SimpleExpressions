﻿using SimpleExpressions.Core.AbstractTree.Nodes;
using SimpleExpressions.Core.Converters;
using SimpleExpressions.Core.Converters.EitherOr;
using SimpleExpressions.Core.Exceptions;

namespace SimpleExpressions.Core.AbstractTree.Builders.Containers
{
    public class OrBuilder: BaseBuilder
    {
        public override INode AddNode(INode currentParent, IConverter converter)
        {
            INode newNode = new OrNode(converter);

            if(!(currentParent is EitherNode))
                throw new SyntaxException("An error occured while trying to handle an OR node. Its parent should be an EITHER node but wasn't.");

            this.LinkNodeToParent(currentParent.Parent, newNode);
            return newNode;
        }

        public override bool CanHandle(IConverter converter)
        {
            return converter is Or;
        }
    }
}
