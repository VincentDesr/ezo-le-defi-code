using StringCalculator.Core.Interfaces;

namespace StringCalculator.Core.Operators;

/// <summary>
/// Multiplication operator (*).
/// </summary>
public class MultiplicationOperator : IOperator
{
    public string Symbol => "*";
    public int Precedence => 2;
    public bool IsLeftAssociative => true;

    public double Execute(double left, double right) => left * right;
}
