﻿using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Nodes
{
    public class TextNode : ValueNode
    {
        public TextNode(IConverter converter) : base(converter) { }
    }
}