using System.Collections.Generic;
using System.Linq;
using SimpleExpressions.Core.Converters;
using SimpleExpressions.Core.Converters.Repetitions;
using SimpleExpressions.Core.Converters.Sets;

namespace SimpleExpressions.Core.Rewriters
{
    public class CardinalityRewriter : BaseRewriter
    {
        /// <summary>
        ///   Add a star after a Letters/Numbers/Alphanumerics that is not followed by a cardinality specifier
        /// </summary>
        public override IList<IConverter> CompleteConverterChain(IList<IConverter> converterChain)
        {
            IList<object> mainList = new List<object>(0);
            IList<IList<object>> listStack = new List<IList<object>>(0);
            listStack.Add(mainList);

            for (var index = 0; index < converterChain.Count; index++)
            {
                var currentList = listStack.Last();
                if (converterChain[index] is SetEnd
                    && (index + 1 == converterChain.Count || !(IsRepetitionQualifier(converterChain[index + 1]) || IsRepetitionBounds(converterChain[index + 1]))))
                {
                    currentList.Add(converterChain[index]);
                    currentList.Add(new RepeatWildcard());
                }
                else
                    currentList.Add(converterChain[index]);
            }

            return FlattenList(mainList);
        }
    }
}