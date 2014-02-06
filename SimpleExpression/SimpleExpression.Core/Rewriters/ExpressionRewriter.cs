using System.Collections.Generic;
using System.Linq;
using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.Rewriters
{
    public class ExpressionRewriter: IRewriter
    {
        private readonly IList<IRewriter> rewriters = new List<IRewriter>();

        public ExpressionRewriter()
        {
            this.rewriters.Add(new GroupRewriter());
            this.rewriters.Add(new SetRewriter());
            this.rewriters.Add(new RepeatRewriter());

            // Must be last
            this.rewriters.Add(new CardinalityRewriter());
        }

        public IList<IConverter> CompleteConverterChain(IList<IConverter> converterChain)
        {
            return this.rewriters.Aggregate(converterChain, (current, rewriter) => rewriter.CompleteConverterChain(current));
        }
    }
}