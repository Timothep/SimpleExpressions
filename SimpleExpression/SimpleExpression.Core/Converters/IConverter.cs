namespace SimpleExpressions.Core.Converters
{
    public interface IConverter
    {
        bool CanParse(string functionName);
        Function Function { get; set; }
    }
}