Wouldn't it be easier if you could write stuff like `Repeat.Sequence("repeatMe").AtLeast(2).AtMost(4).Times` or `Group.Sequence("aeiou").As("vowels")` instead of those nasty Regular Expressions and let a tool generate the expressions for you?

Because having to write regexes is what makes us avoid using them in the first place, isn't it?

=================

Start with instanciating a new `SimpleExpression` object and store it as `dynamic`:

    dynamic se = new SimpleExpression();

This object is then the source of your query. Chain the query to that object as you go, be wild, go ahead! Each query must end with a `Generate()` termination statement to tell the `SimpleExpression` internal parser that the expression is over.

    SimpleExpression result = se.Letters.Generate();
      
The object returned is a `SimpleExpression` itself so you can chain up some more stuff on it.
The generated expression is available on the result object via the `Expression` property.

    string expression = result.Expression;

### The API

The various "functions" you can use are listed here below. Some are methods with parameters, others are member-calls without parameters and without parenthesis `(` and `)`.

SimpleExpressions is based on the C# 4.0 `dynamic` keyword, thus you don't have IntelliSense support. But be reassured, the number of functions you can write is quite small and the combinations are almost entirely up to you, you can chain up pretty much anything to everything.

Here are all the functions that SimpleExpressions currently supports:
* [`Alphanumeric`, `Alphanumerics`, `Letter`, `Letters`, `Number`, `Numbers`](https://github.com/Timothep/SimpleExpressions/wiki/Base-constructs)
* [`-AndWhitespaces`](https://github.com/Timothep/SimpleExpressions/wiki/Whitespace) (likely to change)
* [`Character(char)`, `Characters(string)`](https://github.com/Timothep/SimpleExpressions/wiki/Character)
* [`Sequence(string)`](https://github.com/Timothep/SimpleExpressions/wiki/Sequence)
* [`Word(string)`](https://github.com/Timothep/SimpleExpressions/wiki/Word)
* [`Repeat`, `Exactly(int)`, `AtLeast(int)`, `AtMost(int)`, `Times`](https://github.com/Timothep/SimpleExpressions/wiki/Repetition)
* [`InRange(string)`](https://github.com/Timothep/SimpleExpressions/wiki/Range)
* [`Except(string)`](https://github.com/Timothep/SimpleExpressions/wiki/Except)
* [`Maybe(string)`](https://github.com/Timothep/SimpleExpressions/wiki/Maybe)
* [`Group`, `Together`, `As(string)`](https://github.com/Timothep/SimpleExpressions/wiki/Group)

***

Requirements:
* .NET 4.0

***

The project is in its early stages and only available via Github. You will ultimately be able to install it via Nuget.

***

### WIP, functions and ideas

* Either
* Or
* CaseInsensitive
* StartWith
* EndOfWord
* AsWord
* AsLine
* EndOfLine
* Anything
* Silent times: "Repeat.AtLeast().Times"
* Greedy

* Invert Repeat => Repeat.Blah.AtLeast(4)

### Structural checks
* Group+Together or Group+Together+As or Group+As
* AtLeast/AtMost not with Exactly