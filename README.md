### SimpleExpressions

Wouldn't it be easier if you could write stuff like `Repeat.Sequence("repeatMe").AtLeast(2).AtMost(4).Times` or `Group.Sequence("aeiou").As("vowels")` instead of those nasty Regular Expressions and let a tool generate the expressions for you?

Because having to write regexes is what makes mortals avoid using them in the first place, isn't it?

### Usage

Start with instanciating a new `SimpleExpression` object and store it as `dynamic`:

    dynamic se = new SimpleExpression();

This object is then the source of your query. Chain the query to that object as you go, be wild, go ahead! Each query must end with a `Generate()` termination statement to tell the `SimpleExpression` internal parser that the expression is over.

    SimpleExpression result = se.Letters.Generate();
      
The object returned is a `SimpleExpression` itself so you can chain up some more stuff on it.
The generated expression is available on the result object via the `Expression` property.

    string expression = result.Expression;

### The API

The various "functions" you can use are listed here below. Some are methods with parameters, others are member-calls without parameters and without parenthesis `(` and `)`.

SimpleExpressions is based on the C# 4.0 `dynamic` keyword, thus you don't have IntelliSense support. But be reassured, the number of functions you can write is quite small and the combinations are almost entirely up to you, you can chain up pretty much anything to everything. The only thing you need to care is not messing up the spelling, but the errors thrown by SimpleExpressions will help you there as well.

Head over to the Wiki for the full list of supported functions and examples.

### Requirements:

* .NET 4.0

### Installation

The project is in its early stages and only available via Github. You will ultimately be able to install it via Nuget.