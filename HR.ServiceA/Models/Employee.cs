
namespace HR.ServiceA.Models;

/// <summary>
/// Модель сотрудника организации.
/// Содержит сведения о стаже, заработной плате,
/// повышениях, переработках и условиях работы.
/// </summary>
public class Employee
{
    /// <summary>
    /// Уникальный идентификатор сотрудника.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Полное имя сотрудника.
    /// </summary>
    public string FullName { get; set; } = string.Empty;

    /// <summary>
    /// Продолжительность трудового стажа сотрудника в месяцах.
    /// </summary>
    public int ExperienceMonths { get; set; }

    /// <summary>
    /// Размер заработной платы сотрудника.
    /// </summary>
    public decimal Salary { get; set; }

    /// <summary>
    /// Признак наличия повышения за последние 18 месяцев.
    /// </summary>
    public bool HasPromotionLast18Months { get; set; }

    /// <summary>
    /// Процент переработок сотрудника.
    /// </summary>
    public int OvertimePercent { get; set; }

    /// <summary>
    /// Оценка сотрудника руководителем по шкале от 1 до 5.
    /// </summary>
    public int ManagerRating { get; set; }

    /// <summary>
    /// Количество месяцев без отпуска.
    /// </summary>
    public int MonthsWithoutVacation { get; set; }
}
