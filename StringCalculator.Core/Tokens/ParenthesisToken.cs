namespace StringCalculator.Core.Tokens;

/// <summary>
/// Represents a parenthesis token in a mathematical expression.
/// Demonstrates Inheritance and Polymorphism.
/// </summary>
public class ParenthesisToken : Token
{
    /// <summary>
    /// Gets whether this is a left parenthesis.
    /// </summary>
    public bool IsLeft { get; }

    /// <summary>
    /// Initializes a new instance of the ParenthesisToken class.
    /// </summary>
    /// <param name="value">The parenthesis character ("(" or ")").</param>
    public ParenthesisToken(string value) : base(value)
    {
        if (value != "(" && value != ")")
        {
            throw new ArgumentException($"Invalid parenthesis: {value}", nameof(value));
        }

        IsLeft = value == "(";
    }

    /// <summary>
    /// Gets the type of this token (Polymorphic override).
    /// </summary>
    public override TokenType Type => TokenType.Parenthesis;
}
