
namespace HR.ServiceA.Models;

/// <summary>
/// Модель результата анализа загрузки подразделения.
/// Содержит название подразделения и показатели загрузки по неделям.
/// </summary>
public class DepartmentLoadResponse
{
    /// <summary>
    /// Название подразделения, для которого выполнен анализ.
    /// </summary>
    public string Department { get; set; } = string.Empty;

    /// <summary>
    /// Список показателей загрузки подразделения по неделям.
    /// </summary>
    public List<WeekLoad> Weeks { get; set; } = new();
}

/// <summary>
/// Модель показателей загрузки сотрудников за определённую неделю.
/// </summary>
public class WeekLoad
{
    /// <summary>
    /// Обозначение анализируемой недели.
    /// </summary>
    public string Week { get; set; } = string.Empty;

    /// <summary>
    /// Общее количество сотрудников подразделения.
    /// </summary>
    public int Total { get; set; }

    /// <summary>
    /// Количество сотрудников, находящихся в отпуске.
    /// </summary>
    public int OnVacation { get; set; }

    /// <summary>
    /// Количество сотрудников, находящихся на больничном.
    /// </summary>
    public int Sick { get; set; }

    /// <summary>
    /// Количество сотрудников, находящихся в командировке.
    /// </summary>
    public int BusinessTrip { get; set; }

    /// <summary>
    /// Количество сотрудников, находящихся на работе.
    /// </summary>
    public int Working { get; set; }

    /// <summary>
    /// Рассчитанный показатель загрузки подразделения.
    /// </summary>
    public double Load { get; set; }
}
