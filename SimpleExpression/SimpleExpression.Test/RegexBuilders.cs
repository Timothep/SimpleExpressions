using SimpleExpressions.Core;

namespace SimpleExpressions.Test
{
    public class MailExpression: SimpleExpression
    {
        public MailExpression()
        {
            //Alphanumerics.AtLeast(1)
            //    .One("@")
            //    .Alphanumerics.AtLeast(1)
            //    .One(".")
            //    .Alphanumerics.AtLeast(2).AtMost(5)
            //    .Generate();
        }
    }
}
