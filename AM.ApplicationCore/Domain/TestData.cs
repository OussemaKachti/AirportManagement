namespace AM.ApplicationCore.Domain;

public static class TestData
{
    public static List<Plane> Planes { get; } = new()
    {
        new Plane
        {
            PlaneId = 1,
            PlaneType = PlaneType.Boeing,
            Capacity = 150,
            ManufactureDate = new DateTime(2015, 2, 3)
        },
        new Plane
        {
            PlaneId = 2,
            PlaneType = PlaneType.Airbus,
            Capacity = 250,
            ManufactureDate = new DateTime(2020, 11, 11)
        }
    };

    public static List<Staff> StaffMembers { get; } = new()
    {
        new Staff
        {
            FirstName = "captain",
            LastName = "captain",
            EmailAddress = "captain.captain@gmail.com",
            BirthDate = new DateTime(1965, 1, 1),
            EmploymentDate = new DateTime(1999, 1, 1),
            Salary = 99999
        },
        new Staff
        {
            FirstName = "hostess1",
            LastName = "hostess1",
            EmailAddress = "hostess1.hostess1@gmail.com",
            BirthDate = new DateTime(1995, 1, 1),
            EmploymentDate = new DateTime(2020, 1, 1),
            Salary = 999
        },
        new Staff
        {
            FirstName = "hostess2",
            LastName = "hostess2",
            EmailAddress = "hostess2.hostess2@gmail.com",
            BirthDate = new DateTime(1996, 1, 1),
            EmploymentDate = new DateTime(2020, 1, 1),
            Salary = 999
        }
    };

    public static List<Traveller> Travellers { get; } = new()
    {
        new Traveller
        {
            FirstName = "Traveller1",
            LastName = "Traveller1",
            EmailAddress = "Traveller1.Traveller1@gmail.com",
            BirthDate = new DateTime(1980, 1, 1),
            HealthInformation = "No troubles",
            Nationality = "American"
        },
        new Traveller
        {
            FirstName = "Traveller2",
            LastName = "Traveller2",
            EmailAddress = "Traveller2@gmail.com",
            BirthDate = new DateTime(1981, 1, 1),
            HealthInformation = "Some troubles",
            Nationality = "French"
        },
        new Traveller
        {
            FirstName = "Traveller3",
            LastName = "Traveller3",
            EmailAddress = "Traveller3@gmail.com",
            BirthDate = new DateTime(1982, 1, 1),
            HealthInformation = "No troubles",
            Nationality = "Tunisian"
        },
        new Traveller
        {
            FirstName = "Traveller4",
            LastName = "Traveller4",
            EmailAddress = "Traveller4@gmail.com",
            BirthDate = new DateTime(1983, 1, 1),
            HealthInformation = "Some troubles",
            Nationality = "American"
        },
        new Traveller
        {
            FirstName = "Traveller5",
            LastName = "Traveller5",
            EmailAddress = "Traveller5@gmail.com",
            BirthDate = new DateTime(1984, 1, 1),
            HealthInformation = "Some troubles",
            Nationality = "Spanish"
        }
    };

    public static List<Flight> listFlights { get; } = new()
    {
        new Flight
        {
            FlightId = 1,
            Departure = "Tunis",
            Destination = "Paris",
            FlightDate = new DateTime(2022, 1, 1, 15, 10, 10),
            EffectiveArrival = new DateTime(2022, 1, 1, 17, 10, 10),
            Plane = Planes[1],
            EstimatedDuration = 110,
            Passengers = Travellers.Cast<Passenger>().ToList()
        },
        new Flight
        {
            FlightId = 2,
            Departure = "Tunis",
            Destination = "Paris",
            FlightDate = new DateTime(2022, 2, 1, 21, 10, 10),
            EffectiveArrival = new DateTime(2022, 2, 1, 23, 10, 10),
            Plane = Planes[0],
            EstimatedDuration = 105
        },
        new Flight
        {
            FlightId = 3,
            Departure = "Tunis",
            Destination = "Paris",
            FlightDate = new DateTime(2022, 3, 1, 5, 10, 10),
            EffectiveArrival = new DateTime(2022, 3, 1, 6, 40, 10),
            Plane = Planes[0],
            EstimatedDuration = 100
        },
        new Flight
        {
            FlightId = 4,
            Departure = "Tunis",
            Destination = "Madrid",
            FlightDate = new DateTime(2022, 4, 1, 6, 10, 10),
            EffectiveArrival = new DateTime(2022, 4, 1, 8, 10, 10),
            Plane = Planes[0],
            EstimatedDuration = 130
        },
        new Flight
        {
            FlightId = 5,
            Departure = "Tunis",
            Destination = "Madrid",
            FlightDate = new DateTime(2022, 5, 1, 17, 10, 10),
            EffectiveArrival = new DateTime(2022, 5, 1, 18, 50, 10),
            Plane = Planes[0],
            EstimatedDuration = 105
        },
        new Flight
        {
            FlightId = 6,
            Departure = "Tunis",
            Destination = "Lisbonne",
            FlightDate = new DateTime(2022, 6, 1, 20, 10, 10),
            EffectiveArrival = new DateTime(2022, 6, 1, 22, 30, 10),
            Plane = Planes[1],
            EstimatedDuration = 200
        }
    };
}
