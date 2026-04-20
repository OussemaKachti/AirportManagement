using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System.Globalization;
using System.Reflection;

namespace AM.ApplicationCore.Services;

public class FlightMethods : IFlightMethods
{
    public List<Flight> Flights { get; set; }

    public FlightMethods()
    {
        Flights = new List<Flight>();
    }

    public List<DateTime> GetFlightDates(string destination)
    {
        return Flights
            .Where(f => string.Equals(f.Destination, destination, StringComparison.OrdinalIgnoreCase))
            .Select(f => f.FlightDate)
            .ToList();
    }

    public List<DateTime> GetFlightDatesWithForeach(string destination)
    {
        var result = new List<DateTime>();

        foreach (var flight in Flights)
        {
            if (string.Equals(flight.Destination, destination, StringComparison.OrdinalIgnoreCase))
            {
                result.Add(flight.FlightDate);
            }
        }

        return result;
    }

    public List<Flight> GetFlights(string filterType, string filterValue)
    {
        var result = new List<Flight>();

        PropertyInfo? property = typeof(Flight).GetProperty(filterType, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
        if (property is null)
        {
            return result;
        }

        if (!IsSimpleType(property.PropertyType))
        {
            return result;
        }

        foreach (var flight in Flights)
        {
            object? propertyValue = property.GetValue(flight);
            if (propertyValue is null)
            {
                continue;
            }

            if (AreEqual(property.PropertyType, propertyValue, filterValue))
            {
                result.Add(flight);
            }
        }

        return result;
    }

    public List<string> ShowFlightDetails(Plane plane)
    {
        return Flights
            .Where(f => f.Plane == plane)
            .Select(f => $"Date: {f.FlightDate:dd/MM/yyyy HH:mm:ss} | Destination: {f.Destination}")
            .ToList();
    }

    public int ProgrammedFlightNumber(DateTime startDate)
    {
        DateTime endDate = startDate.AddDays(7);

        return Flights.Count(f => f.FlightDate >= startDate && f.FlightDate < endDate);
    }

    public double DurationAverage(string destination)
    {
        var filteredFlights = Flights
            .Where(f => string.Equals(f.Destination, destination, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (filteredFlights.Count == 0)
        {
            return 0;
        }

        return filteredFlights.Average(f => f.EstimatedDuration);
    }

    public List<Flight> OrderedDurationFlights()
    {
        return Flights
            .OrderByDescending(f => f.EstimatedDuration)
            .ToList();
    }

    public Flight? LongestFlight()
    {
        return Flights
            .OrderByDescending(f => f.EstimatedDuration)
            .FirstOrDefault();
    }

    public List<Traveller> SeniorTravellers(Flight flight)
    {
        return flight.Passengers
            .OfType<Traveller>()
            .OrderBy(t => t.BirthDate)
            .Take(3)
            .ToList();
    }

    public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
    {
        return Flights
            .GroupBy(f => f.Destination)
            .OrderBy(g => g.Key);
    }

    public Dictionary<string, int> FlightCountByDestination()
    {
        return Flights
            .GroupBy(f => f.Destination)
            .ToDictionary(g => g.Key, g => g.Count());
    }

    public Flight? MostOccupiedFlight()
    {
        return Flights
            .OrderByDescending(f => f.Passengers.Count)
            .FirstOrDefault();
    }

    public List<string> GetDestinations()
    {
        return Flights
            .Select(f => f.Destination)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .OrderBy(d => d)
            .ToList();
    }

    public bool ExistsParisFlight()
    {
        return Flights.Any(f => string.Equals(f.Destination, "Paris", StringComparison.OrdinalIgnoreCase));
    }

    private static bool IsSimpleType(Type type)
    {
        Type checkedType = Nullable.GetUnderlyingType(type) ?? type;

        return checkedType.IsPrimitive
            || checkedType == typeof(string)
            || checkedType == typeof(DateTime)
            || checkedType == typeof(decimal)
            || checkedType == typeof(double)
            || checkedType.IsEnum;
    }

    private static bool AreEqual(Type propertyType, object propertyValue, string filterValue)
    {
        Type checkedType = Nullable.GetUnderlyingType(propertyType) ?? propertyType;

        if (checkedType == typeof(string))
        {
            return string.Equals((string)propertyValue, filterValue, StringComparison.OrdinalIgnoreCase);
        }

        if (checkedType == typeof(int))
        {
            return int.TryParse(filterValue, NumberStyles.Any, CultureInfo.InvariantCulture, out int parsedInt)
                && (int)propertyValue == parsedInt;
        }

        if (checkedType == typeof(double))
        {
            return double.TryParse(filterValue, NumberStyles.Any, CultureInfo.InvariantCulture, out double parsedDouble)
                && (double)propertyValue == parsedDouble;
        }

        if (checkedType == typeof(DateTime))
        {
            return DateTime.TryParse(filterValue, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate)
                && ((DateTime)propertyValue).Date == parsedDate.Date;
        }

        if (checkedType.IsEnum)
        {
            return string.Equals(propertyValue.ToString(), filterValue, StringComparison.OrdinalIgnoreCase);
        }

        return string.Equals(propertyValue.ToString(), filterValue, StringComparison.OrdinalIgnoreCase);
    }
}
