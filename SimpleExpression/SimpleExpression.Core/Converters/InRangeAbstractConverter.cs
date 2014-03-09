using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters
{
    public abstract class InRangeAbstractConverter : BaseConverter
    {
        protected IList<string> supportedFunctionNames { get; set; }
        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }
    }
}