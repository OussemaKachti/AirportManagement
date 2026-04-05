using System.Collections.Generic;

namespace AM.ApplicationCore.Domain;

public class Plane
{
    public int PlaneId { get; set; }
    public int Capacity { get; set; }
    public DateTime ManufactureDate { get; set; }
    public PlaneType PlaneType { get; set; }
    public ICollection<Flight> Flights { get; set; }

    public Plane()
    {
        Flights = new List<Flight>();
    }

    public override string ToString()
    {
        return $"Plane Id: {PlaneId}, Type: {PlaneType}, Capacity: {Capacity}, Manufacture Date: {ManufactureDate:yyyy-MM-dd}";
    }
}
