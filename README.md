# MIM_Assessment
---

# LoanApplication

This is a **Loan Application Management System** built with **ASP.NET Core Blazor** and **Entity Framework Core (EF Core)**. It allows users to manage loan applications, including creating, editing, viewing, and deleting records. The application uses a SQL Server database for data storage.

---

## Table of Contents

1. [Prerequisites](#prerequisites)
2. [Setup Instructions](#setup-instructions)
   - [Clone the Repository](#clone-the-repository)
   - [Database Setup](#database-setup)
   - [Run the Application](#run-the-application)
3. [Additional Steps](#additional-steps)
4. [Project Structure](#project-structure)
5. [Technologies Used](#technologies-used)

---

## Prerequisites

Before running the project, ensure you have the following installed on your machine:

- [.NET9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) (or later)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) (or [Visual Studio Code](https://code.visualstudio.com/))
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads))
- [EF Core Tools](https://docs.microsoft.com/en-us/ef/core/cli/dotnet) (for database migrations)

---

## Setup Instructions

### Clone the Repository

1. Open a terminal or command prompt.
2. Clone the repository:
   ```bash
   git clone https://github.com/Ngwueche/MIM_Assessment.git
   ```
3. Navigate to the project directory:
   ```bash
   cd MIM_Assessment
   ```

---

### Database Setup

This project uses **Entity Framework Core (EF Core)** with migrations to manage the database schema. Follow these steps to set up the database:

1. **Update the Connection String**:
   - Open the `appsettings.json` file in the project.
   - Update the `LoanAppContext` string to point to your SQL Server instance:
     ```json
     "ConnectionStrings": {
       "LoanAppContext": "Server=your-server-name;Database=LoanAppDb;Trusted_Connection=True;TrustServerCertificate=True;"
     }
     ```
     Replace `your-server-name` with your SQL Server instance name (e.g., `localhost`, `.\SQLEXPRESS`).

2. **Apply Migrations**:
   - Open a terminal or command prompt in the project directory.
   - Run the following command to apply the migrations and create the database:
     ```bash
     dotnet ef database update
     ```
   - This will create the `LoanAppDb` database and apply all the migrations.

3. **Verify the Database**:
   - Open SQL Server Management Studio (SSMS) or your preferred SQL client.
   - Verify that the `LoanAppDb` database has been created and contains the necessary tables (e.g., `LoanApplications`).

---

### Run the Application

1. **Run the Application**:
   - In the terminal, run the following command to start the application:
     ```bash
     dotnet run
     ```
   - Alternatively, open the project in **Visual Studio** and press `F5` to run the application.

2. **Access the Application**:
   - Open a browser and navigate to `https://localhost:{port}` (or `http://localhost:{port}`).
   - The application should now be running, and you can start managing loan applications.

---

## Additional Steps

### Seed Data

If you want to seed the database with initial data, create a `DbInitializer` class and call it in `Program.cs`:

```csharp
public static class DbInitializer
{
    public static void Initialize(LoanAppContext context)
    {
        if (!context.LoanApplications.Any())
        {
            context.LoanApplications.AddRange(
                new LoanApplication { ApplicantName = "John Doe", LoanTerm = 12, LoanAmount = 10000.50m, LoanStatus = "Approved", ApplicationDate = DateTime.UtcNow },
                new LoanApplication { ApplicantName = "Jane Smith", LoanTerm = 24, LoanAmount = 20000.75m, LoanStatus = "Pending", ApplicationDate = DateTime.UtcNow }
            );
            context.SaveChanges();
        }
    }
}
```

Call the `DbInitializer` in `Program.cs`:

```csharp
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<LoanAppContext>();
    DbInitializer.Initialize(context);
}
```

---

## Project Structure

The project is organized as follows:

```
LoanApp/
├── Components/            # Layout, Pages
├── Data/                  # Database context and entity models
├── Dtos/                  # Data transfer objects (DTOs)
├── Migrations/            # EF Core migrations
├── Models/                # Models Entities, Enums
├── Pages/                 # Blazor components and pages
├── Services/              # Business logic and service interfaces
├── Shared/                # Shared components and utilities
├── wwwroot/               # Static files (CSS, JS, images)
├── appsettings.json       # Configuration file
├── Program.cs             # Application entry point
└── README.md              # Project documentation
```

---

## Technologies Used

- **Frontend**: Blazor (Razor components)
- **Backend**: ASP.NET Core
- **Database**: SQL Server with EF Core
- **ORM**: Entity Framework Core (EF Core)
- **Styling**: Bootstrap
- **Tools**: Visual Studio, SQL Server Management Studio (SSMS), EF Core CLI

---

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

## Support

If you encounter any issues or have questions, feel free to open an issue on the [GitHub repository](https://github.com/your-username/loan-application-system).

---

Enjoy managing your loan applications! 🚀

---

Let me know if you need further assistance or additional details!
