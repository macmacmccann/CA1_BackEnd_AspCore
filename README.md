# CA1 Backend - ASP.NET Core API

## About the App

This is a health and meal planning application designed to help users build personalised weekly meal plans tailored to their nutritional goals. The Android frontend connects to a live ASP.NET Core API hosted on Microsoft Azure, which has been tested and validated through Swagger.

The app provides smart plan generation by combining meal macronutrient data — including protein, calories, and fat — with ingredient information to produce targeted plans suited to the user's needs. Whether the goal is muscle building, fat loss, or general health, the app filters and selects meals based on the relevant nutritional criteria and organises them into a structured seven-day plan across breakfast, lunch, and dinner.

---

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
