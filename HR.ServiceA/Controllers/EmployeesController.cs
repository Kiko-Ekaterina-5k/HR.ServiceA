using Microsoft.AspNetCore.Mvc;
using HR.ServiceA.Models;
using HR.ServiceA.Services;

namespace HR.ServiceA.Controllers;

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

    public EmployeesController(RiskService riskService)
    {
        _riskService = riskService;
    }

    // GET: api/employees
    [HttpGet]
    public ActionResult<List<Employee>> GetAll()
    {
        return Ok(_employees);
    }

    // POST: api/employees
    [HttpPost]
    public ActionResult<Employee> Add([FromBody] Employee employee)
    {
        employee.Id = _employees.Count + 1;
        _employees.Add(employee);
        return Ok(employee);
    }

    // POST: api/employees/forecast
    [HttpPost("forecast")]
    public ActionResult<RiskForecastResponse> Forecast([FromBody] Employee employee)
    {
        var result = _riskService.CalculateRisk(employee);
        return Ok(result);
    }
}