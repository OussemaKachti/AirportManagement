using System.Collections.Generic;

namespace AM.ApplicationCore.Domain;

public class Passenger
{
    public DateTime BirthDate { get; set; }
    public string? EmailAddress { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PassportNumber { get; set; }
    public string? TelNumber { get; set; }
    public ICollection<Flight> Flights { get; set; }

    public Passenger()
    {
        Flights = new List<Flight>();
    }

    public virtual string PassengerType()
    {
        return "I am a passenger";
    }

    public bool CheckProfile(string firstName, string lastName)
    {
        return string.Equals(FirstName, firstName, StringComparison.OrdinalIgnoreCase)
            && string.Equals(LastName, lastName, StringComparison.OrdinalIgnoreCase);
    }

    public bool CheckProfile(string firstName, string lastName, string emailAddress)
    {
        return CheckProfile(firstName, lastName)
            && string.Equals(EmailAddress, emailAddress, StringComparison.OrdinalIgnoreCase);
    }

    public bool CheckProfile(string firstName, string lastName, params string[] emailAddress)
    {
        if (emailAddress is null || emailAddress.Length == 0)
        {
            return CheckProfile(firstName, lastName);
        }

        return CheckProfile(firstName, lastName, emailAddress[0]);
    }

    public override string ToString()
    {
        return $"Name: {FirstName} {LastName}, Birth Date: {BirthDate:yyyy-MM-dd}, Email: {EmailAddress}, Passport: {PassportNumber}, Phone: {TelNumber}";
    }
}
