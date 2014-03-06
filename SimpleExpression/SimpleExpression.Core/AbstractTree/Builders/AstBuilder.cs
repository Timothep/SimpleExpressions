using System;
using System.Collections.Generic;
using System.Linq;
using SimpleExpressions.Core.AbstractTree.Nodes;
using SimpleExpressions.Core.Converters;
using TinyIoC;

namespace SimpleExpressions.Core.AbstractTree.Builders
{
    /// <summary>
    ///     Class wrapping the abstract syntax tree building logic
    /// </summary>
    public class AstBuilder
    {
        public AstBuilder()
        {
            // Lazy load all the available builders
            var container = TinyIoCContainer.Current;
            container.AutoRegister(DuplicateImplementationActions.RegisterMultiple);
            this.SpecializedBuilders = container.ResolveAll<IBuilder>().ToList();

            //this.SpecializedBuilders = new List<IBuilder>
            //    {
            //        new ConcatBuilder(),
            //        new TextBuilder(),
            //        new GroupBuilder(),
            //        new TogetherBuilder(),
            //        new CardinalityBuilder(),
            //        new MaybeBuilder(),
            //        new AsBuilder(),
            //    };
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
}