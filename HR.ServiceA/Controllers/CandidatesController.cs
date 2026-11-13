using Microsoft.AspNetCore.Mvc;
using HR.ServiceA.Models;
using HR.ServiceA.Services;

namespace HR.ServiceA.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CandidatesController : ControllerBase
{
    private readonly ScoreService _scoreService;

    public CandidatesController(ScoreService scoreService)
    {
        _scoreService = scoreService;
    }

    // POST: api/candidates/score
    [HttpPost("score")]
    public ActionResult<List<CandidateScoreResponse>> Score([FromBody] ScoreRequest request)
    {
        // 1. Проверка, что запрос пришел и список не пустой
        if (request == null || request.Candidates == null || request.Candidates.Count == 0)
        {
            return BadRequest("Список кандидатов пуст. Передайте хотя бы одного кандидата.");
        }

        // 2. Проверка, что обязательные параметры вакансии заданы
        if (request.RequiredExperience <= 0)
        {
            return BadRequest("Параметр RequiredExperience должен быть больше 0.");
        }

        if (request.MaxSalary <= 0)
        {
            return BadRequest("Параметр MaxSalary должен быть больше 0.");
        }

        // 3. Вызов сервиса для расчёта и ранжирования
        var results = _scoreService.RankCandidates(
            request.Candidates,
            request.RequiredExperience,
            request.RequiredEducation,
            request.MaxSalary);

        return Ok(results);
    }
}

// Класс для приема данных из тела POST-запроса
public class ScoreRequest
{
    public List<Candidate> Candidates { get; set; } = new();
    public int RequiredExperience { get; set; } = 5;
    public string RequiredEducation { get; set; } = "высшее";
    public decimal MaxSalary { get; set; } = 100000;
}