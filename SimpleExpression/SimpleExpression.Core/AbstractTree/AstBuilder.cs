using System;
using System.Collections.Generic;
using System.Linq;
using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree
{
    /// <summary>
    /// Class wrapping the abstract syntax tree building logic
    /// </summary>
    public class AstBuilder
    {
        /// <summary>
        /// The available builders
        /// </summary>
        public IList<IBuilder> SpecializedBuilders { get; set; }
        
        public AstBuilder()
        {
            SpecializedBuilders = new List<IBuilder>
                {
                    new ConcatBuilder(),
                    new TextBuilder(),
                    new GroupBuilder(),
                    new TransparentBuilder(),
                };
        }

        /// <summary>
        /// Generates the corresponding AST based on a chain of IConverters
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

        /// <summary>
        /// Navigates an AST and returns the root node
        /// </summary>
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
