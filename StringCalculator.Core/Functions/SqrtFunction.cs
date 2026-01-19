using StringCalculator.Core.Interfaces;

namespace StringCalculator.Core.Functions;

/// <summary>
/// Square root function.
/// </summary>
public class SqrtFunction : IFunction
{
    public string Name => "sqrt";
    public int ArgumentCount => 1;

    public double Execute(params double[] arguments)
    {
        if (arguments.Length != ArgumentCount)
            throw new ArgumentException($"sqrt expects {ArgumentCount} argument, got {arguments.Length}");

        if (arguments[0] < 0)
            throw new ArgumentException("Cannot take square root of negative number");

        return Math.Sqrt(arguments[0]);
    }
}
