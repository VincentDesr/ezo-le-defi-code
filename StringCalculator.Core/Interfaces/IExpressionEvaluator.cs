using StringCalculator.Core.Tokens;

namespace StringCalculator.Core.Interfaces;

/// <summary>
/// Defines the contract for evaluating expressions.
/// Responsible for calculating the result from postfix notation tokens.
/// </summary>
public interface IExpressionEvaluator
{
    /// <summary>
    /// Evaluates a list of tokens in postfix notation.
    /// </summary>
    /// <param name="tokens">The tokens in postfix notation.</param>
    /// <returns>The result of the evaluation.</returns>
    double Evaluate(IEnumerable<Token> tokens);
}
