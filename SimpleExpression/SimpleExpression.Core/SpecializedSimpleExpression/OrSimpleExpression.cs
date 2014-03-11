namespace SimpleExpressions.Core.SpecializedSimpleExpression
{
    public class OrSimpleExpression: AbstractSimpleExpression
    {
        public SimpleExpression Or(SimpleExpression argument)
        {
            var se = new SimpleExpression
                {
                    SimpleExpressionChain = this.SimpleExpressionChain,
                };

            se.SimpleExpressionChain.Add(new Function("Or", new object[] { argument }));
            return se;
        }
    }
}
