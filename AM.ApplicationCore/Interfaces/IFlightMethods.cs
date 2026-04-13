using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Interfaces;

public interface IFlightMethods
{
    List<DateTime> GetFlightDates(string destination);
    List<DateTime> GetFlightDatesWithForeach(string destination);
    List<Flight> GetFlights(string filterType, string filterValue);
}
