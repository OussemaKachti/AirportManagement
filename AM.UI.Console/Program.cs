using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;

var flightMethods = new FlightMethods
{
    Flights = TestData.listFlights
};

Console.WriteLine("=== GetFlightDates(destination) avec for ===");
List<DateTime> parisDatesFor = flightMethods.GetFlightDates("Paris");
foreach (DateTime date in parisDatesFor)
{
    Console.WriteLine(date);
}

Console.WriteLine();
Console.WriteLine("=== GetFlightDates(destination) avec foreach ===");
List<DateTime> parisDatesForeach = flightMethods.GetFlightDatesWithForeach("Paris");
foreach (DateTime date in parisDatesForeach)
{
    Console.WriteLine(date);
}

Console.WriteLine();
Console.WriteLine("=== GetFlights(\"Destination\", \"Paris\") ===");
List<Flight> flightsByDestination = flightMethods.GetFlights("Destination", "Paris");
foreach (Flight flight in flightsByDestination)
{
    Console.WriteLine(flight);
}
