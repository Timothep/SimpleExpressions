namespace SimpleExpressions.Core.AbstractTree
{
    public class Cardinality
    {
        public Cardinality(CardinalityEnum card = CardinalityEnum.ExactlyOne)
        {
            switch (card)
            {
                case CardinalityEnum.ZeroOrMore:
                    this.Min = 0;
                    this.Max = int.MaxValue;
                    break;
                case CardinalityEnum.ZeroToOne:
                    this.Min = 0;
                    this.Max = 1;
                    break;
                case CardinalityEnum.ExactlyOne:
                    this.Min = 1;
                    this.Max = 1;
                    break;
                case CardinalityEnum.OneOrMore:
                    this.Min = 1;
                    this.Max = int.MaxValue;
                    break;
            }
        }

        public int Min { get; set; }
        public int Max { get; set; }
    }

    public enum CardinalityEnum
    {
        ZeroOrMore = 0,
        ZeroToOne,
        ExactlyOne,
        OneOrMore,
    }
}