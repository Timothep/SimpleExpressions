using System.Collections.Generic;
using System.Linq;
using SimpleExpressions.Core.Converters;
using SimpleExpressions.Core.Converters.Grouping;

namespace SimpleExpressions.Core.Rewriters
{
    public class GroupRewriter : IRewriter
    {
        /// <summary>
        ///   Inserts the "Together" instruction - if missing - and moves the "As" instruction - if present - right after the "Group"
        /// </summary>
        public IList<IConverter> CompleteConverterChain(IList<IConverter> converterChain)
        {
            // Split the groups in lists
            IList<object> mainList = new List<object>(0);
            IList<IList<object>> listStack = new List<IList<object>>(0);
            listStack.Add(mainList);

            for (var index = 0; index < converterChain.Count; index++)
            {
                var currentList = listStack.Last();
                if (converterChain[index] is Group)
                {
                    // Create a new list
                    var newList = new List<object> {converterChain[index]};
                    // Link it to the current one
                    currentList.Add(newList);
                    // Add the new list onto the stack
                    listStack.Add(newList);
                }
                else if (converterChain[index] is As)
                {
                    // Sneak a Together if needed
                    if (!(converterChain[index - 1] is Together))
                        listStack.Last().Add(new Together());
                    // Move As the second place
                    currentList.Insert(1, converterChain[index]);
                    // Unstack that list
                    listStack.RemoveAt(listStack.Count - 1);
                }
                else
                    currentList.Add(converterChain[index]);
            }

            return FlattenList(mainList);
        }

        /// <summary>
        ///   Recursively flattens a list of lists
        /// </summary>
        private static IList<IConverter> FlattenList(IEnumerable<object> listToFlatten)
        {
            var outputList = new List<IConverter>(0);
            foreach (var element in listToFlatten)
            {
                if (element is IConverter)
                    outputList.Add(element as IConverter);
                else
                    outputList = outputList.Concat(FlattenList(element as IList<object>)).ToList();
            }
            return outputList;
        }
    }
}