# CA1 Backend API

# https://marksapi-d7fvaucyewh4excm.canadaeast-01.azurewebsites.net/swagger

A meal planning rest api built with ASP Core backed by an Azure SQL database and server and deployed to Azure App Service.

---

## ASP.NET

The backend is built using NET 8. It exposes three controllers — Meals, Plans, and Ingredients full CRUD operations. 
The app uses dependency injection to supply the database context to each controller

---

## Deployed on Azure

The API is deployed to Azure App Service. It is accessible at:

https://marksapi-d7fvaucyewh4excm.canadaeast-01.azurewebsites.net

The app connects to an Azure SQL database hosted on `marksserver12345.database.windows.net`. 
Connection instability is handled in the code 
Security is managed with environmental variables and sql authentication in the base code .


---

## SQL Database

The database is an Azure SQL database containing three tables: 
 Meals Plans Ingredients
 The `Meals` table has an optional foreign key (`PlanId`) linking each meal to a plan : a one-to-many relationship between Plans and Meals.

---

## Entity Framework Code-First

The database schema is managed using Entity Framework Core with a code-first approach. 
Models are defined in C# and migrations are generated using the EF Core tools.  
 Seed data for meals, plans, and ingredients is defined in `AppDbContext.OnModelCreating`   
and applied automatically on startup via `db.Database.Migrate()`

---

## OpenAPI / Swagger

The API provides OpenAPI metadata via Swashbuckle.
 The Swagger UI is available at the root URL and lists all available endpoints with request/response schemas.
 It can be used to test endpoints directly in the browser.


## CI/CD Pipeline

A GitHub Actions pipeline is configured in .github/workflows/  
 On every push to the `main` branch it automatically  
1 builds the project  
2 publishes the release artifact  
3 deploys it to Azure App Service  
The pipeline also imports the OpenAPI specification into Azure API Management on each deployment.  

---

## Source Code

Source code is in the github . The main branch is protected and all deployments are triggered via push to main.



---

## API Endpoints

### Meals

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | /api/meals | Get all meals |
| GET | /api/meals/{id} | Get meal by ID |
| GET | /api/meals/search/name/{name} | Search meals by name |
| GET | /api/meals/search/category/{category} | Filter by category |
| GET | /api/meals/search/difficulty/{difficulty} | Filter by difficulty |
| GET | /api/meals/search/rating/{rating} | Filter by rating |
| GET | /api/meals/search/calories/{calories} | Filter by calories |
| GET | /api/meals/search/protein/{protein} | Filter by protein |
| GET | /api/meals/search/minprotein/{minProtein} | Filter by minimum protein |
| GET | /api/meals/search/totalFat/{totalFat} | Filter by total fat |
| GET | /api/meals/search/prepTime/{prepTime} | Filter by prep time |
| GET | /api/meals/search/cookTime/{cookTime} | Filter by cook time |
| GET | /api/meals/search/servings/{servings} | Filter by servings |
| POST | /api/meals | Create a new meal |
| PUT | /api/meals/{id} | Update a meal |
| DELETE | /api/meals/{id} | Delete a meal |

### Plans

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | /api/plans | Get all plans |
| GET | /api/plans/{id} | Get plan by ID |
| GET | /api/plans/{id}/meals | Get all meals in a plan |
| POST | /api/plans | Create a new plan |
| PUT | /api/plans/{id} | Update a plan |
| DELETE | /api/plans/{id} | Delete a plan |
| POST | /api/plans/{planId}/meals/{mealId} | Assign a meal to a plan |
| DELETE | /api/plans/{planId}/meals/{mealId} | Remove a meal from a plan |

### Ingredients

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | /api/ingredients | Get all ingredients |
| GET | /api/ingredients/{id} | Get ingredient by ID |
| GET | /api/ingredients/search | Search with query params: name, origin, minPrice, maxPrice, minProtein, maxProtein, minFats, maxFats |
| GET | /api/ingredients/search/name/{name} | Search by name |
| GET | /api/ingredients/search/origin/{origin} | Filter by origin |
| GET | /api/ingredients/search/price/{maxPrice} | Filter by max price |
| GET | /api/ingredients/search/protein/{minProtein} | Filter by min protein |
| GET | /api/ingredients/search/fat/{minFat} | Filter by min fat |
| GET | /api/ingredients/isOrganic/{isOrganic} | Filter by organic status |
| GET | /api/ingredients/page | Paginated results (query params: page, pageSize) |
| POST | /api/ingredients | Add a new ingredient |
| PUT | /api/ingredients/{id} | Full update of an ingredient |
| PUT | /api/ingredients/simple-update/{id} | Update name and price only |
| DELETE | /api/ingredients/{id} | Delete an ingredient |

---


