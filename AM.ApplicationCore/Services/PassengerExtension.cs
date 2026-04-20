using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Services;

public static class PassengerExtension
{
    public static string UpperFullName(this Passenger passenger)
    {
        string firstName = (passenger.FirstName ?? string.Empty).Trim().ToUpper();
        string lastName = (passenger.LastName ?? string.Empty).Trim().ToUpper();
        return $"{firstName} {lastName}".Trim();
    }
}
