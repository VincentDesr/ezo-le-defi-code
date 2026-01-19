namespace StringCalculator.Core.Interfaces;

/// <summary>
/// Defines the contract for mathematical operators.
/// Implements Strategy Pattern - each operator is a different strategy for executing operations.
/// </summary>
public interface IOperator
{
    /// <summary>
    /// Gets the symbol representing this operator (e.g., "+", "-", "*").
    /// </summary>
    string Symbol { get; }

    /// <summary>
    /// Gets the precedence level of this operator.
    /// Higher values indicate higher precedence (e.g., * has higher precedence than +).
    /// </summary>
    int Precedence { get; }

    /// <summary>
    /// Gets whether this operator is left-associative.
    /// </summary>
    bool IsLeftAssociative { get; }

    /// <summary>
    /// Executes the operation on the given operands.
    /// </summary>
    /// <param name="left">The left operand.</param>
    /// <param name="right">The right operand.</param>
    /// <returns>The result of the operation.</returns>
    double Execute(double left, double right);
}
