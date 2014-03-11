using System;

namespace SimpleExpressions.Core.AbstractTree.DomainObjects
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
            if (this.Min == null && this.Max == null)
                return string.Empty;

            //Star => {0,infinite}
            if (this.Min == 0 && this.Max == null)
                return "*";

            //Plus => {1,infinite}
            if (this.Min == 1 && this.Max == null)
                return "+";

            //If only a min Bound was given
            if (this.Min != null && this.Max == null)
                return "{" + this.Min + ",}";

            if (this.Min != null && this.Max != null)
            {
                // Case of exactly
                if (this.Min == this.Max)
                    return "{" + this.Min + "}";

                // If both were entered
                return "{" + this.Min + "," + this.Max + "}";
            }

            // AtMost only
            if (Min == null && Max != null)
                return "{0," + this.Max + "}";

            throw new NotImplementedException(string.Format("Not implemented cardinality case. Min={0}, Max={1}", Min, Max));
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