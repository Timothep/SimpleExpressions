namespace SimpleExpressions.Core
{
    public class Function
    {
        public string Name { get; set; }
        public object[] Arguments { get; set; }

        internal Function(string name, object[] arguments = null)
        {
            this.Name = name;
            this.Arguments = arguments;
        }
    }
}
