using StringCalculator.Core.Interfaces;

namespace StringCalculator.Core.Tokens;

/// <summary>
/// Represents an operator token in a mathematical expression.
/// Demonstrates Inheritance, Polymorphism, and Dependency on Abstraction.
/// </summary>
public class OperatorToken : Token
{
    /// <summary>
    /// Gets the operator associated with this token.
    /// Demonstrates Dependency Inversion - depends on IOperator interface, not concrete implementation.
    /// </summary>
    public IOperator Operator { get; }

    /// <summary>
    /// Initializes a new instance of the OperatorToken class.
    /// </summary>
    /// <param name="operator">The operator.</param>
    public OperatorToken(IOperator @operator) : base(@operator.Symbol)
    {
        Operator = @operator ?? throw new ArgumentNullException(nameof(@operator));
    }

    /// <summary>
    /// Gets the type of this token (Polymorphic override).
    /// </summary>
    public override TokenType Type => TokenType.Operator;
}
