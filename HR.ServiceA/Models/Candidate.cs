
namespace HR.ServiceA.Models;

/// <summary>
/// Модель кандидата на вакансию.
/// Содержит персональные данные, опыт работы,
/// образование и показатели соответствия требованиям вакансии.
/// </summary>
public class Candidate
{
    /// <summary>
    /// Уникальный идентификатор кандидата.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Полное имя кандидата.
    /// </summary>
    public string FullName { get; set; } = string.Empty;

    /// <summary>
    /// Опыт работы кандидата в годах.
    /// </summary>
    public int ExperienceYears { get; set; }

    /// <summary>
    /// Уровень образования кандидата.
    /// </summary>
    public string Education { get; set; } = string.Empty;

    /// <summary>
    /// Процент соответствия навыков кандидата требованиям вакансии (от 0 до 100).
    /// </summary>
    public int SkillsMatchPercent { get; set; }

    /// <summary>
    /// Ожидаемый размер заработной платы кандидата.
    /// </summary>
    public decimal SalaryExpectation { get; set; }

    /// <summary>
    /// Оценка рекомендаций кандидата (от 0 до 100).
    /// </summary>
    public int RecommendationsScore { get; set; }
}
