using System.Collections.Generic;
using System.Dynamic;

namespace SimpleExpressions.Core
{
    /// <summary>
    ///     Use this object to construct SimpleExpressions, see https://github.com/Timothep/SimpleExpressions for more details
    /// </summary>
    public class SimpleExpression : DynamicObject
    {
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
        public IList<Function> TokenizedSimpleExpression { get; set; }
        public IList<string> TokenizedRegularExpression { get; set; }

        public string RegularExpressionPattern
        {
            get { return string.Join("", this.TokenizedRegularExpression); }
        }

        private void Initialize()
        {
            this.TokenizedSimpleExpression = new List<Function>(0);
        }

        /// <summary>
        ///     Called for a function with parameters
        /// </summary>
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            this.TokenizedSimpleExpression.Add(new Function(binder.Name, args));
            result = this;
            return true;
        }

        /// <summary>
        ///     Called for a parameterless function
        /// </summary>
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            this.TokenizedSimpleExpression.Add(new Function(binder.Name));
            result = this;
            return true;
        }

        /// <summary>
        ///     Attempts to generates the regular expression
        /// </summary>
        public SimpleExpression Generate()
        {
            this.TokenizedRegularExpression = RegexBuilder.Generate(this.TokenizedSimpleExpression);
            return this;
        }
    }
}