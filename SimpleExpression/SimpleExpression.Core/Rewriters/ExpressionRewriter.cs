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
            this.rewriters.Add(new RepeatRewriter());
        }

        public IList<IConverter> CompleteConverterChain(IList<IConverter> converterChain)
        {
            /* Analyze the complete chain and perform the necessary adjustments
             * ----------------------------------------------------------------
             * Group.X.Together.As -> Group.As.X.Together
             * 
             * OneOrMore.X -> OneOrMore.X.EndOneOrMore
             * ZeroOrMore.X -> ZeroOrMore.X.EndZeroOrMore
             * 
             * X.AtLeast.AtMost/Exactly
             * 
             * Repeat.X.AtLeast.AtMost/Exactly.Times -> Repeat.X.Times.AtLeast.AtMost/Exactly
             * 
             * Maybe.X -> Maybe.X.EndMaybe
             * 
            */

            return this.rewriters.Aggregate(converterChain, (current, rewriter) => rewriter.CompleteConverterChain(current));
        }
    }
}