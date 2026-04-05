namespace AM.ApplicationCore.Domain;

public class Staff : Passenger
{
    public DateTime EmploymentDate { get; set; }
    public string? Function { get; set; }
    public double Salary { get; set; }

    public override string PassengerType()
    {
        return $"{base.PassengerType()} I am a Staff Member";
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Employment Date: {EmploymentDate:yyyy-MM-dd}, Function: {Function}, Salary: {Salary:0.##}";
    }
}
