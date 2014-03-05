using System;
using System.Collections.Generic;
using System.Linq;
using SimpleExpressions.Core.AbstractTree.Nodes;
using SimpleExpressions.Core.Converters;
using SimpleExpressions.Core.Converters.Repetitions;

namespace SimpleExpressions.Core.AbstractTree.Builders
{
    /// <summary>
    ///     Class wrapping the abstract syntax tree building logic
    /// </summary>
    public class AstBuilder
    {
        public AstBuilder()
        {
            this.SpecializedBuilders = new List<IBuilder>
                {
                    new ConcatBuilder(),
                    new TextBuilder(),
                    new GroupBuilder(),
                    new TogetherBuilder(),
                    new CardinalityBuilder(),
                };
        }

        /// <summary>
        ///     The available builders
        /// </summary>
        public IList<IBuilder> SpecializedBuilders { get; set; }

        /// <summary>
        ///     Generates the corresponding AST based on a chain of IConverters
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

            return current != null ? this.GetRoot(current) : null;
        }

        /// <summary>
        ///     Navigates an AST and returns the root node
        /// </summary>
        private INode GetRoot(INode current)
        {
            while (current.Parent != null)
                current = current.Parent;
            return current;
        }

        /// <summary>
        ///     Searches for a corresponding Builder for the desired function
        /// </summary>
        /// <returns>If no builder is found, a "concat" builder is returned by default</returns>
        private IBuilder GetAdequateBuilder(IConverter converter)
        {
            foreach (var builder in this.SpecializedBuilders.Where(builder => builder.CanHandle(converter)))
                return builder;

            return new ConcatBuilder();
        }
    }

    public class CardinalityBuilder : BaseBuilder
    {
        public override INode AddNode(INode currentParent, IConverter converter)
        {
            // Do not add a node but instead modify the parent
            var card = currentParent.Cardinality ?? new Cardinality();
            
            if (converter is AtLeast)
                card.Min = Convert.ToInt32(converter.Function.Arguments[0]);
            else if (converter is AtMost)
                card.Max = Convert.ToInt32(converter.Function.Arguments[0]);
            else if (converter is Exactly)
            {
                card.Min = null;
                card.Max = Convert.ToInt32(converter.Function.Arguments[0]);
            }
            else
                throw new NotImplementedException("Seriously not implemented");

            return currentParent;
        }

        public override bool CanHandle(IConverter converter)
        {
            return  converter is AtLeast 
                || converter is AtMost
                || converter is Exactly;
        }
    }
}