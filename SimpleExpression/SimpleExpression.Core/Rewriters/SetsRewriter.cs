using System.Collections.Generic;
using System.Linq;
using SimpleExpressions.Core.Converters;
using SimpleExpressions.Core.Converters.Sets;

namespace SimpleExpressions.Core.Rewriters
{
    public class SetsRewriter : BaseRewriter
    {
        /// <summary>
        ///   Adds the "Set" and "EndSet" around a set definition
        /// </summary>
        public override IList<IConverter> CompleteConverterChain(IList<IConverter> converterChain)
        {
            IList<object> mainList = new List<object>(0);
            IList<IList<object>> listStack = new List<IList<object>>(0);
            listStack.Add(mainList);

            for (var index = 0; index < converterChain.Count; index++)
            {
                var currentList = listStack.Last();
                if (IsSimpleSet(converterChain[index]))
                {
                    currentList.Add(new Set());

                    if (!NumbersFollowedByInRange(converterChain, index))
                        currentList.Add(converterChain[index]);

                    if(index + 1 == converterChain.Count || !IsQualifier(converterChain[index + 1]))
                        currentList.Add(new EndSet());
                }
                else if (IsQualifier(converterChain[index]))
                {
                    currentList.Add(converterChain[index]);

                    if (index + 1 == converterChain.Count || !IsQualifier(converterChain[index - 1]))
                        currentList.Add(new EndSet());
                }
                else
                    currentList.Add(converterChain[index]);
            }

            return FlattenList(mainList);
        }

        private static bool NumbersFollowedByInRange(IList<IConverter> converterChain, int index)
        {
            return converterChain[index] is Numbers && index + 1 < converterChain.Count && converterChain[index + 1] is InRange;
        }
    }
}