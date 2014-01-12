using System;
using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters
{
    public class InRange : BaseConverter
    {
        private readonly IList<string> functions = new List<string> {"InRange"};

        public override IList<string> Functions
        {
            get { return this.functions; }
        }

        public override IList<string> Generate(IList<Function> tokens, int currentIndex, IList<string> pattern)
        {
            var currentToken = tokens[currentIndex];

            if (currentToken.Arguments.Length != 1)
                throw new ArgumentException("Incorrect number of arguments found");

            var findLastGroupTokenIndex = FindLastGroupTokenIndex(pattern);

            //pattern.RemoveAt(findLastGroupTokenIndex);
            //pattern.Insert(findLastGroupTokenIndex, this.CreateRange(currentToken.Arguments[0].ToString()));

            return pattern;
        }

        ///// <summary>
        ///// Does not work yet, not sure what we actually want
        ///// </summary>
        ///// <param name="argument"></param>
        ///// <returns></returns>
        //private string CreateRange(string argument)
        //{
        //    var from = Convert.ToInt64(argument.Substring(0, argument.IndexOf('-')));
        //    var to = Convert.ToInt64(argument.Substring(argument.IndexOf('-') + 1));

        //    if (from < 0 || to < 0)
        //    {
        //        //throw new Exception("Negative values not supported"); 
        //        return null;
        //    }
        //    if (from > to)
        //    {
        //        //throw new Exception("Invalid range from..to, from > to"); 
        //        return null;
        //    }

        //    IList<string> ranges = new List<string>(0);
        //    ranges.Add(from.ToString());
        //    var increment = 1;
        //    var next = from;
        //    var higher = true;

        //    while (true)
        //    {
        //        next += increment;
        //        if (next + increment > to)
        //        {
        //            if (next <= to)
        //            {
        //                ranges.Add(next.ToString());
        //            }
        //            increment /= 10;
        //            higher = false;
        //        }
        //        else
        //        {
        //            if (next%(increment*10) == 0)
        //            {
        //                ranges.Add(next.ToString());
        //                increment = higher ? increment*10 : increment/10;
        //            }
        //        }

        //        if (!higher && increment < 10)
        //        {
        //            break;
        //        }
        //    }

        //    ranges.Add((to + 1).ToString());
        //    //var regex = "/^(?:";
        //    var regex = "?:";

        //    for (var i = 0; i < ranges.Count - 1; i++)
        //    {
        //        string strFrom = ranges[i];
        //        string strTo = ((Convert.ToInt64(ranges[i + 1])) - 1).ToString();

        //        for (var j = 0; j < strFrom.Length; j++)
        //        {
        //            if (strFrom[j] == strTo[j])
        //            {
        //                regex += strFrom[j];
        //            }
        //            else
        //            {
        //                regex += "[" + strFrom[j] + "-" + strTo[j] + "]";
        //            }
        //        }
        //        regex += "|";
        //    }

        //    //return regex.Substring(0, regex.Length - 1) + ")$/";
        //    return regex.Substring(0, regex.Length - 1);
        //}

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
}