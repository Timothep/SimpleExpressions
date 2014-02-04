using System.Collections.Generic;
using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.Parser
{
    public class SyntaxFiller
    {
        public IList<IConverter> AddMissingOperators(IList<IConverter> converterChain)
        {
            var newChain = new List<IConverter>(0);
            for (var index = 0; index < converterChain.Count; index ++)
            {
                newChain.Add(converterChain[index]);

                if (index == converterChain.Count - 1)
                    break;

                if ((converterChain[index].NodeType != NodeType.Operator && converterChain[index].NodeType != NodeType.PrefixedQualifier && converterChain[index + 1].NodeType == NodeType.SimpleNode) ||
                    (converterChain[index].NodeType == NodeType.SimpleNode && (converterChain[index + 1].NodeType == NodeType.Operator || converterChain[index + 1].NodeType == NodeType.PrefixedQualifier)))
                    newChain.Add(new FollowedBy());
            }

            return newChain;
        }
    }
}
