using StringCalculator.Core.Interfaces;

namespace StringCalculator.Core.Operators;

/// <summary>
/// Subtraction operator (-).
/// </summary>
public class SubtractionOperator : IOperator
{
    public string Symbol => "-";
    public int Precedence => 1;
    public bool IsLeftAssociative => true;

    public double Execute(double left, double right) => left - right;
}
