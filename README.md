## 🗄️ Database Migration

This project uses **Entity Framework Core Migrations** to keep the database schema in sync with the C# domain models.  
Whenever the data model changes (e.g., adding a new entity for logging), a new migration can be created and applied to update the database.

### Common Commands

Using **.NET CLI**:

```bash
# Create a new migration (example: AddLogging)
dotnet ef migrations add AddLogging

# Apply the latest migration(s) to the database
dotnet ef database update

# Remove the last migration (before applying it)
dotnet ef migrations remove
