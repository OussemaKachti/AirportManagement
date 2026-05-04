using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AM.ApplicationCore.Domain;

public class Passenger
{
    public int Id { get; set; }

    [DisplayName("Date of Birth")]
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }

    [EmailAddress]
    public string? EmailAddress { get; set; }

    [MinLength(3, ErrorMessage = "FirstName must be at least 3 characters.")]
    [MaxLength(25, ErrorMessage = "FirstName must be at most 25 characters.")]
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    [Key]
    [StringLength(7, MinimumLength = 7)]
    public string PassportNumber { get; set; } = string.Empty;

    [RegularExpression(@"^\d{8}$", ErrorMessage = "TelNumber must contain exactly 8 digits.")]
    public string? TelNumber { get; set; }
    public ICollection<Flight> Flights { get; set; }

    public Passenger()
    {
        Flights = new List<Flight>();
    }

    public virtual string PassengerType()
    {
        return "I am a passenger";
    }

    public bool CheckProfile(string firstName, string lastName)
    {
        return string.Equals(FirstName, firstName, StringComparison.OrdinalIgnoreCase)
            && string.Equals(LastName, lastName, StringComparison.OrdinalIgnoreCase);
    }

    public bool CheckProfile(string firstName, string lastName, string emailAddress)
    {
        return CheckProfile(firstName, lastName)
            && string.Equals(EmailAddress, emailAddress, StringComparison.OrdinalIgnoreCase);
    }

    public bool CheckProfile(string firstName, string lastName, params string[] emailAddress)
    {
        if (emailAddress is null || emailAddress.Length == 0)
        {
            return CheckProfile(firstName, lastName);
        }

        return CheckProfile(firstName, lastName, emailAddress[0]);
    }

    public override string ToString()
    {
        return $"Name: {FirstName} {LastName}, Birth Date: {BirthDate:yyyy-MM-dd}, Email: {EmailAddress}, Passport: {PassportNumber}, Phone: {TelNumber}";
    }
}
