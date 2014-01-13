using System.Collections.Generic;

namespace SimpleExpressions.Core
{
    /// <summary>
    ///     Use this object to construct SimpleExpressions, see https://github.com/Timothep/SimpleExpressions for more details
    /// </summary>
    public class SimpleExpression
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

        private string WorkObject { get; set; }
        private IList<Function> TokenizedSimpleExpression { get; set; }
        private IList<string> TokenizedRegularExpression { get; set; }

        /// <summary>
        ///     Contains the generated regular expression
        /// </summary>
        public string Expression
        {
            get { return this.TokenizedRegularExpression != null ?
                string.Join("", this.TokenizedRegularExpression) 
                : null; }
        }

        //##############

        private void Initialize()
        {
            this.TokenizedSimpleExpression = new List<Function>(0);
        }

        ///// <summary>
        /////     Called for a function with parameters
        ///// </summary>
        //public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        //{
        //    this.TokenizedSimpleExpression.Add(new Function(binder.Name, args));
        //    result = this;
        //    return true;
        //}

        ///// <summary>
        /////     Called for a parameterless function
        ///// </summary>
        //public override bool TryGetMember(GetMemberBinder binder, out object result)
        //{
        //    this.TokenizedSimpleExpression.Add(new Function(binder.Name));
        //    result = this;
        //    return true;
        //}

        /// <summary>
        ///     Attempts to generates the regular expression
        /// </summary>
        public SimpleExpression Generate()
        {
            this.TokenizedRegularExpression = RegexBuilder.Generate(this.TokenizedSimpleExpression);
            return this;
        }

        //Helpers

        private SimpleExpression Property(string token)
        {
            this.TokenizedSimpleExpression.Add(new Function(token));
            return this;
        }

        private SimpleExpression Method(string token, dynamic args)
        {
            this.TokenizedSimpleExpression.Add(new Function(token, args));
            return this;
        }

        //Properties

        public SimpleExpression Alphanumerics
        {
            get { return this.Property("Alphanumerics"); }
        }

        public SimpleExpression Alphanumeric
        {
            get { return this.Property("Alphanumeric"); }
        }

        public SimpleExpression Numbers
        {
            get { return this.Property("Numbers"); }
        }

        public SimpleExpression Number
        {
            get { return this.Property("Number"); }
        }

        public SimpleExpression Letters
        {
            get { return this.Property("Letters"); }
        }

        public SimpleExpression Letter
        {
            get { return this.Property("Letter"); }
        }

        //Methods

        public SimpleExpression AtLeast(dynamic min)
        {
            return this.Method("AtLeast", min);
        }

        public SimpleExpression AtMost(dynamic max)
        {
            return this.Method("AtMost", max);
        }

        public SimpleExpression One(dynamic element)
        {
            return this.Method("One", element);
        }

        public SimpleExpression Or(dynamic arg)
        {
            return this.Method("Or", arg);
        }

        public SimpleExpression Exactly(dynamic args)
        {
            return this.Method("Exactly", args);
        }

        public SimpleExpression Except(dynamic args)
        {
            return this.Method("Except", args);
        }

    }
}