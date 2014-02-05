using System;
using System.Collections.Generic;
using System.Linq;
 

namespace SimpleExpressions.Core.Converters.Repetitions
{
    public class AtLeast : BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "AtLeast" };
        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }

        public override IList<string> Generate(IList<string> regularExpressionSofar)
        {
            var currentToken = this.Function;

            if (currentToken.Arguments.Length != 1)
                throw new ArgumentException("Incorrect number of arguments found");

            regularExpressionSofar.Add(currentToken.Arguments[0] + ",");

            return regularExpressionSofar;
        }

        //private static bool IsPartOfARepeatLoop(IList<Function> tokens, int currentIndex)
        //{
        //    //If there is a "Times" token on the right (maybe with a AtMost() in between)
        //    if ((tokens.Count > (currentIndex + 1) && tokens[currentIndex + 1].Name == "Times")
        //        ||
        //        (tokens.Count > (currentIndex + 2) && tokens[currentIndex + 1].Name == "AtMost" &&
        //            tokens[currentIndex + 2].Name == "Times"))
        //        return true;
        //    return false;
        //}

        //private static void RemoveStar(IList<string> pattern)
        //{
        //    var lastSegment = pattern.Last();
        //    if (lastSegment != null && lastSegment.Contains("*"))
        //    {
        //        var indexOfStar = lastSegment.IndexOf('*');
        //        var trimmedSegment = lastSegment.Remove(indexOfStar, 1);
        //        pattern.RemoveAt(pattern.Count - 1);
        //        pattern.Add(trimmedSegment);
        //    }
        //}
    }
}
