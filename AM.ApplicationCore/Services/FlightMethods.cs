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
        var result = new List<DateTime>();

        for (int i = 0; i < Flights.Count; i++)
        {
            if (string.Equals(Flights[i].Destination, destination, StringComparison.OrdinalIgnoreCase))
            {
                result.Add(Flights[i].FlightDate);
            }
        }

        return result;
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
