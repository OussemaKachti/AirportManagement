using AM.ApplicationCore.Domain;

var plane1 = new Plane();
plane1.PlaneId = 1;
plane1.Capacity = 180;
plane1.ManufactureDate = new DateTime(2018, 4, 12);
plane1.PlaneType = PlaneType.Airbus;

var plane2 = new Plane
{
	PlaneId = 2,
	Capacity = 220,
	ManufactureDate = new DateTime(2020, 9, 18),
	PlaneType = PlaneType.Boeing
};

var flight = new Flight
{
	FlightId = 101,
	Departure = "Tunis",
	Destination = "Paris",
	FlightDate = new DateTime(2026, 6, 12, 8, 30, 0),
	EffectiveArrival = new DateTime(2026, 6, 12, 11, 20, 0),
	EstimatedDuration = 2.5,
	Plane = plane1
};

plane1.Flights.Add(flight);

var passenger = new Passenger
{
	PassengerId = 1,
	FirstName = "Amine",
	LastName = "Ben Salah",
	BirthDate = new DateTime(2001, 2, 14),
	EmailAddress = "amine@example.com",
	PassportNumber = "P123456",
	TelNumber = "+21620000000"
};

var staff = new Staff
{
	PassengerId = 2,
	FirstName = "Sara",
	LastName = "Mansouri",
	BirthDate = new DateTime(1996, 11, 3),
	EmailAddress = "sara@airline.com",
	PassportNumber = "P654321",
	TelNumber = "+21621111111",
	EmploymentDate = new DateTime(2022, 1, 10),
	Function = "Cabin Crew",
	Salary = 2400
};

var traveller = new Traveller
{
	PassengerId = 3,
	FirstName = "Nour",
	LastName = "Ali",
	BirthDate = new DateTime(1999, 8, 22),
	EmailAddress = "nour@example.com",
	PassportNumber = "P777777",
	TelNumber = "+21623333333",
	HealthInformation = "Fit to travel",
	Nationality = "Tunisian"
};

Console.WriteLine("=== Plane demo ===");
Console.WriteLine(plane1);
Console.WriteLine(plane2);

Console.WriteLine();
Console.WriteLine("=== Flight demo ===");
Console.WriteLine(flight);

Console.WriteLine();
Console.WriteLine("=== Passenger demo ===");
Console.WriteLine(passenger);
Console.WriteLine(staff);
Console.WriteLine(traveller);

Console.WriteLine();
Console.WriteLine("=== CheckProfile demo ===");
Console.WriteLine(passenger.CheckProfile("Amine", "Ben Salah"));
Console.WriteLine(passenger.CheckProfile("Amine", "Ben Salah", "amine@example.com"));
Console.WriteLine(passenger.CheckProfile(new Passenger
{
	FirstName = "Amine",
	LastName = "Ben Salah",
	EmailAddress = "amine@example.com"
}));

Console.WriteLine();
Console.WriteLine("=== PassengerType demo ===");
Console.WriteLine(passenger.PassengerType());
Console.WriteLine(staff.PassengerType());
Console.WriteLine(traveller.PassengerType());
