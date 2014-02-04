using System.Collections.Generic;
using SimpleExpressions.Core.Converters;
using SimpleExpressions.Core.Converters.Grouping;

namespace SimpleExpressions.Core.Rewriters
{
    public class GroupRewriter: IRewriter
    {
        public IList<IConverter> CompleteConverterChain(IList<IConverter> converterChain)
        {
            // Go through the whole chain and mark the groups
            IList<Sequence> groupSequences = new List<Sequence>(0);
            var currentBlock = -1;

            for (var index = 0; index < converterChain.Count; index++)
            {
                if (converterChain[index] is Group)
                {
                    groupSequences.Add(new Sequence {GroupIndex = index});
                    currentBlock++;
                }
                else if (converterChain[index] is Together)
                {
                    groupSequences[currentBlock].TogetherIndex = index;
                    if ((converterChain.Count > index + 1) && !(converterChain[index + 1] is As))
                        currentBlock--;
                }
                else if (converterChain[index] is As)
                {
                    groupSequences[currentBlock].AsIndex = index;
                    currentBlock--;
                }
            }

            // Go through the chain once more and replace the elements
            IList<IConverter> fixedChain = new List<IConverter>(0);
            for (var index = 0; index < converterChain.Count; index++)
            {

            }

            return converterChain;
        }

        internal class Sequence
        {
            internal int GroupIndex;
            internal int TogetherIndex;
            internal int AsIndex;
        }
    }
}