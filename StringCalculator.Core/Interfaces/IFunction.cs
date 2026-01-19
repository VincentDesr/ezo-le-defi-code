namespace StringCalculator.Core.Interfaces;

/// <summary>
/// Defines the contract for mathematical functions.
/// Implements Strategy Pattern - each function is a different strategy for executing operations.
/// </summary>
public interface IFunction
{
    /// <summary>
    /// Gets the name of this function (e.g., "sqrt", "abs").
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Gets the number of arguments this function accepts.
    /// </summary>
    int ArgumentCount { get; }

    /// <summary>
    /// Executes the function with the given arguments.
    /// </summary>
    /// <param name="arguments">The function arguments.</param>
    /// <returns>The result of the function.</returns>
    double Execute(params double[] arguments);
}
