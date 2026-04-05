using System.Collections.Generic;

namespace AM.ApplicationCore.Domain;

public class Passenger
{
    public int PassengerId { get; set; }
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

    public bool CheckProfile(Passenger passenger)
    {
        ArgumentNullException.ThrowIfNull(passenger);
        return CheckProfile(passenger.FirstName ?? string.Empty, passenger.LastName ?? string.Empty, passenger.EmailAddress ?? string.Empty);
    }

    public override string ToString()
    {
        return $"Passenger Id: {PassengerId}, Name: {FirstName} {LastName}, Birth Date: {BirthDate:yyyy-MM-dd}, Email: {EmailAddress}, Passport: {PassportNumber}, Phone: {TelNumber}";
    }
}
