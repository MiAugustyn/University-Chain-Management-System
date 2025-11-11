# University Chain Management System

Author: Michał Augustyn

#### Requirements

- .NET 8 SDK or later
- SQL Server (2016+)

### Technolody Stack

- **Framework:** ASP.NET Core MVC
- **ORM:** Entity Framework Core
- **Database:** SQL Server
- **Frontend:** Razor Views, Bootstrap, CSS
- **Client-side Logic:** jQuery
- **Pattern:** Repository Pattern

## Overview

**University Chain Management System (UCMS)** is an ASP.NET Core MVC application built with Entity Framework Core that centralizes and streamlines administration across multiple universities. 
It provides integrated student enrollment, employee management, academic program coordination, and multi-institution oversight.

### Domain Models

UCMS defines nine interconnected entities: **Employee**, **Grade**, **Notification**, **Major**, **Position**, **Student**, **Subject** and the **University**. 
The application configures one-to-many and many-to-many relationships through the **StudentMajor** join table to maintain referential integrity and prevent data redundancy.

<sub>UCMS navbar providing quick access to each model’s Index page (excluding notifications tied directly to the homepage):</sub> \
<img width="1657" height="31" alt="Image" src="https://github.com/user-attachments/assets/9c5ae02c-0e57-4a89-94da-8dddb1024b79" />

### Repository Pattern & Dependency Injection

Repository Pattern is implemented with interface-based abstractions and concrete implementations for all entities.
Each repository encapsulates CRUD operations and occasionally more complex query logic.

### Controllers & Views

Each model has a dedicated controller with complete CRUD actions (Index, Details, Create, Edit, Delete). 
Project contains comprehensive Razor Views featuring form-based interfaces that enable users to interact with all CRUD operations through an intuitive user interface.

<sub>Grades *Index* page with *Create* action at the top and *View*, *Edit* and *Delete* actions separately under each grade:</sub> \
<img width="1302" height="447" alt="image" src="https://github.com/user-attachments/assets/e72bcb8c-9dde-4584-9724-087684cc7f93" />


### Data Validation

Integrated multi-layer validation across all models utilizing ValidationAttributes for email format verification, name constraints, and date validation.

<sub>Form with invalid data after pressing the *Submit* button:</sub> \
<img width="1337" height="542" alt="image" src="https://github.com/user-attachments/assets/e05faf63-18b3-4891-bedd-67e7eb32d26f" />

### Dynamic User Interactions

jQuery-powered enhancements like custom date pickers and dynamic form interactions were implemented for improved user experience. 
Controllers expose endpoints that enable real-time data filtering - for example, dynamically loading students not yet enrolled in a selected major during StudentMajor assignment.

### User Interface & Responsive Design

Designed responsive pages, including a professional Homepage, Navigation Bar, and Footer with custom CSS and Bootstrap styling. 
The homepage aggregates key metrics featuring a latest-notifications panel, year-over-year performance statistics, and quick-action shortcuts.

<sub>UCMS homepage view scaled to a different resolution:</sub> \
<img width="787" height="932" alt="image" src="https://github.com/user-attachments/assets/5778b242-791a-449a-b28d-a0a3d0388440" />

### Utility Infrastructure

Created a centralized Utility class containing reusable constants and helper methods utilized throughout controllers and views. 
This promotes code maintainability, reduces duplication, and enables consistent calculations (for example, enrollment shifts, notification age calculations) across the application.

## Configuration & Deployment

#### Configuration

- Specify the database connection string in the *appsettings.json* file under the **ConnectionStrings** section by setting the **DefaultConnection** key. 
Refer to the sample connection string, provided as an example structure for local development.

<sub>*appsettings.json* file with DefaultConnection key underlined:</sub> \
<img width="1646" height="227" alt="Image" src="https://github.com/user-attachments/assets/0b1218f6-dfd3-48a4-badd-fc6d675790d7" />

#### Deployment

- In the terminal or command prompt, navigate to project root folder
- Confirm *appsettings.json* contains correct connection string
- Run database migrations: `dotnet ef database update`

<sub>Microsoft SQL Server data tables overview after ef database update:</sub> \
<img width="207" height="293" alt="image" src="https://github.com/user-attachments/assets/4482a47e-71ea-4228-826c-8a38ca2fb039" />


- **(Optional)** Seed database with sample data: `dotnet run seeddata` 

  <sub>Every data table will be filled with sample records with relations:</sub> \
  <img width="420" height="295" alt="image" src="https://github.com/user-attachments/assets/65ac0d91-34f9-4240-b017-5bdd89c05ef3" />

  
- Build and run application (locally): `dotnet run`
