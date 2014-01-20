namespace SimpleExpressions.Core.SyntaxTree
{
    public class Node
    {
        public Node LeftSuccessor { get; set; }
        public Node RightSuccessor { get; set; }

        public Function Type { get; set; }
    }
}
