using System.Collections.Generic;
using System.Linq;
using SimpleExpressions.Core.Parser;

namespace SimpleExpressions.Core.Converters
{
    public class SimpleSet: IConverter
    {
        private const string AndWhitespaces = "AndWhitespaces";
        private readonly IList<string> functions = new List<string> { "Alphanumeric", "Alphanumerics", "Letter", "Letters", "Number", "Numbers" };

        internal NodeType Type = NodeType.SimpleNode;
        public NodeType NodeType { get { return Type; } }

        public bool CanParse(string token)
        {
            return this.functions.Any(token.Contains);
        }

        private string FormatPattern(bool lower, bool upper, bool number, bool white, bool multiple)
        {
            const string lowerCaseRange = "a-z";
            const string upperCaseRange = "A-Z";
            const string numberRange = "0-9";
            const string whitespaces = @"\s";
            const string multiplicity = "*";

            return string.Format(@"[{0}{1}{2}{3}]{4}",
                lower ? lowerCaseRange : "", 
                upper ? upperCaseRange : "", 
                number ? numberRange : "", 
                white ? whitespaces : "",
                multiple ? multiplicity : "");
        }

        public IList<string> Generate(IList<Function> tokens, int currentIndex, IList<string> pattern)
        {
            var formattedPattern = "";

            const bool lower = true;
            const bool upper = true;
            const bool number =true;
            const bool white = true;
            const bool multiple = true;

            var name = tokens[currentIndex].Name;
            if (name == "Alphanumerics")
                formattedPattern = FormatPattern(lower, upper, number, !white, multiple);
            else if(name.StartsWith("Alphanumerics") && name.EndsWith(AndWhitespaces))
                formattedPattern = FormatPattern(lower, upper, number, white, multiple);
            if (name == "Alphanumeric")
                formattedPattern = FormatPattern(lower, upper, number, !white, !multiple);
            else if(name.StartsWith("Alphanumeric") && name.EndsWith(AndWhitespaces))
                formattedPattern = FormatPattern(lower, upper, number, white, !multiple);

            if (name == "Letters")
                formattedPattern = FormatPattern(lower, upper, !number, !white, multiple);
            else if (name.StartsWith("Letters") && name.EndsWith(AndWhitespaces))
                formattedPattern = FormatPattern(lower, upper, !number, white, multiple); 
            else if (name == "Letter")
                formattedPattern = FormatPattern(lower, upper, !number, !white, !multiple);
            else if (name.StartsWith("Letter") && name.EndsWith(AndWhitespaces))
                formattedPattern = FormatPattern(lower, upper, !number, white, !multiple);

            if (name == "Numbers")
                formattedPattern = FormatPattern(!lower, !upper, number, !white, multiple);
            else if (name.StartsWith("Numbers") && name.EndsWith(AndWhitespaces))
                formattedPattern = FormatPattern(!lower, !upper, number, white, multiple);
            else if (name == "Number")
                formattedPattern = FormatPattern(!lower, !upper, number, !white, !multiple);
            else if (name.StartsWith("Number") && name.EndsWith(AndWhitespaces))
                formattedPattern = FormatPattern(!lower, !upper, number, white, !multiple);

            pattern.Add(formattedPattern);
            return pattern;
        }
    }
}
