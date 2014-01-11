using System.Collections.Generic;
using System.Dynamic;

namespace SimpleExpressions.Core
{
    public class SimpleExpression: DynamicObject
    {
        public string WorkObject { get; set; }
        public IList<Function> Chain { get; set; }
        public string Pattern { get; set; }

        public SimpleExpression(string workObject)
        {
            this.WorkObject = workObject;
            this.Chain = new List<Function>(0);
        }

        /// <summary>
        /// Called for a function with parameters
        /// </summary>
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            this.Chain.Add(new Function(binder.Name, args));
            result = this;
            return true;
        }

        /// <summary>
        /// Called for a parameterless function
        /// </summary>
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            this.Chain.Add(new Function(binder.Name));
            result = this;
            return true;
        }

        public override bool TryInvoke(InvokeBinder binder, object[] args, out object result)
        {
            return base.TryInvoke(binder, args, out result);
        }

        public void Generate()
        {
            this.Pattern = RegexBuilder.Generate(this.Chain);
        }
    }
}
