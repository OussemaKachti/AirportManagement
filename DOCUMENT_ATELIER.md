    # Document d execution - Atelier Airport Management

## 1) Ce que je dois avoir

- SDK .NET 8 installe (obligatoire)
- Un terminal ouvert dans le dossier racine du projet
- Les 2 projets dans la solution:
	- AM.ApplicationCore
	- AM.UI.Console

## 2) Verification de l environnement

Executer ces commandes:

dotnet --version
dotnet --list-sdks
dotnet --list-runtimes

Resultat attendu:

- Une version 8.0.x doit apparaitre dans le SDK
- Microsoft.NETCore.App 8.0.x doit apparaitre dans les runtimes

## 3) Compilation

Depuis la racine du projet, executer:

dotnet restore
dotnet build AM.ApplicationCore/AM.ApplicationCore.csproj
dotnet build AM.UI.Console/AM.UI.Console.csproj

## 4) Execution

Option 1 (depuis la racine):

dotnet run --project AM.UI.Console/AM.UI.Console.csproj

Option 2 (depuis le dossier AM.UI.Console):

dotnet run

## 5) Ce que le programme affiche

Le programme teste les methodes demandees:

- GetFlightDates("Paris") avec la boucle for
- GetFlightDatesWithForeach("Paris") avec foreach
- GetFlights("Destination", "Paris")

## 6) Erreurs frequentes

1. Erreur: Argument obligatoire manquant pour l option --project
Cause: commande incomplete
Correction: utiliser le chemin complet du projet

2. Erreur: You must install or update .NET to run this application
Cause: .NET 8 non installe
Correction: installer le SDK .NET 8 puis reouvrir le terminal
