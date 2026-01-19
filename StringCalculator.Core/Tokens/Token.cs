namespace StringCalculator.Core.Tokens;

/// <summary>
/// Abstract base class representing a token in a mathematical expression.
/// Demonstrates Abstraction and Encapsulation principles.
/// Serves as Template Method pattern - defines structure for all tokens.
/// </summary>
public abstract class Token
{
    /// <summary>
    /// Gets the string value of this token.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Initializes a new instance of the Token class.
    /// </summary>
    /// <param name="value">The string value of the token.</param>
    protected Token(string value)
    {
        Value = value ?? throw new ArgumentNullException(nameof(value));
    }

    /// <summary>
    /// Gets the type of this token.
    /// Must be overridden by derived classes (Polymorphism).
    /// </summary>
    public abstract TokenType Type { get; }

    /// <summary>
    /// Returns a string representation of this token.
    /// </summary>
    public override string ToString() => $"{Type}: {Value}";
}

/// <summary>
/// Enumeration of token types.
/// </summary>
public enum TokenType
{
    Number,
    Operator,
    Function,
    Parenthesis
}
