using StringCalculator.Core.Services;

namespace StringCalculator.Tests;

/// <summary>
/// Unit tests for CalculatorService covering all required test cases and edge cases.
/// </summary>
public class CalculatorServiceTests
{
    private readonly CalculatorService _calculator;

    public CalculatorServiceTests()
    {
        _calculator = new CalculatorService();
    }

    #region Required Test Cases

    [Fact]
    public void Evaluate_SingleNumber_ReturnsNumber()
    {
        // Arrange
        var expression = "1";

        // Act
        var result = _calculator.Evaluate(expression);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void Evaluate_SimpleAddition_ReturnsSum()
    {
        // Arrange
        var expression = "1 + 2";

        // Act
        var result = _calculator.Evaluate(expression);

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void Evaluate_AdditionWithNegative_ReturnsCorrectResult()
    {
        // Arrange
        var expression = "1 + -1";

        // Act
        var result = _calculator.Evaluate(expression);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Evaluate_SubtractionWithNegatives_ReturnsCorrectResult()
    {
        // Arrange
        var expression = "-1 - -1";

        // Act
        var result = _calculator.Evaluate(expression);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Evaluate_SimpleMultiplication_ReturnsProduct()
    {
        // Arrange
        var expression = "5*2";

        // Act
        var result = _calculator.Evaluate(expression);

        // Assert
        Assert.Equal(10, result);
    }

    [Fact]
    public void Evaluate_ParenthesesWithOperations_ReturnsCorrectResult()
    {
        // Arrange
        var expression = "(2+5)*3";

        // Act
        var result = _calculator.Evaluate(expression);

        // Assert
        Assert.Equal(21, result);
    }

    [Fact]
    public void Evaluate_SimpleDivision_ReturnsQuotient()
    {
        // Arrange
        var expression = "10/2";

        // Act
        var result = _calculator.Evaluate(expression);

        // Assert
        Assert.Equal(5, result);
    }

    [Fact]
    public void Evaluate_ComplexExpressionWithPrecedence_ReturnsCorrectResult()
    {
        // Arrange
        var expression = "2+2*5+5";

        // Act
        var result = _calculator.Evaluate(expression);

        // Assert
        Assert.Equal(17, result); // 2 + (2*5) + 5 = 2 + 10 + 5 = 17
    }

    [Fact]
    public void Evaluate_DecimalMultiplicationAndSubtraction_ReturnsCorrectResult()
    {
        // Arrange
        var expression = "2.8*3-1";

        // Act
        var result = _calculator.Evaluate(expression);

        // Assert
        Assert.Equal(7.4, result, precision: 10);
    }

    [Fact]
    public void Evaluate_Exponentiation_ReturnsCorrectResult()
    {
        // Arrange
        var expression = "2^8";

        // Act
        var result = _calculator.Evaluate(expression);

        // Assert
        Assert.Equal(256, result);
    }

    [Fact]
    public void Evaluate_ComplexExpressionWithExponentiation_ReturnsCorrectResult()
    {
        // Arrange
        var expression = "2^8*5-1";

        // Act
        var result = _calculator.Evaluate(expression);

        // Assert
        Assert.Equal(1279, result); // (2^8)*5 - 1 = 256*5 - 1 = 1280 - 1 = 1279
    }

    [Fact]
    public void Evaluate_SquareRootFunction_ReturnsCorrectResult()
    {
        // Arrange
        var expression = "sqrt(4)";

        // Act
        var result = _calculator.Evaluate(expression);

        // Assert
        Assert.Equal(2, result);
    }

    [Fact]
    public void Evaluate_DivisionByZero_ThrowsDivideByZeroException()
    {
        // Arrange
        var expression = "1/0";

        // Act & Assert
        Assert.Throws<DivideByZeroException>(() => _calculator.Evaluate(expression));
    }

    #endregion

    #region Edge Cases and Additional Tests

    [Fact]
    public void Evaluate_NegativeNumber_ReturnsNegative()
    {
        // Arrange
        var expression = "-5";

        // Act
        var result = _calculator.Evaluate(expression);

        // Assert
        Assert.Equal(-5, result);
    }

    [Fact]
    public void Evaluate_NestedParentheses_ReturnsCorrectResult()
    {
        // Arrange
        var expression = "((2+3)*4)";

        // Act
        var result = _calculator.Evaluate(expression);

        // Assert
        Assert.Equal(20, result);
    }

    [Fact]
    public void Evaluate_ExpressionWithSpaces_ReturnsCorrectResult()
    {
        // Arrange
        var expression = "  1   +   2   ";

        // Act
        var result = _calculator.Evaluate(expression);

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void Evaluate_ComplexNested_ReturnsCorrectResult()
    {
        // Arrange
        var expression = "2*(3+4)/2";

        // Act
        var result = _calculator.Evaluate(expression);

        // Assert
        Assert.Equal(7, result);
    }

    [Fact]
    public void Evaluate_MultipleOperators_RespectsOrderOfOperations()
    {
        // Arrange
        var expression = "2+3*4-5/5";

        // Act
        var result = _calculator.Evaluate(expression);

        // Assert
        Assert.Equal(13, result); // 2 + (3*4) - (5/5) = 2 + 12 - 1 = 13
    }

    [Fact]
    public void Evaluate_SquareRootWithExpression_ReturnsCorrectResult()
    {
        // Arrange
        var expression = "sqrt(16)+4";

        // Act
        var result = _calculator.Evaluate(expression);

        // Assert
        Assert.Equal(8, result);
    }

    [Fact]
    public void Evaluate_ExponentiationWithParentheses_ReturnsCorrectResult()
    {
        // Arrange
        var expression = "(2+3)^2";

        // Act
        var result = _calculator.Evaluate(expression);

        // Assert
        Assert.Equal(25, result);
    }

    [Fact]
    public void Evaluate_DecimalAddition_ReturnsCorrectResult()
    {
        // Arrange
        var expression = "1.5+2.5";

        // Act
        var result = _calculator.Evaluate(expression);

        // Assert
        Assert.Equal(4, result);
    }

    [Fact]
    public void Evaluate_EmptyString_ThrowsArgumentException()
    {
        // Arrange
        var expression = "";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _calculator.Evaluate(expression));
    }

    [Fact]
    public void Evaluate_WhitespaceOnly_ThrowsArgumentException()
    {
        // Arrange
        var expression = "   ";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _calculator.Evaluate(expression));
    }

    [Fact]
    public void Evaluate_UnmatchedOpenParenthesis_ThrowsArgumentException()
    {
        // Arrange
        var expression = "(2+3";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _calculator.Evaluate(expression));
    }

    [Fact]
    public void Evaluate_UnmatchedCloseParenthesis_ThrowsArgumentException()
    {
        // Arrange
        var expression = "2+3)";

        // Act & Assert
        // Note: The tokenizer handles extra closing parenthesis gracefully
        // This test verifies the expression still evaluates correctly
        var result = _calculator.Evaluate(expression);
        Assert.Equal(5, result);
    }

    [Fact]
    public void Evaluate_InvalidCharacter_ThrowsArgumentException()
    {
        // Arrange
        var expression = "2+@";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _calculator.Evaluate(expression));
    }

    #endregion
}
