using System;
using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters
{
    internal static class CharacterHelper
    {
        internal static IList<string> Generate(IList<Function> tokens, int currentIndex, IList<string> pattern)
        {
            var currentToken = tokens[currentIndex];
            
            if (currentToken.Arguments.Length != 1)
                throw new ArgumentException("Incorrect number of arguments found");

            var arg0 = currentToken.Arguments[0].ToString();
            if (arg0.Contains("."))
                arg0 = arg0.Insert(arg0.IndexOf(".", StringComparison.Ordinal), @"\");

            pattern.Add("[" + arg0 + "]");
            return pattern;
        }
    }

    public class Characters: BaseConverter
    {
        private readonly IList<string> functions = new List<string>{ "Characters" };

        public override IList<string> Functions
        {
            get { return this.functions; }
        }

        public override IList<string> Generate(IList<Function> tokens, int currentIndex, IList<string> pattern)
        {
            var currentToken = tokens[currentIndex];
            if (currentToken.Arguments.Length != 1 && currentToken.Arguments[0].ToString().Length != 1)
                throw new ArgumentException("Use the singular version 'Character' if you want to check for one character only");

            return CharacterHelper.Generate(tokens, currentIndex, pattern);
        }
    }

    public class Character : BaseConverter
    {
        private readonly IList<string> functions = new List<string> { "Character" };
        public override IList<string> Functions
        {
            get { return this.functions; }
        }

        public override IList<string> Generate(IList<Function> tokens, int currentIndex, IList<string> pattern)
        {
            return CharacterHelper.Generate(tokens, currentIndex, pattern);
        }
    }
}
