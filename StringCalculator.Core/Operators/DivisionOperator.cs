using StringCalculator.Core.Interfaces;

namespace StringCalculator.Core.Operators;

/// <summary>
/// Division operator (/).
/// </summary>
public class DivisionOperator : IOperator
{
    public string Symbol => "/";
    public int Precedence => 2;
    public bool IsLeftAssociative => true;

    public double Execute(double left, double right)
    {
        if (right == 0)
            throw new DivideByZeroException("Cannot divide by zero");
        
        return left / right;
    }
}
