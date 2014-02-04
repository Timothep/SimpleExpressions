namespace SimpleExpressions.Core.Parser
{
    public enum NodeType
    {
        SimpleNode = 0,
        Operator,
        PostfixedQualifier,
        PrefixedQualifier,
        SilentNode,
    }
}