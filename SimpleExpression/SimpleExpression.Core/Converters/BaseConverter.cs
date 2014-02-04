using System.Collections.Generic;
 

namespace SimpleExpressions.Core.Converters
{
    public abstract class BaseConverter: IConverter
    {
        /// <summary>
        /// The functions the converter can support
        /// </summary>
        public abstract IList<string> SupportedFunctionNames { get; }

        /// <summary>
        /// The function the converter will handle
        /// </summary>
        public Function Function { get; set; }

        /// <summary>
        /// Generates the part of the regex it can handle inside the global chain
        /// </summary>
        /// <param name="regularExpressionSofar">The regular expression being built</param>
        public abstract IList<string> Generate(IList<string> regularExpressionSofar);

        /// <summary>
        /// Used to know if this converter can parse the given function
        /// </summary>
        /// <param name="functionName">The name of the function to be converted</param>
        public bool CanParse(string functionName)
        {
            return this.SupportedFunctionNames.Contains(functionName);
        }
    }
}
