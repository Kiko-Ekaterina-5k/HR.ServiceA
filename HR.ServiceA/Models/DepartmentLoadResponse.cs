namespace HR.ServiceA.Models;

public class DepartmentLoadResponse
{
    public string Department { get; set; } = string.Empty;
    public List<WeekLoad> Weeks { get; set; } = new();
}

public class WeekLoad
{
    public string Week { get; set; } = string.Empty;
    public int Total { get; set; }
    public int OnVacation { get; set; }
    public int Sick { get; set; }
    public int BusinessTrip { get; set; }
    public int Working { get; set; }
    public double Load { get; set; }
}