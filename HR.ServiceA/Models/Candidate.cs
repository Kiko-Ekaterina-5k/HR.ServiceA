namespace HR.ServiceA.Models;

public class Candidate
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public int ExperienceYears { get; set; }
    public string Education { get; set; } = string.Empty;
    public int SkillsMatchPercent { get; set; } // 0-100
    public decimal SalaryExpectation { get; set; }
    public int RecommendationsScore { get; set; } // 0-100
}