namespace HR.ServiceA.Models;

public class Employee
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public int ExperienceMonths { get; set; }
    public decimal Salary { get; set; }
    public bool HasPromotionLast18Months { get; set; }
    public int OvertimePercent { get; set; }
    public int ManagerRating { get; set; } // 1-5
    public int MonthsWithoutVacation { get; set; }
}
