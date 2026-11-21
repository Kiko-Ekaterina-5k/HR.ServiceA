
using Microsoft.AspNetCore.Mvc;
using HR.ServiceA.Models;
using HR.ServiceA.Services;

namespace HR.ServiceA.Controllers;

/// <summary>
/// Контроллер для управления данными сотрудников
/// и прогнозирования риска текучести кадров.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    // Временное хранилище (в реальности — БД)
    private static List<Employee> _employees = new()
    {
        new Employee
        {
            Id = 1,
            FullName = "Иванов Иван",
            ExperienceMonths = 5,
            Salary = 70000,
            HasPromotionLast18Months = false,
            OvertimePercent = 25,
            ManagerRating = 2,
            MonthsWithoutVacation = 14
        }
    };

    private readonly RiskService _riskService;

    /// <summary>
    /// Создаёт контроллер сотрудников.
    /// </summary>
    /// <param name="riskService">Сервис расчёта риска увольнения.</param>
    public EmployeesController(RiskService riskService)
    {
        _riskService = riskService;
    }

    /// <summary>
    /// Получает полный список сотрудников.
    /// </summary>
    /// <returns>Список сотрудников.</returns>
    /// <response code="200">Список сотрудников успешно получен.</response>
    [HttpGet]
    [ProducesResponseType(typeof(List<Employee>), StatusCodes.Status200OK)]
    public ActionResult<List<Employee>> GetAll()
    {
        return Ok(_employees);
    }

    /// <summary>
    /// Добавляет нового сотрудника в систему.
    /// </summary>
    /// <param name="employee">Данные нового сотрудника.</param>
    /// <returns>Добавленный сотрудник с присвоенным идентификатором.</returns>
    /// <response code="200">Сотрудник успешно добавлен.</response>
    [HttpPost]
    [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
    public ActionResult<Employee> Add([FromBody] Employee employee)
    {
        employee.Id = _employees.Count + 1;
        _employees.Add(employee);
        return Ok(employee);
    }

    /// <summary>
    /// Рассчитывает риск увольнения сотрудника.
    /// </summary>
    /// <param name="employee">Данные сотрудника для анализа.</param>
    /// <returns>Оценка риска, уровень риска и рекомендация.</returns>
    /// <response code="200">Прогноз успешно рассчитан.</response>
    [HttpPost("forecast")]
    [ProducesResponseType(typeof(RiskForecastResponse), StatusCodes.Status200OK)]
    public ActionResult<RiskForecastResponse> Forecast([FromBody] Employee employee)
    {
        var result = _riskService.CalculateRisk(employee);
        return Ok(result);
    }
}
