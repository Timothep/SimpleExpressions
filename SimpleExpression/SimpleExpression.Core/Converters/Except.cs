using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleExpressions.Core.Converters
{
    //Cases:
    //Except("a") <- [^a]
    //ExceptRange("a-d") <- [^blah]
    //ExceptLetters("blah") <- except all those letters [^blah]
    

    public class Except : BaseConverter
    {
        private readonly IList<string> functions = new List<string> { "Except" };
        public override IList<string> Functions
        {
            get { return this.functions; }
        }

        public override IList<string> Generate(IList<Function> tokens, int currentIndex, IList<string> pattern)
        {
            var currentToken = tokens[currentIndex];
            var lastPatternToken = pattern.Last();
            pattern.Remove(lastPatternToken);

            var offset = 1;
            if (lastPatternToken.EndsWith("*"))
                offset = 2;

            pattern.Add(lastPatternToken.Insert(lastPatternToken.Length - offset, "-[" + currentToken.Arguments[0] + "]"));
            return pattern;
        }
    }

    /// <summary>
    /// ExceptWord("blah") -> ^(.(?!blah))*$
    /// </summary>
    public class ExceptWord : BaseConverter
    {
        private readonly IList<string> functions = new List<string> { "ExceptWord" };
        public override IList<string> Functions
        {
            get { return this.functions; }
        }

        public override IList<string> Generate(IList<Function> tokens, int currentIndex, IList<string> pattern)
        {
            var currentToken = tokens[currentIndex];
            var lastPatternToken = pattern.Last();
            pattern.Remove(lastPatternToken);
            pattern.Add(lastPatternToken.Insert(lastPatternToken.Length - 1, "[^" + currentToken.Arguments[0] + "]"));
            return pattern;
        }
    }
}
