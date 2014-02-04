namespace SimpleExpressions.Core.Parser
{
    public enum NodeType
    {
        SimpleNode = 0,
        HeadOperator,
        EnclosedOperator,
        PostfixedQualifier,
        PrefixedQualifier,
        SilentNode,
    }
}