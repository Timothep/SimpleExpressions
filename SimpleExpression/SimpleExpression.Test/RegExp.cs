using SimpleExpressions.Core;

namespace SimpleExpressions.Test
{
    public class RegExp:SimpleExpression
    {
        public string RegExp()
        {
            Group(Exactly("aaa").Exactly("aaa"))
                .Or
                    .Group(Exactly("xxx").Exactly("xxx"))
                    .As("Identifier")
                .Or
                    .Group(Exactly("Alpha").Exactly("Beta"))
                    .Generate();

            return this.Expression;
        }
    }
}
