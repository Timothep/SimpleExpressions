using System.Collections.Generic;
using System.Dynamic;
using System.Text.RegularExpressions;
using SimpleExpressions.Core.AbstractTree.Builders;

namespace SimpleExpressions.Core
{
    /// <summary>
    ///     Use this object to construct SimpleExpressions, see https://github.com/Timothep/SimpleExpressions for more details
    /// </summary>
    public class SimpleExpression : DynamicObject
    {
        private readonly ConverterBoostrapper converterBootstrapper = new ConverterBoostrapper();
        private readonly AstBuilder astBuilder = new AstBuilder();

        public SimpleExpression()
        {
            this.Initialize();
        }

        public SimpleExpression(string workObject)
        {
            this.Initialize();
            this.WorkObject = workObject;
        }

        public string WorkObject { get; set; }
        public IList<Function> SimpleExpressionChain { get; set; }
        public IList<string> RegularExpressionChain { get; set; }
        
        private Regex Regex { get; set; }
        
        public string Expression
        {
            get
            {
                return this.Generate();
            }
        }

        private void Initialize()
        {
            this.SimpleExpressionChain = new List<Function>(0);
        }

        /// <summary>
        ///     Attempts to generates the regular expression
        /// </summary>
        public string Generate()
        {
            // Find the matching converters
            var converterChain = converterBootstrapper.CreateConverterChain(this.SimpleExpressionChain);
            
            // Generate the Abstract Syntax Tree
            var astRoot = astBuilder.GenerateAst(converterChain);
            
            // Generate the regular expression
            return astRoot.Generate();
        }

        /// REGEX STUFF

        public MatchCollection Matches(string stringToValidate)
        {
            this.Regex = new Regex(this.Expression);
            return this.Regex.Matches(stringToValidate);
        }

        public bool IsMatch(string stringToValidate)
        {
            this.Regex = new Regex(this.Expression);
            return this.Regex.IsMatch(stringToValidate);
        }

        public string[] GetGroupNames()
        {
            return this.Regex != null ? this.Regex.GetGroupNames() : null;
        }
    }
}