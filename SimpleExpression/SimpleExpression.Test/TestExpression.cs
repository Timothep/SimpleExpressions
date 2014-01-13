using SimpleExpressions.Core;

namespace SimpleExpressions.Test
{
    public class MailExpression: SimpleExpression
    {
        public MailExpression()
        {
            Alphanumerics.AtLeast(1)
                .One("@")
                .Alphanumerics.AtLeast(1)
                .One(".")
                .Alphanumerics.AtLeast(2).AtMost(5)
                .Generate();
        }
    }

    public class TestExpression : SimpleExpression
    {
        public TestExpression()
        {
            //Either(Exactly("http")).Or(Exactly("ftp")).Generate();

            //Group
            //    .One("A").Or.One("X")
            //.Anonymously
            //.One("B")
            //    .Or
            //.One("Y");
        }
    }
}
