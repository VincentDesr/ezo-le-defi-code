using StringCalculator.Core.Tokens;

namespace StringCalculator.Core.Interfaces;

/// <summary>
/// Defines the contract for parsing tokenized expressions.
/// Responsible for converting infix notation to postfix notation (Shunting Yard Algorithm).
/// </summary>
public interface IExpressionParser
{
    /// <summary>
    /// Parses a list of tokens from infix notation to postfix notation.
    /// </summary>
    /// <param name="tokens">The tokens in infix notation.</param>
    /// <returns>The tokens in postfix notation.</returns>
    IEnumerable<Token> Parse(IEnumerable<Token> tokens);
}
