using System.Collections.Generic;
using System.Linq;
using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.Parser
{
    public abstract class BaseParser
    {
        protected Node CurrentRoot;
        public abstract Node Parse(IList<IConverter> chainStack);

        /// <summary>
        /// Links the first node to the second
        /// </summary>
        protected void LinkAsChild(Node nodeToAdd, Node hostNode)
        {
            if (hostNode.CurrentSide == Side.Left)
                hostNode.LeftChild = nodeToAdd;
            else
                hostNode.RightChild = nodeToAdd;
        }
    }

    public class Parser : BaseParser
    {
        /// <summary>
        /// Function creating an AST
        /// </summary>
        /// <param name="chainStack">A stack made by reversing the parsed converter chain</param>
        public override Node Parse(IList<IConverter> chainStack)
        {
            if (chainStack == null || chainStack.Count == 0)
                return CurrentRoot;

            var currentElement = new Node(chainStack.First());

            // First element case
            if (CurrentRoot == null)
            {
                CurrentRoot = currentElement;
                
                chainStack.RemoveAt(0);
                this.Parse(chainStack);
                return CurrentRoot;
            }
            
            // Simple element case
            if (currentElement.Converter.NodeType == NodeType.SimpleNode)
            {
                // Link the current element as child of the current root
                LinkAsChild(currentElement, CurrentRoot);
            
                chainStack.RemoveAt(0);
                this.Parse(chainStack);
                return CurrentRoot;
            }

            // FollowedBy (and other HeadOperators?) case
            if (currentElement.Converter is FollowedBy)
            {
                // Link the current root as child of this element
                LinkAsChild(CurrentRoot, currentElement);
                // Update the root to this element
                CurrentRoot = currentElement;
                // Unstack
                chainStack.RemoveAt(0);
                // Iterate
                this.Parse(chainStack);
                // Return the last root
                return CurrentRoot;
            }

            //// Repeat case
            //if (currentElement.Converter is Times)
            //{
            //    // Times is silent, remove it
            //    chainStack.RemoveAt(0); 
            //    // Create a RepeatParser
            //    var repeatParser = new RepeatParser();
            //    var repeatRoot = repeatParser.Parse(chainStack);
            //    // Link the repeat block under the root
            //    LinkAsChild(repeatRoot, CurrentRoot);
            //    // Return the last root
            //    return CurrentRoot;
            //}

            return CurrentRoot;
        }
    }

    //public class RepeatParser : BaseParser
    //{
    //    public override Node Parse(IList<IConverter> chainStack)
    //    {
    //        var currentElement = new Node(chainStack.First());

    //        // First element case
    //        if (CurrentRoot == null)
    //        {
    //            // Update the root
    //            CurrentRoot = currentElement;
    //            // Unstack
    //            chainStack.RemoveAt(0);
    //            // Iterate
    //            this.Parse(chainStack);
    //            // Return the last root
    //            return CurrentRoot;
    //        }

    //        return null;
    //    }
    //}

    public class Node
    {
        private Node rightChild;
        public Node RightChild
        {
            get { return rightChild; }
            set
            {
                rightChild = value; 
                CurrentSide = Side.Left;
            }
        }

        private Node leftChild;
        public Node LeftChild
        {
            get { return leftChild; } 
            set 
            { 
                leftChild = value; 
                CurrentSide = Side.Right; 
            }
        }

        private Side currentSide = Side.Right;
        public Side CurrentSide
        {
            get { return currentSide; }
            set { currentSide = value; }
        }
        public IConverter Converter { get; set; }

        public Node(IConverter converter)
        {
            Converter = converter;
        }
    }

    public enum Side
    {
        Left = 0,
        Right,
    }
}
