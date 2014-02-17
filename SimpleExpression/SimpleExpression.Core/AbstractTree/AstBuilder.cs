using System;
using System.Collections.Generic;
using System.Linq;
using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree
{
    public interface IBuilder
    {
        INode AddNode(INode currentParent, IConverter converter);
        bool CanHandle(IConverter converter);
    }

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

    public class TextBuilder: IBuilder
    {
        public INode AddNode(INode currentParent, IConverter converter)
        {
            INode textNode = null;

            // If the currentParent is not an IMotherNode
            if (!(currentParent is IMotherNode))
            {
                // If the currentParent has no parent
                if (currentParent == null)
                {
                    var concat = new ConcatNode { Cardinality = new Cardinality() };
                    currentParent = concat;
                    textNode = new TextNode { Cardinality = new Cardinality(), Parent = currentParent };
                    (currentParent as IMotherNode).AddChild(textNode);
                }
                // If the parent cannot host a child, dock it to its parent
                else if (currentParent.Parent is IMotherNode)
                {
                    textNode = new TextNode { Cardinality = new Cardinality(), Parent = currentParent.Parent };
                    (currentParent.Parent as IMotherNode).AddChild(textNode);
                }
                else
                    throw new NotImplementedException("No correct node found for insertion");
            }
            
            return textNode;
        }

        public bool CanHandle(IConverter converter)
        {
            return converter is Text;
        }
    }

    public class AstBuilder
    {
        public IList<IBuilder> SpecializedBuilders { get; set; }
        
        public AstBuilder()
        {
            SpecializedBuilders = new List<IBuilder>
                {
                    new ConcatBuilder(),
                    new TextBuilder(),
                };
        }

        /// <summary>
        /// Chain in, Tree out
        /// </summary>
        public INode GenerateAst(IList<IConverter> convertersChain)
        {
            if (convertersChain == null)
                throw new ArgumentException("Cannot create an AST on a null chain");

            INode current = null;

            foreach (var converter in convertersChain)
            {
                var builder = this.GetAdequateBuilder(converter);

                current = builder.AddNode(current, converter);
            }

            return GetRoot(current);
        }

        private INode GetRoot(INode current)
        {
            while (current.Parent != null)
                current = current.Parent;
            return current;
        }

        /// <summary>
        /// Searches for a corresponding Builder for the desired function
        /// </summary>
        /// <returns>If no builder is found, a "concat" builder is returned by default</returns>
        private IBuilder GetAdequateBuilder(IConverter converter)
        {
            foreach (var builder in this.SpecializedBuilders.Where(builder => builder.CanHandle(converter)))
                return builder;

            return new ConcatBuilder();
        }
    }
}
