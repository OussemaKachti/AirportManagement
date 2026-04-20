using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Services;

public static class PassengerExtension
{
    public static string UpperFullName(this Passenger passenger)
    {
        string firstName = (passenger.FirstName ?? string.Empty).Trim();
        string lastName = (passenger.LastName ?? string.Empty).Trim();

        if (firstName.Length > 0)
        {
            firstName = firstName[..1].ToUpper() + firstName[1..].ToLower();
        }

        if (lastName.Length > 0)
        {
            lastName = lastName[..1].ToUpper() + lastName[1..].ToLower();
        }

        return $"{firstName} {lastName}".Trim();
    }
}
