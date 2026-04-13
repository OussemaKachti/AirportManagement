using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;

var flightMethods = new FlightMethods
{
    Flights = TestData.listFlights
};

Console.WriteLine("==================== ATELIER 2 ====================");
Console.WriteLine("I) Preparation des donnees de test");
Console.WriteLine($"Planes: {TestData.Planes.Count}");
Console.WriteLine($"Staff: {TestData.StaffMembers.Count}");
Console.WriteLine($"Travellers: {TestData.Travellers.Count}");
Console.WriteLine($"Flights: {flightMethods.Flights.Count}");

Console.WriteLine();
Console.WriteLine("Liste des vols de test:");
foreach (Flight flight in flightMethods.Flights)
{
    Console.WriteLine(flight);
}

Console.WriteLine();
Console.WriteLine("II) Structures iteratives");
Console.WriteLine("1) GetFlightDates(\"Paris\") avec boucle for");
List<DateTime> parisDatesFor = flightMethods.GetFlightDates("Paris");
foreach (DateTime date in parisDatesFor)
{
    Console.WriteLine($"- {date:dd/MM/yyyy HH:mm:ss}");
}

Console.WriteLine();
Console.WriteLine("2) GetFlightDates(\"Paris\") avec foreach");
List<DateTime> parisDatesForeach = flightMethods.GetFlightDatesWithForeach("Paris");
foreach (DateTime date in parisDatesForeach)
{
    Console.WriteLine($"- {date:dd/MM/yyyy HH:mm:ss}");
}

Console.WriteLine();
Console.WriteLine("3) GetFlights(\"Destination\", \"Paris\")");
List<Flight> flightsByDestination = flightMethods.GetFlights("Destination", "Paris");
foreach (Flight flight in flightsByDestination)
{
    Console.WriteLine(flight);
}

Console.WriteLine();
Console.WriteLine("================== FIN ATELIER 2 ==================");
