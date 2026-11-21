
using Microsoft.AspNetCore.Mvc;
using HR.ServiceA.Models;
using HR.ServiceA.Services;

namespace HR.ServiceA.Controllers;

/// <summary>
/// Контроллер для оценки и ранжирования кандидатов
/// по заданным требованиям вакансии.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class CandidatesController : ControllerBase
{
    private readonly ScoreService _scoreService;

    /// <summary>
    /// Создаёт контроллер оценки кандидатов.
    /// </summary>
    /// <param name="scoreService">Сервис расчёта рейтинга кандидатов.</param>
    public CandidatesController(ScoreService scoreService)
    {
        _scoreService = scoreService;
    }

    /// <summary>
    /// Оценивает и ранжирует кандидатов
    /// с учётом требований выбранной вакансии.
    /// </summary>
    /// <param name="request">Список кандидатов и требования вакансии.</param>
    /// <returns>Список кандидатов с рассчитанными оценками.</returns>
    /// <response code="200">Оценка и ранжирование выполнены успешно.</response>
    /// <response code="400">Переданы некорректные данные или пустой список кандидатов.</response>
    [HttpPost("score")]
    [ProducesResponseType(typeof(List<CandidateScoreResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public ActionResult<List<CandidateScoreResponse>> Score([FromBody] ScoreRequest request)
    {
        // 1. Проверка, что запрос пришёл и список не пустой
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

/// <summary>
/// Модель входных данных для оценки кандидатов.
/// Содержит список кандидатов и требования к вакансии.
/// </summary>
public class ScoreRequest
{
    /// <summary>
    /// Список кандидатов для оценки.
    /// </summary>
    public List<Candidate> Candidates { get; set; } = new();

    /// <summary>
    /// Требуемый опыт работы в годах.
    /// </summary>
    public int RequiredExperience { get; set; } = 5;

    /// <summary>
    /// Требуемый уровень образования.
    /// </summary>
    public string RequiredEducation { get; set; } = "высшее";

    /// <summary>
    /// Максимальный размер заработной платы по вакансии.
    /// </summary>
    public decimal MaxSalary { get; set; } = 100000;
}
