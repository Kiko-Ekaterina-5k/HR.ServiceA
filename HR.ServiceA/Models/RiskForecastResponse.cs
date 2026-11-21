
namespace HR.ServiceA.Models;

/// <summary>
/// Модель результата прогнозирования риска увольнения сотрудника.
/// Содержит идентификатор сотрудника, оценку риска,
/// уровень риска и рекомендацию по его снижению.
/// </summary>
public class RiskForecastResponse
{
    /// <summary>
    /// Идентификатор сотрудника, для которого выполнен прогноз.
    /// </summary>
    public int EmployeeId { get; set; }

    /// <summary>
    /// Числовая оценка риска увольнения сотрудника.
    /// </summary>
    public double RiskScore { get; set; }

    /// <summary>
    /// Уровень риска увольнения сотрудника.
    /// </summary>
    public string RiskLevel { get; set; } = string.Empty;

    /// <summary>
    /// Рекомендация по снижению риска увольнения сотрудника.
    /// </summary>
    public string Recommendation { get; set; } = string.Empty;
}
