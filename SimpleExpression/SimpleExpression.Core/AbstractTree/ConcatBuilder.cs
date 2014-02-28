using System;
using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree
{
    public class ConcatBuilder: IBuilder
    {
        public INode AddNode(INode currentParent, IConverter converter)
        {
            throw new NotImplementedException();
        }

        public bool CanHandle(IConverter converter)
        {
            return false;
        }
    }
}