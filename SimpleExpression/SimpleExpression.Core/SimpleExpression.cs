using System.Collections.Generic;
using System.Dynamic;
using SimpleExpressions.Core.Rewriters;

namespace SimpleExpressions.Core
{
    /// <summary>
    ///     Use this object to construct SimpleExpressions, see https://github.com/Timothep/SimpleExpressions for more details
    /// </summary>
    public class SimpleExpression : DynamicObject
    {
        private readonly ConverterBoostrapper converterBootstrapper = new ConverterBoostrapper();
        private readonly ExpressionRewriter expressionRewriter = new ExpressionRewriter();
        private readonly ExpressionBuilder expressionBuilder = new ExpressionBuilder();

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

        public string Expression
        {
            get { return string.Join("", this.RegularExpressionChain); }
        }

        private void Initialize()
        {
            this.SimpleExpressionChain = new List<Function>(0);
        }

        /// <summary>
        ///     Called for a function with parameters
        /// </summary>
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            this.SimpleExpressionChain.Add(new Function(binder.Name, args));
            result = this;
            return true;
        }

        /// <summary>
        ///     Called for a parameterless function
        /// </summary>
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            this.SimpleExpressionChain.Add(new Function(binder.Name));
            result = this;
            return true;
        }

        /// <summary>
        ///     Attempts to generates the regular expression
        /// </summary>
        public SimpleExpression Generate()
        {
            // Find the matching converters
            var converterChain = converterBootstrapper.CreateConverterChain(this.SimpleExpressionChain);
            
            // Modify the SimpleExpression to be convertible
            var completedConverterChain = expressionRewriter.CompleteConverterChain(converterChain);
            
            // Generate the regular expression
            this.RegularExpressionChain = expressionBuilder.GenerateRegularExpression(completedConverterChain);

            return this;
        }
    }
}