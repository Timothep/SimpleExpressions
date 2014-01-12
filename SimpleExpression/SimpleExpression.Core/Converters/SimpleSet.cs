using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters
{
    internal class SimpleSet: IConverter
    {
        private readonly IList<string> functions = new List<string> { "Alphanumeric", "Alphanumerics", "Letter", "Letters", "Number", "Numbers" };

        public bool CanParse(string token)
        {
            return this.functions.Contains(token);
        }

        public IList<string> Generate(IList<Function> tokens, Function currentToken, IList<string> pattern)
        {
            switch (currentToken.Name)
            {
                case "Alphanumeric":
                    pattern.Add(@"\w");
                    break;
                case "Alphanumerics":
                    pattern.Add(@"\w*");
                    break;
                case "Letter":
                    pattern.Add(@"[a-zA-Z]");
                    break;
                case "Letters":
                    pattern.Add(@"[a-zA-Z]*");
                    break;
                case "Number":
                    pattern.Add(@"[0-9]");
                    break;
                case "Numbers":
                    pattern.Add(@"[0-9]*");
                    break;
            }

            return pattern;
        }
    }
}
