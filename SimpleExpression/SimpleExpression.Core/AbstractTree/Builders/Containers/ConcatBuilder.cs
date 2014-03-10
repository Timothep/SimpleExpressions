using System;
using SimpleExpressions.Core.AbstractTree.Nodes;
using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Builders.Containers
{
    public class ConcatBuilder: IBuilder
    {
        public INode AddNode(INode currentParent, IConverter converter)
        {
            throw new NotImplementedException("42... or not. No no, blue, you're right, blue. Or Sun!");
        }

        public bool CanHandle(IConverter converter)
        {
            return false;
        }
    }
}