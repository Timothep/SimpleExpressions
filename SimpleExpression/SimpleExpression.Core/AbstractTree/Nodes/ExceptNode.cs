using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Nodes
{
    public class ExceptNode : ValueNode
    {
        public ExceptNode(IConverter converter) : base(converter) { }

        public override string Generate()
        {
            //var valueCorrected = "";
            //foreach (char c in this.Value)
            //{
            //    if(char.IsLetter(c))
            //        valueCorrected += c.ToString(CultureInfo.InvariantCulture).ToUpper();
            //}
            return this.Value + (Value.ToUpper() != this.Value ? Value.ToUpper() : "") + this.Cardinality;
        }
    }
}