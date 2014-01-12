using System;
using System.Collections.Generic;
using System.Dynamic;

namespace SimpleExpressions.Core
{
    public class SimpleExpression : DynamicObject
    {
        public SimpleExpression()
        {
            Initialize();
        }

        public SimpleExpression(string workObject)
        {
            Initialize();
            this.WorkObject = workObject;
        }

        private void Initialize()
        {
            this.Chain = new List<Function>(0);
        }

        public string WorkObject { get; set; }
        public IList<Function> Chain { get; set; }
        public IList<string> TokenizedPattern { get; set; }

        public string Pattern
        {
            get { return string.Join("", this.TokenizedPattern ); }
        }

        /// <summary>
        ///     Called for a function with parameters
        /// </summary>
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            this.Chain.Add(new Function(binder.Name, args));
            result = this;
            return true;
        }

        /// <summary>
        ///     Called for a parameterless function
        /// </summary>
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            this.Chain.Add(new Function(binder.Name));
            result = this;
            return true;
        }

        public SimpleExpression Generate()
        {
            this.TokenizedPattern = RegexBuilder.Generate(this.Chain);
            return this;
        }
    }
}