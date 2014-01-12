using System;
using System.Collections.Generic;
using SimpleExpressions.Core.Converters;
using SimpleExpressions.Core.Extensions;

namespace SimpleExpressions.Core
{
    /// <summary>
    /// Bootstrap container charged to dispatch the work to the correct converters
    /// </summary>
    public static class RegexBuilder
    {
        public static IList<string> Generate(IList<Function> chain)
        {
            IList<string> pattern = new List<string>(0);
            IList<IConverter> converters = new List<IConverter>
                {
                    new SimpleSet(),
                    new One(),
                    new AtLeast(),
                    new AtMost(),
                };

            foreach (var function in chain)
            {
                var converter = converters.GetConverters(function.Name);
                
                if (converter == null)
                    throw new NullReferenceException(string.Format("No matching converter for function '{0}' could be found", function.Name));

                pattern = converter.Generate(chain, chain.IndexOf(function), pattern);
            }

            return pattern;
        }
    }
}