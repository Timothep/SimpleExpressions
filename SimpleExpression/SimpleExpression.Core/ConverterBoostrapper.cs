using System;
using System.Collections.Generic;
using System.Linq;
using SimpleExpressions.Core.Converters;
using SimpleExpressions.Core.Exceptions;
using SimpleExpressions.Core.Extensions;
 
using TinyIoC;

namespace SimpleExpressions.Core
{
    /// <summary>
    ///   Bootstrap container charged to dispatch the work to the correct converters
    /// </summary>
    public class ConverterBoostrapper
    {
        public IList<IConverter> Converters { get; set; }

        public ConverterBoostrapper()
        {
            // Lazy load all the available containers
            var container = TinyIoCContainer.Current;
            container.AutoRegister(DuplicateImplementationActions.RegisterMultiple);
            this.Converters = container.ResolveAll<IConverter>().ToList();
        }

        /// <summary>
        /// Matches the functions to their converters
        /// </summary>
        /// <param name="tokenizedChain">The SimpleExpression as a function chain</param>
        /// <returns>The SimpleExpression from its converters point of view</returns>
        public IList<IConverter> CreateConverterChain(IList<Function> tokenizedChain)
        {
            IList<IConverter> converterChain = new List<IConverter>(0);

            // Scan each of the functions of the tokenized command chain
            foreach (var function in tokenizedChain)
            {
                // Find the correct converter
                var singletonConverter = this.Converters.GetConverter(function.Name);
                IConverter converter = null;
                try
                {
                    converter = TinyIoCContainer.Current.Resolve(singletonConverter.GetType()) as IConverter;
                }
                catch (NullReferenceException)
                {
                    throw new SyntaxException(String.Format("The function '{0}' could not be resolved, please verify the spelling", function.Name));
                }

                if (converter == null)
                {
                    //If no parameters, consider it as a String and handle it as an Characters(xyz)
                    if (function.Arguments == null || function.Arguments.Length == 0)
                    {
                        converter = new Text();
                        function.Arguments = new object[] {function.Name};
                        function.Name = "Sequence";
                    }
                    else
                        throw new NullReferenceException(
                            string.Format("No matching converter for function '{0}' could be found", function.Name));
                }

                //Save each function inside its converter (1-1 relationship)
                converter.Function = function;
                converterChain.Add(converter);
            }

            return converterChain;
        }
    }
}