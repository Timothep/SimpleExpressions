using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleExpressions.Core.Converters.Repetitions
{
    public class AtMost:BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "AtMost" };
        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }

        public override IList<string> Generate(IList<string> regularExpressionSofar)
        {
            //var currentToken = this.Function;

            //if (currentToken.Arguments.Length != 1)
            //    throw new ArgumentException("Incorrect number of arguments found");

            ////If it is the first after the repeat, close the ")"
            //if (IsPartOfARepeatLoop(tokens, currentIndex) && tokens[currentIndex - 1].Name != "AtLeast")
            //    regularExpressionSofar.Add(")");

            //var lastPatternToken = regularExpressionSofar.Last();

            //regularExpressionSofar.Remove(lastPatternToken);
            //regularExpressionSofar.Add(lastPatternToken.Insert(lastPatternToken.Length - 1, currentToken.Arguments[0].ToString()));

            return regularExpressionSofar;
        }

        private static bool IsPartOfARepeatLoop(IList<Function> tokens, int currentIndex)
        {
            //If there is a "Times" functionName on the right (maybe with a AtMost() in between)
            if (tokens.Count > (currentIndex + 1) && tokens[currentIndex + 1].Name == "Times")
                return true;

            return false;
        }
    }
}
