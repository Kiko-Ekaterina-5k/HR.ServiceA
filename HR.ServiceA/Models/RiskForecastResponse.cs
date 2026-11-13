namespace HR.ServiceA.Models;

public class RiskForecastResponse
{
    public int EmployeeId { get; set; }
    public double RiskScore { get; set; }
    public string RiskLevel { get; set; } = string.Empty;
    public string Recommendation { get; set; } = string.Empty;
}
