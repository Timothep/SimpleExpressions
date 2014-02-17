using System;
using System.Collections.Generic;
using System.Linq;
using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree
{
    public interface IBuilder
    {
        void AddCurrentNode(INode current, IConverter converter);
        bool CanHandle(Function function);
    }

    public class ConcatBuilder: IBuilder
    {
        public void AddCurrentNode(INode current, IConverter converter)
        {
            throw new NotImplementedException();
        }

        public bool CanHandle(Function function)
        {
            throw new NotImplementedException();
        }
    }

    public class TextBuilder: IBuilder
    {
        private const string FunctionName = "Text";

        public void AddCurrentNode(INode current, IConverter converter)
        {
            throw new NotImplementedException();
        }

        public bool CanHandle(Function function)
        {
            return function.Name == FunctionName;
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

            INode root = null;
            var current = root;

            foreach (var converter in convertersChain)
            {
                var builder = GetBuilder(converter.Function);
                builder.AddCurrentNode(current, converter);
            }

            return root;
        }

        /// <summary>
        /// Searches for a corresponding Builder for the desired function
        /// </summary>
        /// <returns>If no builder is found, a "concat" builder is returned by default</returns>
        private IBuilder GetBuilder(Function function)
        {
            foreach (var builder in this.SpecializedBuilders.Where(builder => builder.CanHandle(function)))
                return builder;

            return new ConcatBuilder();
        }
    }
}
