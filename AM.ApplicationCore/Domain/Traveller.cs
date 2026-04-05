namespace AM.ApplicationCore.Domain;

public class Traveller : Passenger
{
    public string? HealthInformation { get; set; }
    public string? Nationality { get; set; }

    public override string PassengerType()
    {
        return $"{base.PassengerType()} I am a traveller";
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Health Information: {HealthInformation}, Nationality: {Nationality}";
    }
}
