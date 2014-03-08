namespace SimpleExpressions.Core
{
    public class Function
    {
        public string Name { get; set; }
        public object[] Arguments { get; set; }

        public Function(string name, object[] arguments = null)
        {
            this.Name = name;
            this.Arguments = Purify(arguments);
            //this.Arguments = arguments;
        }

        private static object[] Purify(object[] arguments)
        {
            if (arguments != null)
            {
                for (var i = 0; i < arguments.Length; i++)
                {
                    if ((arguments[i] as string) != null && (arguments[i] as string).Contains("."))
                        arguments[i] = (arguments[i] as string).Replace(".", @"\.");
                }
            }
            return arguments;
        }
    }
}
