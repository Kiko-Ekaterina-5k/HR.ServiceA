using HR.ServiceA.Models;

namespace HR.ServiceA.Services;

public class ScoreService
{
    public CandidateScoreResponse CalculateScore(Candidate candidate, int requiredExperience,
        string requiredEducation, decimal maxSalary)
    {
        // 1. Нормализация опыта (0-1), защита от деления на 0
        double expNorm = requiredExperience > 0
            ? Math.Min(1.0, (double)candidate.ExperienceYears / requiredExperience)
            : 1.0;

        // 2. Соответствие образования (1.0 если совпадает, 0.5 если нет)
        double eduMatch = 0.5;
        if (!string.IsNullOrEmpty(requiredEducation) && !string.IsNullOrEmpty(candidate.Education))
        {
            if (candidate.Education.ToLower().Contains(requiredEducation.ToLower()))
            {
                eduMatch = 1.0;
            }
        }

        // 3. Совпадение навыков (0-1)
        double skillsNorm = candidate.SkillsMatchPercent / 100.0;
        if (skillsNorm > 1.0) skillsNorm = 1.0;
        if (skillsNorm < 0) skillsNorm = 0;

        // 4. Зарплатные ожидания (0-1), защита от деления на 0 и явное приведение
        double salaryMatch = 1.0;
        if (maxSalary > 0)
        {
            double expectation = (double)candidate.SalaryExpectation;
            double maxSal = (double)maxSalary;
            salaryMatch = Math.Max(0, 1 - (expectation - maxSal) / maxSal);
            if (salaryMatch > 1.0) salaryMatch = 1.0;
        }

        // 5. Рекомендации (0-1)
        double recNorm = candidate.RecommendationsScore / 100.0;
        if (recNorm > 1.0) recNorm = 1.0;
        if (recNorm < 0) recNorm = 0;

        // 6. Взвешенная формула score
        double score = 0.3 * expNorm
                     + 0.25 * eduMatch
                     + 0.2 * skillsNorm
                     + 0.15 * salaryMatch
                     + 0.1 * recNorm;

        // Округляем до 3 знаков
        score = Math.Round(score, 3);

        return new CandidateScoreResponse
        {
            CandidateId = candidate.Id,
            Score = score,
            Reason = $"Опыт: {expNorm:F2}, Образование: {eduMatch:F2}, " +
                     $"Навыки: {skillsNorm:F2}, Зарплата: {salaryMatch:F2}, Рекомендации: {recNorm:F2}"
        };
    }

    public List<CandidateScoreResponse> RankCandidates(List<Candidate> candidates,
        int requiredExperience, string requiredEducation, decimal maxSalary)
    {
        var results = candidates
            .Select(c => CalculateScore(c, requiredExperience, requiredEducation, maxSalary))
            .OrderByDescending(r => r.Score)
            .ToList();

        return results;
    }
}