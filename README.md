# AirportManagement Atelier

This repository contains a clean .NET 8 implementation of the airport management atelier.

## Projects

- `AM.ApplicationCore`: domain model and business logic
- `AM.UI.Console`: console demo that exercises the domain model

## Implemented domain model

- `Plane`
- `Flight`
- `Passenger`
- `Traveller`
- `Staff`
- `PlaneType`

## What the console demo shows

- Plane creation through object initializers
- Flight navigation to a plane
- Passenger inheritance with `Staff` and `Traveller`
- `CheckProfile(...)` overloads
- Polymorphic `PassengerType()` behavior

## How to run

Open the solution in Visual Studio or run the console project from the workspace root.

```bash
dotnet run --project AM.UI.Console/AM.UI.Console.csproj
```

## Notes about the atelier steps

The workshop asks to create a parameterized `Plane` constructor and then remove it to observe object initializers. The final code in this repository keeps the clean final state: the default constructor plus object initializers in the console demo.
