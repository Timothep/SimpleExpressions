using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleExpressions.Core.Converters
{
    public static class ConverterStaticHelper
    {
        /// <summary>
        /// Function finding the matching "("
        /// </summary>
        /// <param name="pattern">The list of strings containing parenthesis</param>
        /// <param name="parenthesisToMatch">A tuple containing the location of the closing parenthesis to match Tuple(positionInTheList, positionInTheString)</param>
        /// <returns>A Tuple describing the position of the matching "(" or null</returns>
        public static Tuple<int, int> FindMatchingParenthesisIndex(IList<string> pattern, Tuple<int, int> parenthesisToMatch)
        {
            IList<Tuple<int, int>> stack = new List<Tuple<int, int>>(0);
            //Go through the list of strings
            for (var tokenIndex = 0; tokenIndex <= parenthesisToMatch.Item1; tokenIndex++)
            {
                //If we are in the token where the ")" is to be matched, go only up to the parenthesis, otherwise consider the whole string
                var maxBound = tokenIndex == parenthesisToMatch.Item1
                               ? parenthesisToMatch.Item2
                               : pattern[tokenIndex].Length;
                //Loop over each char of the strings
                for (var charIndex = 0; charIndex < maxBound; charIndex++)
                {
                    //Push
                    if (pattern[tokenIndex][charIndex] == '(')
                        stack.Add(new Tuple<int, int>(tokenIndex, charIndex));
                    //Pop
                    else if (pattern[tokenIndex][charIndex] == ')')
                        stack.Remove(stack.Last());
                }
            }
            //There should be only one
            return stack.FirstOrDefault();
        }
    }
}
