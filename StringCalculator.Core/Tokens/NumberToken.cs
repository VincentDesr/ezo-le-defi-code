namespace StringCalculator.Core.Tokens;

/// <summary>
/// Represents a numeric token in a mathematical expression.
/// Demonstrates Inheritance and Polymorphism.
/// </summary>
public class NumberToken : Token
{
    /// <summary>
    /// Gets the numeric value of this token.
    /// Demonstrates Encapsulation - private setter, public getter.
    /// </summary>
    public double NumericValue { get; }

    /// <summary>
    /// Initializes a new instance of the NumberToken class.
    /// </summary>
    /// <param name="value">The string representation of the number.</param>
    public NumberToken(string value) : base(value)
    {
        if (!double.TryParse(value, out double numericValue))
        {
            throw new ArgumentException($"Invalid number format: {value}", nameof(value));
        }

        NumericValue = numericValue;
    }

    /// <summary>
    /// Gets the type of this token (Polymorphic override).
    /// </summary>
    public override TokenType Type => TokenType.Number;
}
