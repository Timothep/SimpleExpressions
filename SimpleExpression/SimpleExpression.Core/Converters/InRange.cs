using System;
using System.Collections.Generic;
using System.Globalization;
 

namespace SimpleExpressions.Core.Converters
{
    public class InRange : BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "InRange" };
        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }

        public override IList<string> Generate(IList<string> regularExpressionSofar)
        {
            var currentToken = this.Function;

            if (currentToken.Arguments == null)
                throw new ArgumentException("Missing argument");

            var findLastGroupTokenIndex = FindLastGroupTokenIndex(regularExpressionSofar);

            regularExpressionSofar.RemoveAt(findLastGroupTokenIndex);
            regularExpressionSofar.Insert(findLastGroupTokenIndex, RangeBuilder.CreateRange(currentToken.Arguments[0].ToString()));

            return regularExpressionSofar;
        }

        private static int FindLastGroupTokenIndex(IList<string> pattern)
        {
            var i = -1;
            for (var j = 0; j < pattern.Count; j++)
            {
                if (pattern[j].Contains("]"))
                    i = j;
            }
            return i;
        }
    }

    public static class RangeBuilder
    {
        /// <summary>
        /// Does not work yet, not sure what we actually want
        /// </summary>
        /// <param name="argument"></param>
        /// <returns></returns>
        public static string CreateRange(string argument)
        {
            var from = Convert.ToInt64(argument.Substring(0, argument.IndexOf('-')));
            var to = Convert.ToInt64(argument.Substring(argument.IndexOf('-') + 1));

            if (from < 0 || to < 0)
            {
                //throw new Exception("Negative values not supported"); 
                return null;
            }
            if (from > to)
            {
                //throw new Exception("Invalid range from..to, from > to"); 
                return null;
            }

            IList<string> ranges = new List<string>(0);
            ranges.Add(from.ToString(CultureInfo.InvariantCulture));

            DecomposeSteps(@from, to, ranges);

            ranges.Add((to + 1).ToString(CultureInfo.InvariantCulture));
            //var regex = "/^(?:";
            var regex = "(";//"?:";

            for (var i = 0; i < ranges.Count - 1; i++)
            {
                string strFrom = ranges[i];
                string strTo = ((Convert.ToInt64(ranges[i + 1])) - 1).ToString(CultureInfo.InvariantCulture);

                for (var j = 0; j < strFrom.Length; j++)
                {
                    if (strFrom[j] == strTo[j])
                    {
                        regex += strFrom[j];
                    }
                    else
                    {
                        regex += "[" + strFrom[j] + "-" + strTo[j] + "]";
                    }
                }
                regex += "|";
            }

            //return regex.Substring(0, regex.Length - 1) + ")$/";
            return regex.Substring(0, regex.Length - 1) + ")";
        }

        public static void DecomposeSteps(long from, long to, IList<string> ranges)
        {
            var increment = 1;
            var next = from;
            var higher = true;

            while (true)
            {
                next += increment;
                if (next + increment > to)
                {
                    if (next <= to)
                    {
                        ranges.Add(next.ToString(CultureInfo.InvariantCulture));
                    }
                    increment /= 10;
                    higher = false;
                }
                else
                {
                    if (next % (increment * 10) == 0)
                    {
                        ranges.Add(next.ToString(CultureInfo.InvariantCulture));
                        increment = higher ? increment * 10 : increment / 10;
                    }
                }

                if (!higher && increment < 10)
                {
                    break;
                }
            }
        }
    }
}