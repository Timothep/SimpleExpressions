using System.Collections.Generic;
using System.Linq;
using SimpleExpressions.Core.Converters;
using SimpleExpressions.Core.Converters.Sets;

namespace SimpleExpressions.Core.Rewriters
{
    public class SetRewriter : BaseRewriter
    {
        /// <summary>
        ///   Adds the "SetBegin" and "SetEnd" around a set definition
        /// </summary>
        public override IList<IConverter> CompleteConverterChain(IList<IConverter> converterChain)
        {
            // Split the groups in lists
            IList<object> mainList = new List<object>(0);
            IList<IList<object>> listStack = new List<IList<object>>(0);
            listStack.Add(mainList);

            for (var index = 0; index < converterChain.Count; index++)
            {
                var currentList = listStack.Last();
                if (IsContentElement(converterChain[index]))
                {
                    //If no modifier afterwards do not wrap
                    if (NextElementIsModifier(converterChain, index))
                    {
                        // Create a new list
                        var newList = new List<object> {new SetBegin(), converterChain[index]};
                        // Link it to the current one
                        currentList.Add(newList);
                        // Add the new list onto the stack
                        listStack.Add(newList);
                    }
                    else
                        currentList.Add(converterChain[index]);
                }
                else if (IsModifier(converterChain[index]) && !NextElementIsModifier(converterChain, index))
                {
                    currentList.Add(converterChain[index]);
                    //Close the set
                    currentList.Add(new SetEnd());
                    //Unstack
                    listStack.RemoveAt(listStack.Count - 1);
                }
                else
                    currentList.Add(converterChain[index]);
            }

            return FlattenList(mainList);
        }

        private bool NextElementIsModifier(IList<IConverter> converterChain, int index)
        {
            return index + 1 < converterChain.Count && IsModifier(converterChain[index + 1]);
        }

        private static bool NumbersFollowedByInRange(IList<IConverter> converterChain, int index)
        {
            return converterChain[index] is Numbers && index + 1 < converterChain.Count && converterChain[index + 1] is InRange;
        }
    }
}