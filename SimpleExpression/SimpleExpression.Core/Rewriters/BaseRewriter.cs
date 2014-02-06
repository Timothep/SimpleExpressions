using System.Collections.Generic;
using System.Linq;
using SimpleExpressions.Core.Converters;
using SimpleExpressions.Core.Converters.Repetitions;
using SimpleExpressions.Core.Converters.Sets;

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

        public static bool IsContentElement(IConverter converter)
        {
            return converter is Letters || converter is Numbers || converter is Alphanumerics || converter is Text 
                || converter is One || converter is OneOf || converter is EitherOf || converter is Anything || converter is Maybe;
        }

        public static bool IsRepetitionQualifier(IConverter converter)
        {
            return converter is Exactly || converter is AtLeast || converter is AtMost;
        }

        public static bool IsRepetitionBounds(IConverter converter)
        {
            return converter is RepetitionQualifier || converter is EndRepetitionQualifier;
        }

        public bool IsSimpleSet(IConverter converter)
        {
            return converter is Letters || converter is Numbers || converter is Alphanumerics;
        }

        public bool IsModifier(IConverter converter)
        {
            return converter is Except || converter is InRange;
        }
    }
}