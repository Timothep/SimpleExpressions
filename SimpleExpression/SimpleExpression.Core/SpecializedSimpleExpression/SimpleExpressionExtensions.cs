namespace SimpleExpressions.Core.SpecializedSimpleExpression
{
    public static class SimpleExpressionExtensions
    {
        /// <summary>
        /// Matches a single letter in lower-case, between a and z, with a default cardinality of min 1 & max 1
        /// </summary>
        public static SimpleExpression Letter(this SimpleExpression se)
        {
            se.SimpleExpressionChain.Add(new Function("Letter"));
            return se;
        }

        /// <summary>
        /// Matches a single number, between 0 and 9, with a default cardinality of min 1 & max 1
        /// </summary>
        public static SimpleExpression Number(this SimpleExpression se)
        {
            se.SimpleExpressionChain.Add(new Function("Number"));
            return se;
        }

        /// <summary>
        /// Matches a single letter in lower-case between a and z, or a single number between 0 and 9, with a default cardinality of min 1 & max 1
        /// </summary>
        public static SimpleExpression Alphanumeric(this SimpleExpression se)
        {
            se.SimpleExpressionChain.Add(new Function("Alphanumeric"));
            return se;
        }

        /// <summary>
        /// Matches the argument.
        /// </summary>
        /// <param name="argument">A string to match</param>
        public static SimpleExpression Text(this SimpleExpression se, string argument)
        {
            se.SimpleExpressionChain.Add(new Function("Text", new object[] { argument }));
            return se;
        }

        /// <summary>
        /// Matches the argument.
        /// </summary>
        /// <param name="argument">A character to match</param>
        public static SimpleExpression One(this SimpleExpression se, char argument)
        {
            se.SimpleExpressionChain.Add(new Function("One", new object[] { argument }));
            return se;
        }

        /// <summary>
        /// Matches one of the subparts of the argument. The argument format must be "arg1|arg2|arg3". ex: "http|ftp".
        /// </summary>
        /// <param name="argument">A pipe-separated string of elements to match</param>
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

        public static OrSimpleExpression Either(this SimpleExpression se, SimpleExpression argument)
        {
            var ose = new OrSimpleExpression { SimpleExpressionChain = se.SimpleExpressionChain };
            ose.SimpleExpressionChain.Add(new Function("Either", new object[] { argument }));
            return ose;
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
