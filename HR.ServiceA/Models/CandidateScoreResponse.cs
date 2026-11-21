
namespace HR.ServiceA.Models;

/// <summary>
/// Модель результата оценки кандидата.
/// Содержит идентификатор кандидата, рассчитанный балл
/// и объяснение полученной оценки.
/// </summary>
public class CandidateScoreResponse
{
    /// <summary>
    /// Идентификатор кандидата, для которого рассчитана оценка.
    /// </summary>
    public int CandidateId { get; set; }

    /// <summary>
    /// Итоговый балл кандидата по результатам оценки.
    /// </summary>
    public double Score { get; set; }

    /// <summary>
    /// Обоснование присвоенной кандидату оценки.
    /// </summary>
    public string Reason { get; set; } = string.Empty;
}
