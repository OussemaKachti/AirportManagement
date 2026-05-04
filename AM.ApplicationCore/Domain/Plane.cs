using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AM.ApplicationCore.Domain;

public class Plane
{
    public int PlaneId { get; set; }

    [Range(1, int.MaxValue)]
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
