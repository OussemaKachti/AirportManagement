using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Interfaces;

public interface IFlightMethods
{
    List<DateTime> GetFlightDates(string destination);
    List<DateTime> GetFlightDatesWithForeach(string destination);
    List<Flight> GetFlights(string filterType, string filterValue);
    List<string> ShowFlightDetails(Plane plane);
    int ProgrammedFlightNumber(DateTime startDate);
    double DurationAverage(string destination);
    List<Flight> OrderedDurationFlights();
    Flight? LongestFlight();
    List<Traveller> SeniorTravellers(Flight flight);
    IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights();
    Dictionary<string, int> FlightCountByDestination();
    Flight? MostOccupiedFlight();
    List<string> GetDestinations();
    bool ExistsParisFlight();
}
