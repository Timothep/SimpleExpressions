using System;

namespace SimpleExpressions.Core.AbstractTree
{
    public class Cardinality
    {
        public Cardinality(CardinalityEnum card = CardinalityEnum.Undefined)
        {
            switch (card)
            {
                case CardinalityEnum.Undefined:
                    this.Min = null;
                    this.Max = null;
                    break;
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

        public override string ToString()
        {
            //If no cardinality was given... ever
            if (Min == null && Max == null)
                return "";

            //If only a min Bound was given
            if (Min != null && Max == null)
                return "{" + Min + ",}";

            if (this.Min != null && this.Max != null)
            {
                // Case of exactly
                if (this.Min == this.Max)
                    return "{" + this.Min + "}";

                // If both were entered
                return "{" + Min + "," + Max + "}";
            }

            //if (Min == null && Max != null)
            throw new ArgumentException("AtMost alone is not supported");
        }

        public int? Min { get; set; }
        public int? Max { get; set; }
    }

    public enum CardinalityEnum
    {
        Undefined = 0,
        ZeroOrMore,
        ZeroToOne,
        ExactlyOne,
        OneOrMore,
    }
}