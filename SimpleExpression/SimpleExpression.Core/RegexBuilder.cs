using System;
using System.Collections.Generic;
using System.Linq;
using SimpleExpressions.Core.Converters;
using SimpleExpressions.Core.Extensions;
using TinyIoC;

namespace SimpleExpressions.Core
{
    /// <summary>
    ///   Bootstrap container charged to dispatch the work to the correct converters
    /// </summary>
    public static class RegexBuilder
    {
        public static IList<string> Generate(IList<Function> chain)
        {
            IList<string> pattern = new List<string>(0);

            var container = TinyIoCContainer.Current;
            container.AutoRegister(DuplicateImplementationActions.RegisterMultiple);
            var converters = container.ResolveAll<IConverter>().ToList();
            
            foreach (var function in chain)
            {
                var converter = converters.GetConverters(function.Name);

                if (converter == null)
                {
                    //If no parameters, consider it as a String and handle it as an Exactly(xyz)
                    if (function.Arguments.Length == 0)
                    {
                        converter = new Exactly();
                        function.Arguments[0] = function.Name;
                        function.Name = "Exactly";
                    }
                    else
                        throw new NullReferenceException(string.Format("No matching converter for function '{0}' could be found", function.Name));
                }

                pattern = converter.Generate(chain, chain.IndexOf(function), pattern);
            }

            return pattern;
        }
    }
}