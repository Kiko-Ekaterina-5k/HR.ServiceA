namespace HR.ServiceA.Models;

public class CandidateScoreResponse
{
    public int CandidateId { get; set; }
    public double Score { get; set; }
    public string Reason { get; set; } = string.Empty;
}