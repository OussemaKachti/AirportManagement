using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;

var flightMethods = new FlightMethods
{
    Flights = TestData.listFlights
};

Console.WriteLine("==================== ATELIER 3 ====================");

Console.WriteLine("1) GetFlightDates(\"Paris\") avec LINQ");
foreach (DateTime date in flightMethods.GetFlightDates("Paris"))
{
    Console.WriteLine($"- {date:dd/MM/yyyy HH:mm:ss}");
}

Console.WriteLine();
Console.WriteLine("2) ShowFlightDetails(plane Airbus)");
Plane airbus = TestData.Planes.First(p => p.PlaneType == PlaneType.Airbus);
foreach (string detail in flightMethods.ShowFlightDetails(airbus))
{
    Console.WriteLine(detail);
}

Console.WriteLine();
Console.WriteLine("3) ProgrammedFlightNumber(01/01/2022)");
Console.WriteLine(flightMethods.ProgrammedFlightNumber(new DateTime(2022, 1, 1)));

Console.WriteLine();
Console.WriteLine("4) DurationAverage(\"Paris\")");
Console.WriteLine(flightMethods.DurationAverage("Paris"));

Console.WriteLine();
Console.WriteLine("5) OrderedDurationFlights()");
foreach (Flight flight in flightMethods.OrderedDurationFlights())
{
    Console.WriteLine($"{flight.Destination} - {flight.EstimatedDuration}");
}

Console.WriteLine();
Console.WriteLine("6) LongestFlight()");
Console.WriteLine(flightMethods.LongestFlight());

Console.WriteLine();
Console.WriteLine("7) SeniorTravellers(first flight)");
Flight firstFlight = TestData.listFlights.First();
foreach (Traveller traveller in flightMethods.SeniorTravellers(firstFlight))
{
    Console.WriteLine($"{traveller.FirstName} {traveller.LastName} - {traveller.BirthDate:dd/MM/yyyy}");
}

Console.WriteLine();
Console.WriteLine("8) DestinationGroupedFlights()");
foreach (IGrouping<string, Flight> group in flightMethods.DestinationGroupedFlights())
{
    Console.WriteLine($"Destination {group.Key}");
    foreach (Flight flight in group)
    {
        Console.WriteLine($"Decollage : {flight.FlightDate:dd/MM/yyyy HH:mm:ss}");
    }
}

Console.WriteLine();
Console.WriteLine("9) FlightCountByDestination()");
foreach (KeyValuePair<string, int> item in flightMethods.FlightCountByDestination())
{
    Console.WriteLine($"{item.Key}: {item.Value}");
}

Console.WriteLine();
Console.WriteLine("10) MostOccupiedFlight()");
Console.WriteLine(flightMethods.MostOccupiedFlight());

Console.WriteLine();
Console.WriteLine("11) GetDestinations()");
foreach (string destination in flightMethods.GetDestinations())
{
    Console.WriteLine(destination);
}

Console.WriteLine();
Console.WriteLine("12) ExistsParisFlight()");
Console.WriteLine(flightMethods.ExistsParisFlight());

Console.WriteLine();
Console.WriteLine("14) Extension method UpperFullName()");
Console.WriteLine(TestData.Travellers.First().UpperFullName());

Console.WriteLine();
Console.WriteLine("================== FIN ATELIER 3 ==================");
