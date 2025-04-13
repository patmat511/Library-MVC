
# 📚 Library MVC Application

This application is a web-based book rental system developed using **ASP.NET Core MVC**. It enables users to browse a collection of books, categorized by genre or type, and perform essential operations such as renting and returning books. Administrators can manage the library by adding new books, editing existing entries, assigning categories, and removing outdated records.

The core functionality of the system is structured using a layered approach. The **Controller layer** handles HTTP requests and coordinates the flow of data between the views and the underlying services. The **Service layer** encapsulates the business logic, including validation rules and domain-specific operations, ensuring that controllers remain thin and maintainable. **Data access is abstracted** through a **Repository layer**, which communicates with the database using Entity Framework Core and exposes clean, reusable interfaces for CRUD operations.

Books are associated with categories through a one-to-many relationship, allowing for efficient filtering and organization of the catalog. Each book can be rented by users, and the application keeps track of active and historical rentals. The system ensures that a book cannot be rented if it is currently checked out, maintaining the integrity of inventory management.

This project serves as a practical demonstration of how to implement separation of concerns using MVC architecture, repositories, and services within a single ASP.NET Core application.

---

## 🚀 How to Run the Application

### 1. Clone the repository

```bash
git clone https://github.com/patmat511/Library-MVC.git
cd Library-MVC
```

### 2. Configure the database connection

Edit the `appsettings.json` file and set your connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=LibraryDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

### 3. Apply database migrations

```bash
dotnet ef database update
```

If you don’t have EF CLI installed:

```bash
dotnet tool install --global dotnet-ef
```

### 4. Run the application

```bash
dotnet run
``` 
