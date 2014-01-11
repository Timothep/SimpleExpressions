using System;
using System.Collections.Generic;

namespace SimpleExpressions.Core
{
    public static class RegexBuilder
    {
        public static string Generate(IList<Function> chain)
        {
            string pattern = "";

            foreach (var function in chain)
            {
                if (function.Name == "Alphanumerics")
                    pattern += @"\w";
                else if (function.Name == "One")
                {
                    if(function.Arguments.Length != 1)
                        throw new ArgumentException("Incorrect number of arguments found");
                    
                    var arg0 = function.Arguments[0];
                    if (function.Arguments[0].ToString() == ".")
                        arg0 = @"\" + arg0;

                    pattern += arg0;
                }
                else if (function.Name == "AtLeast")
                {
                    if (function.Arguments.Length != 1)
                        throw new ArgumentException("Incorrect number of arguments found");

                    pattern += @"{" + function.Arguments[0] + ",}";
                }
                else if (function.Name == "AtMost")
                {
                    if (function.Arguments.Length != 1)
                        throw new ArgumentException("Incorrect number of arguments found");
                    if (!pattern.EndsWith(",}"))
                        throw new Exception("The AtMost function can only be called after an AtLeast function");

                    pattern = pattern.Insert(pattern.Length - 1, function.Arguments[0].ToString());
                }
            }

            return pattern;
        }
    }
}