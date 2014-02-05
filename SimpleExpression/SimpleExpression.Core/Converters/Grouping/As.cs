using System;
using System.Collections.Generic;
using System.Linq;
 

namespace SimpleExpressions.Core.Converters.Grouping
{
    public class As : BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "As" };
        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }

        public override IList<string> Generate(IList<string> regularExpressionSofar)
        {
            var currentToken = this.Function;
            
            if (currentToken.Arguments.Length != 1)
                throw new ArgumentException("Incorrect number of arguments found");
            
            var arg = currentToken.Arguments[0];

            //Build the string to insert
            var namedGroup = string.Format("?<{0}>", arg);

            ////Handle a "Group.xyz.As()" without "Together"
            //var lastPatternToken = regularExpressionSofar.Last();
            //if (!lastPatternToken.EndsWith(")"))
            //{
            //    var correctedLastPatternToken = lastPatternToken + ")";
            //    regularExpressionSofar.Remove(lastPatternToken);
            //    regularExpressionSofar.Add(correctedLastPatternToken);
            //}

            ////Find the location of the matching parenthesis
            //var openingParenthesisLocation = ConverterStaticHelper.FindMatchingParenthesisIndex(regularExpressionSofar, new Tuple<int, int>(regularExpressionSofar.Count - 1, lastPatternToken.Length - 1));

            ////Insert the string
            //var patternToEdit = regularExpressionSofar[openingParenthesisLocation.Item1];
            //var editedGroup = patternToEdit.Insert(openingParenthesisLocation.Item2 + 1, namedGroup);

            ////Insert the group in the list
            //regularExpressionSofar.RemoveAt(openingParenthesisLocation.Item1);
            //regularExpressionSofar.Insert(openingParenthesisLocation.Item1, editedGroup);

            regularExpressionSofar.Add(namedGroup);

            return regularExpressionSofar;
        }
    }
}
