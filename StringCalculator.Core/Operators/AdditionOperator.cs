using StringCalculator.Core.Interfaces;

namespace StringCalculator.Core.Operators;

/// <summary>
/// Addition operator (+).
/// </summary>
public class AdditionOperator : IOperator
{
    public string Symbol => "+";
    public int Precedence => 1;
    public bool IsLeftAssociative => true;

    public double Execute(double left, double right) => left + right;
}
