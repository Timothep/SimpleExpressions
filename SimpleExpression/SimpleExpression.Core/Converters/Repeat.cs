using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters
{
    public class Repeat: BaseConverter
    {
        private readonly IList<string> functions = new List<string> { "Repeat" };
        public override IList<string> Functions
        {
            get { return this.functions; }
        }

        public override IList<string> Generate(IList<Function> tokens, int currentIndex, IList<string> pattern)
        {
            //Encapsulate the previous group with parenthesis
            var lastPatternElement = pattern[pattern.Count - 1];

            //If the last element of the pattern doesn't end with a parenthesis
            if (lastPatternElement[lastPatternElement.Length -1] != ')')
            {
                var wrappedElement = lastPatternElement.Insert(0, "(");
                wrappedElement = wrappedElement.Insert(wrappedElement.Length, ")");
                pattern.RemoveAt(pattern.Count - 1);
                pattern.Add(wrappedElement);
            }

            return pattern;
        }
    }
}
