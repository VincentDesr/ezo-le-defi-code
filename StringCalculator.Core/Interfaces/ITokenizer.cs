using StringCalculator.Core.Tokens;

namespace StringCalculator.Core.Interfaces;

/// <summary>
/// Defines the contract for tokenizing mathematical expressions.
/// Responsible for breaking down input strings into tokens.
/// </summary>
public interface ITokenizer
{
    /// <summary>
    /// Tokenizes the given mathematical expression into a list of tokens.
    /// </summary>
    /// <param name="expression">The expression to tokenize.</param>
    /// <returns>A list of tokens representing the expression.</returns>
    IEnumerable<Token> Tokenize(string expression);
}
