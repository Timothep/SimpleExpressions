using System;
using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters
{
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
            ranges.Add(from.ToString());

            DecomposeSteps(@from, to, ranges);

            ranges.Add((to + 1).ToString());
            //var regex = "/^(?:";
            var regex = "(";//"?:";

            for (var i = 0; i < ranges.Count - 1; i++)
            {
                string strFrom = ranges[i];
                string strTo = ((Convert.ToInt64(ranges[i + 1])) - 1).ToString();

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
                        ranges.Add(next.ToString());
                    }
                    increment /= 10;
                    higher = false;
                }
                else
                {
                    if (next % (increment * 10) == 0)
                    {
                        ranges.Add(next.ToString());
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