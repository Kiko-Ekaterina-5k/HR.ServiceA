using Microsoft.AspNetCore.Mvc;
using HR.ServiceA.Models;
using HR.ServiceA.Services;

namespace HR.ServiceA.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoadController : ControllerBase
{
    private readonly LoadService _loadService;

    public LoadController(LoadService loadService)
    {
        _loadService = loadService;
    }

    // POST: api/load/department
    [HttpPost("department")]
    public ActionResult<DepartmentLoadResponse> Calculate([FromBody] LoadRequest request)
    {
        var result = _loadService.CalculateLoad(
            request.Department,
            request.TotalEmployees,
            request.Absences);
        return Ok(result);
    }
}

public class LoadRequest
{
    public string Department { get; set; } = string.Empty;
    public int TotalEmployees { get; set; }
    public List<WeekLoad> Absences { get; set; } = new();
}