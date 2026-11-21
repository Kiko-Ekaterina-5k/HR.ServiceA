
using Microsoft.AspNetCore.Mvc;
using HR.ServiceA.Models;
using HR.ServiceA.Services;

namespace HR.ServiceA.Controllers;

/// <summary>
/// Контроллер для анализа загрузки сотрудников подразделения.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class LoadController : ControllerBase
{
    private readonly LoadService _loadService;

    /// <summary>
    /// Создаёт контроллер анализа загрузки.
    /// </summary>
    /// <param name="loadService">Сервис расчёта загрузки подразделения.</param>
    public LoadController(LoadService loadService)
    {
        _loadService = loadService;
    }

    /// <summary>
    /// Рассчитывает показатели загрузки сотрудников подразделения
    /// с учётом отсутствий.
    /// </summary>
    /// <param name="request">Данные подразделения и сведения об отсутствиях сотрудников.</param>
    /// <returns>Результаты анализа загрузки подразделения.</returns>
    /// <response code="200">Расчёт загрузки успешно выполнен.</response>
    [HttpPost("department")]
    [ProducesResponseType(typeof(DepartmentLoadResponse), StatusCodes.Status200OK)]
    public ActionResult<DepartmentLoadResponse> Calculate([FromBody] LoadRequest request)
    {
        var result = _loadService.CalculateLoad(
            request.Department,
            request.TotalEmployees,
            request.Absences);

        return Ok(result);
    }
}

/// <summary>
/// Модель входных данных для расчёта загрузки подразделения.
/// </summary>
public class LoadRequest
{
    /// <summary>
    /// Название подразделения.
    /// </summary>
    public string Department { get; set; } = string.Empty;

    /// <summary>
    /// Общее количество сотрудников подразделения.
    /// </summary>
    public int TotalEmployees { get; set; }

    /// <summary>
    /// Список сведений об отсутствиях сотрудников по неделям.
    /// </summary>
    public List<WeekLoad> Absences { get; set; } = new();
}
