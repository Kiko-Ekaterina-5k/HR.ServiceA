using HR.ServiceA.Models;

namespace HR.ServiceA.Services;

public class LoadService
{
    public DepartmentLoadResponse CalculateLoad(string department, int totalEmployees,
        List<WeekLoad> absences)
    {
        var result = new DepartmentLoadResponse
        {
            Department = department,
            Weeks = new List<WeekLoad>()
        };

        foreach (var week in absences)
        {
            var working = totalEmployees - week.OnVacation - week.Sick - week.BusinessTrip;
            var load = totalEmployees > 0 ? (double)working / totalEmployees : 0;

            result.Weeks.Add(new WeekLoad
            {
                Week = week.Week,
                Total = totalEmployees,
                OnVacation = week.OnVacation,
                Sick = week.Sick,
                BusinessTrip = week.BusinessTrip,
                Working = working,
                Load = Math.Round(load, 2)
            });
        }

        return result;
    }
}