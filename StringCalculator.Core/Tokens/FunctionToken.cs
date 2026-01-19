using StringCalculator.Core.Interfaces;

namespace StringCalculator.Core.Tokens;

/// <summary>
/// Represents a function token in a mathematical expression.
/// Demonstrates Inheritance, Polymorphism, and Dependency on Abstraction.
/// </summary>
public class FunctionToken : Token
{
    /// <summary>
    /// Gets the function associated with this token.
    /// Demonstrates Dependency Inversion - depends on IFunction interface, not concrete implementation.
    /// </summary>
    public IFunction Function { get; }

    /// <summary>
    /// Initializes a new instance of the FunctionToken class.
    /// </summary>
    /// <param name="function">The function.</param>
    public FunctionToken(IFunction function) : base(function.Name)
    {
        Function = function ?? throw new ArgumentNullException(nameof(function));
    }

    /// <summary>
    /// Gets the type of this token (Polymorphic override).
    /// </summary>
    public override TokenType Type => TokenType.Function;
}
