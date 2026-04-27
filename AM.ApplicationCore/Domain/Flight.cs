using System.Collections.Generic;

namespace AM.ApplicationCore.Domain;

public class Flight
{
    public int FlightId { get; set; }
    public string? AirlineLogo { get; set; }
    public string Departure { get; set; } = string.Empty;
    public string Destination { get; set; } = string.Empty;
    public DateTime FlightDate { get; set; }
    public DateTime EffectiveArrival { get; set; }
    public double EstimatedDuration { get; set; }
    public Plane? Plane { get; set; }
    public ICollection<Passenger> Passengers { get; set; }

    public Flight()
    {
        Passengers = new List<Passenger>();
    }

    public override string ToString()
    {
        var planeInfo = Plane is null ? "No plane assigned" : $"Plane: {Plane.PlaneType} ({Plane.PlaneId})";
        return $"Flight Id: {FlightId}, Departure: {Departure}, Destination: {Destination}, Flight Date: {FlightDate:yyyy-MM-dd HH:mm}, Arrival: {EffectiveArrival:yyyy-MM-dd HH:mm}, Duration: {EstimatedDuration:0.##}h, {planeInfo}";
    }
}
