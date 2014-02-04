using System.Collections.Generic;
using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.Parser
{
    public static class SyntaxFiller
    {
        /// <summary>
        ///   Crawls through a converter chain and adds the omited "FollowedBy" operators
        /// </summary>
        public static IList<IConverter> AddMissingOperators(IList<IConverter> converterChain)
        {
            var newChain = new List<IConverter>(0);
            for (var index = 0; index < converterChain.Count; index ++)
            {
                newChain.Add(converterChain[index]);

                if (index == converterChain.Count - 1) break;

                if (((converterChain[index].NodeType == NodeType.SimpleNode || converterChain[index].NodeType == NodeType.PostfixedQualifier || converterChain[index].NodeType == NodeType.SilentNode) && converterChain[index + 1].NodeType == NodeType.SimpleNode)
                    || (converterChain[index].NodeType == NodeType.SimpleNode && (converterChain[index + 1].NodeType == NodeType.HeadOperator || converterChain[index + 1].NodeType == NodeType.PrefixedQualifier)))
                    newChain.Add(new FollowedBy());
            }
            return newChain;
        }
    }
}