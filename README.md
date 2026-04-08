# CA1 Backend - ASP.NET Core API

This is the ASP.NET Core Web API backend for the CA1 Android application. It provides a restful API with full CRUD support across three resources —
 **Meals**, **Ingredients**, and **Plans** — including one-to-many relationships between Plans and Meals

## Relationships

- **Plan → Meals** (One-to-Many): A plan can contain many meals. Each meal holds a `PlanId` field that links it to a plan.
- **Meals → Ingredients** (One-to-Many): A meal can contain many ingredients.

## Hosting

The API is hosted on **Microsoft Azure App Service** and is accessible as a live public endpoint.

---



## Tech Stack

- **ASP.NET Core 8** Web API
- **C#**
- **Swagger / OpenAPI**
- **Azure App Service** 
