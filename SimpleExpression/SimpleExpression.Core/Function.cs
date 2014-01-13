namespace SimpleExpressions.Core
{
    public class Function
    {
        public string Name { get; set; }
        public dynamic Arguments { get; set; }

        internal Function(string name, dynamic arguments = null)
        {
            this.Name = name;
            this.Arguments = arguments;
        }
    }
}
