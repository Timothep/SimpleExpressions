using System.Collections.Generic;
using System.Linq;
using SimpleExpressions.Core.Converters;
using SimpleExpressions.Core.Converters.Repetitions;

namespace SimpleExpressions.Core.Rewriters
{
    public class RepeatRewriter : BaseRewriter
    {
        /// <summary>
        ///   Moves the "Times" instruction before the "AtLeast/AtMost/Exactly" ones.
        ///   Insert qualifier bounds around the "AtLeast/AtMost/Exactly"
        /// </summary>
        public override IList<IConverter> CompleteConverterChain(IList<IConverter> converterChain)
        {
            IList<object> mainList = new List<object>(0);
            IList<IList<object>> listStack = new List<IList<object>>(0);
            listStack.Add(mainList);

            for (var index = 0; index < converterChain.Count; index++)
            {
                var currentList = listStack.Last();
                if (converterChain[index] is Repeat)
                {
                    var newList = new List<object> {converterChain[index]};
                    currentList.Add(newList);
                    listStack.Add(newList);
                }
                else if (IsRepetitionQualifier(converterChain[index]))
                {
                    // If the previous element is not a repetition qualifier
                    if (!IsRepetitionQualifier(converterChain[index - 1]))
                        currentList.Add(new RepetitionQualifier());

                    currentList.Add(converterChain[index]);

                    //If the next element is not a repetition qualifier
                    if(index + 1 == converterChain.Count || !IsRepetitionQualifier(converterChain[index + 1]))
                        currentList.Add(new EndRepetitionQualifier());
                }
                else if (converterChain[index] is Times)
                {
                    var insertionIndex = FindTimesInsertionSpot(currentList);
                    currentList.Insert(insertionIndex, converterChain[index]);
                    listStack.RemoveAt(listStack.Count - 1);
                }
                else
                    currentList.Add(converterChain[index]);
            }

            return FlattenList(mainList);
        }

        private static int FindTimesInsertionSpot(IList<object> currentList)
        {
            var insertionPoint = currentList.Count - 1;

            while (insertionPoint >= 0)
            {
                if (currentList[insertionPoint] is RepetitionQualifier)
                    return insertionPoint;
                insertionPoint--;
            }

            return insertionPoint;
        }
    }
}