using System.Collections.Generic;
using System.Linq;
using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.Rewriters
{
    public abstract class BaseRewriter : IRewriter
    {
        public abstract IList<IConverter> CompleteConverterChain(IList<IConverter> converterChain);

        /// <summary>
        ///   Recursively flattens a list of lists
        /// </summary>
        public static IList<IConverter> FlattenList(IEnumerable<object> listToFlatten)
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