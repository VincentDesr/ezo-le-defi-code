using StringCalculator.Core.Interfaces;

namespace StringCalculator.Core.Operators;

/// <summary>
/// Exponentiation operator (^).
/// </summary>
public class ExponentiationOperator : IOperator
{
    public string Symbol => "^";
    public int Precedence => 3;
    public bool IsLeftAssociative => false; // Right-associative: 2^3^2 = 2^(3^2) = 512

    public double Execute(double left, double right) => Math.Pow(left, right);
}
