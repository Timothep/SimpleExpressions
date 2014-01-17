using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleExpressions.Core.Converters
{
    public class As : BaseConverter
    {
        private readonly IList<string> functions = new List<string> { "As" };
        public override IList<string> Functions
        {
            get { return this.functions; }
        }

        public override IList<string> Generate(IList<Function> tokens, int currentIndex, IList<string> pattern)
        {
            //Handle arguments
            var currentToken = tokens[currentIndex];
            if (currentToken.Arguments.Length != 1)
                throw new ArgumentException("Incorrect number of arguments found");
            var arg = currentToken.Arguments[0];

            //Build the string to insert
            var namedGroup = string.Format("?<{0}>", arg);

            //Handle a "Group.xyz.As()" without "Together"
            var lastPatternToken = pattern.Last();
            if (!lastPatternToken.EndsWith(")"))
            {
                var correctedLastPatternToken = lastPatternToken + ")";
                pattern.Remove(lastPatternToken);
                pattern.Add(correctedLastPatternToken);
            }

            //Find the location of the matching parenthesis
            var openingParenthesisLocation = ConverterStaticHelper.FindMatchingParenthesisIndex(pattern, new Tuple<int, int>(pattern.Count - 1, lastPatternToken.Length - 1));

            //Insert the string
            var patternToEdit = pattern[openingParenthesisLocation.Item1];
            var editedGroup = patternToEdit.Insert(openingParenthesisLocation.Item2 + 1, namedGroup);

            //Insert the group in the list
            pattern.RemoveAt(openingParenthesisLocation.Item1);
            pattern.Insert(openingParenthesisLocation.Item1, editedGroup);

            return pattern;
        }
    }
}
