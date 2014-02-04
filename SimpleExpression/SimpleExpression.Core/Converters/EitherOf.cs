using System.Collections.Generic;
 

namespace SimpleExpressions.Core.Converters
{
    public class EitherOf : BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "EitherOf" };
        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }

        public override IList<string> Generate(IList<string> regularExpressionSofar)
        {
            var arg = this.Function.Arguments[0].ToString();

            if(!arg.Contains("|"))
                regularExpressionSofar.Add("[" + arg + "]");
            else
                regularExpressionSofar.Add(arg);

            return regularExpressionSofar;
        }
    }
}
