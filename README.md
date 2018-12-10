# SwitchFully-IntakeApp-Backend

## Installation
1. Install SQL Server Express (with id SQLEXPRESS)
2. Run (from the Visual Studio 2017 Developer Command Prompt) the following command: `dotnet clean && dotnet build`
    - It will first perform a clean, followed by a complete build.
3. Set (in API) the User Secret (called SecretKey)
4. Setup the Database / Apply the EF Migrations  (https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/):
    1. Either, from the Package Manager Console (in Visual Studio: tools > NuGet Package Manager > PMC), execute command `Update-Database` in the project Swintake.Domain.
    2. Or, from the (from the Visual Studio 2017 Developer Command Prompt), execute command `dotnet ef database update` from the Swintake.Domain directory.