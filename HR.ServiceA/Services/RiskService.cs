using HR.ServiceA.Models;

namespace HR.ServiceA.Services;

public class RiskService
{
    public RiskForecastResponse CalculateRisk(Employee employee)
    {
        // Веса из модели прогноза текучести
        double w1 = 0.20; // стаж < 6 мес
        double w2 = 0.25; // зарплата ниже рынка (упрощённо < 80000)
        double w3 = 0.25; // нет повышения > 18 мес
        double w4 = 0.15; // переработки > 20%
        double w5 = 0.10; // оценка руководителя < 3
        double w6 = 0.05; // отпуск не брал > 12 мес

        double score = 0;

        if (employee.ExperienceMonths < 6) score += w1;
        if (employee.Salary < 80000) score += w2;
        if (!employee.HasPromotionLast18Months) score += w3;
        if (employee.OvertimePercent > 20) score += w4;
        if (employee.ManagerRating < 3) score += w5;
        if (employee.MonthsWithoutVacation > 12) score += w6;

        string level;
        string recommendation;

        if (score > 0.6)
        {
            level = "high";
            recommendation = "Пересмотреть оклад и условия труда";
        }
        else if (score > 0.3)
        {
            level = "medium";
            recommendation = "Обратить внимание, провести беседу";
        }
        else
        {
            level = "low";
            recommendation = "Риск минимален";
        }

        return new RiskForecastResponse
        {
            EmployeeId = employee.Id,
            RiskScore = Math.Round(score, 2),
            RiskLevel = level,
            Recommendation = recommendation
        };
    }
}