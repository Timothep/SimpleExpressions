namespace SimpleExpressions.Core
{
    public static class SimpleExpressionExtensions
    {
        public static SimpleExpression Letters(this SimpleExpression se)
        {
            se.SimpleExpressionChain.Add(new Function("Letters"));
            return se;
        }

        public static SimpleExpression Numbers(this SimpleExpression se)
        {
            se.SimpleExpressionChain.Add(new Function("Numbers"));
            return se;
        }

        public static SimpleExpression Alphanumerics(this SimpleExpression se)
        {
            se.SimpleExpressionChain.Add(new Function("Alphanumerics"));
            return se;
        }

        public static SimpleExpression Text(this SimpleExpression se, string argument)
        {
            se.SimpleExpressionChain.Add(new Function("Text", new object[] { argument }));
            return se;
        }

        public static SimpleExpression One(this SimpleExpression se, string argument)
        {
            se.SimpleExpressionChain.Add(new Function("One", new object[] { argument }));
            return se;
        }

        public static SimpleExpression OneOf(this SimpleExpression se, string argument)
        {
            se.SimpleExpressionChain.Add(new Function("OneOf", new object[] { argument }));
            return se;
        }

        public static SimpleExpression Maybe(this SimpleExpression se, string argument)
        {
            se.SimpleExpressionChain.Add(new Function("Maybe", new object[] { argument }));
            return se;
        }

        public static SimpleExpression And(this SimpleExpression se, string argument)
        {
            se.SimpleExpressionChain.Add(new Function("And", new object[] { argument }));
            return se;
        }

        public static SimpleExpression Except(this SimpleExpression se, string argument)
        {
            se.SimpleExpressionChain.Add(new Function("Except", new object[] { argument }));
            return se;
        }

        public static SimpleExpression EitherOf(this SimpleExpression se, string argument)
        {
            se.SimpleExpressionChain.Add(new Function("EitherOf", new object[] { argument }));
            return se;
        }

        public static SimpleExpression As(this SimpleExpression se, string argument)
        {
            se.SimpleExpressionChain.Add(new Function("As", new object[] { argument }));
            return se;
        }

        public static SimpleExpression AtLeast(this SimpleExpression se, int argument)
        {
            se.SimpleExpressionChain.Add(new Function("AtLeast", new object[] { argument }));
            return se;
        }

        public static SimpleExpression AtMost(this SimpleExpression se, int argument)
        {
            se.SimpleExpressionChain.Add(new Function("AtMost", new object[] { argument }));
            return se;
        }

        public static SimpleExpression Exactly(this SimpleExpression se, int argument)
        {
            se.SimpleExpressionChain.Add(new Function("Exactly", new object[] { argument }));
            return se;
        }

        /* RANGE */

        public static SimpleExpression NumberInRange(this SimpleExpression se, string argument)
        {
            se.SimpleExpressionChain.Add(new Function("NumberInRange", new object[] { argument }));
            return se;
        }

        public static SimpleExpression LetterInRange(this SimpleExpression se, string argument)
        {
            se.SimpleExpressionChain.Add(new Function("LetterInRange", new object[] { argument }));
            return se;
        }

        /* DUMB FUNCTIONS */

        public static SimpleExpression Together(this SimpleExpression se)
        {
            se.SimpleExpressionChain.Add(new Function("AtMost"));
            return se;
        }

        public static SimpleExpression Then(this SimpleExpression se)
        {
            se.SimpleExpressionChain.Add(new Function("Exactly"));
            return se;
        }

        /* COMPLEX FUNCTIONS */

        public static SimpleExpression Either(this SimpleExpression se, SimpleExpression argument)
        {
            se.SimpleExpressionChain.Add(new Function("Either", new object[] { argument }));
            return se;
        }

        public static SimpleExpression Or(this SimpleExpression se, SimpleExpression argument)
        {
            se.SimpleExpressionChain.Add(new Function("Or", new object[] { argument }));
            return se;
        }

        public static SimpleExpression Group(this SimpleExpression se, SimpleExpression argument)
        {
            se.SimpleExpressionChain.Add(new Function("Group", new object[] { argument }));
            return se;
        }

        public static SimpleExpression SubExpression(this SimpleExpression se, SimpleExpression argument)
        {
            se.SimpleExpressionChain.Add(new Function("SubExpression", new object[] { argument }));
            return se;
        }
    }
}
