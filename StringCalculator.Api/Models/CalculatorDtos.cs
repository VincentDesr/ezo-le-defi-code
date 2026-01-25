namespace StringCalculator.Api.Models;

/// <summary>
/// Request DTO for calculator evaluation.
/// </summary>
/// <param name="Expression">The mathematical expression to evaluate.</param>
public record EvaluateRequest(string Expression);

/// <summary>
/// Response DTO for calculator evaluation.
/// </summary>
/// <param name="Value">The calculated result.</param>
/// <param name="Expression">The original expression.</param>
public record EvaluateResponse(double Value, string Expression);
