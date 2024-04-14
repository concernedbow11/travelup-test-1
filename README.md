# Project Documentation

## Overview
This project is a web application built using ASP.NET Core MVC and Entity Framework Core. It provides CRUD (Create, Read, Update, Delete) operations for managing items. Users can view a list of items, create new items, edit existing items, and delete items from the list. Additionally, a simple RESTful API is implemented to expose CRUD operations for items, allowing external clients to interact with the application programmatically.

## Features

### ASP.NET MVC Web Application
- **Description:** Create a simple ASP.NET MVC web application with two views: one for displaying a list of items and another for adding a new item.
- **Implementation:** Implemented using ASP.NET Core MVC framework with Razor syntax for rendering views.
- **Views:** 
  - List View: Displays a list of items with their names and prices.
  - Create View: Provides a form to add a new item.
  - Delete View: Delete an item.
  - Edit View: Edit the values of an item that was already added.

### RESTful API
- **Description:** Extend the existing application by creating a simple RESTful API that exposes CRUD operations for the items.
- **API Endpoints:** Implemented endpoints for:
  - Retrieving a list of items
  - Getting details for a specific item
  - Adding a new item
  - Updating an existing item
  - Deleting an item

### Entity Framework Integration
- **Description:** Integrate Entity Framework for database interaction.
- **Database:** Configured the application to use a SQL Server database for storing and retrieving item information.
- **Entity Framework Core:** Utilized Entity Framework Core to interact with the database.
- **Error Handling:** Implemented proper handling of database connections and error scenarios to ensure application stability.

### Integration Testing
- **Description:** Wrote a set of integration tests to validate the functionality of both the front-end and back-end components.
- **Testing Frameworks:** Utilized MSTest for backend and NUnit for frontend testing.
- **Test Scenarios:** Covered scenarios for CRUD operations, API endpoints, and error handling.

## Technologies Used
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server Database
- HTML/CSS
- JavaScript
- MSTest
- NUnit

- 
# Project Structure

## Controllers
- **ItemController.cs**: Handles HTTP requests and implements CRUD operations for managing items.
  
## Models
- **Item.cs**: Represents the item entity with properties like Id, Name, and Price.

## Views
- **Index.cshtml**: Displays a list of items.
- **Create.cshtml**: Provides a form to add a new item.
- **Edit.cshtml**: Allows editing of existing items.
- **Delete.cshtml**: Allows deletion of items.

## API Endpoints
- **/Item**: API endpoint for CRUD operations on items.

## Tests
- **MSTest and NUnitTest projects**: Contains integration tests for the back-end and front-end components.

# How It Works

1. **MVC Architecture**: The application follows the Model-View-Controller (MVC) architectural pattern. 
   - **Model**: Represents the data (e.g., Item).
   - **View**: Renders the user interface (e.g., Index.cshtml, Create.cshtml).
   - **Controller**: Handles incoming requests, processes data, and sends responses (e.g., ItemController.cs).

2. **Database Interaction**: Entity Framework Core is used for database interaction. 
   - The `AppDbContext` class manages interactions with the SQL Server database.
   - The `Item` class represents an entity in the database and is mapped to a corresponding table.

3. **Front-End Functionality**:
   - **List View**: Displays a list of items retrieved from the database.
   - **Create View**: Provides a form to add a new item. Upon submission, the data is sent to the server to be stored in the database.
   - **Edit View**: Allows editing of existing items. Changes are saved to the database upon submission.
   - **Delete View**: Allows deletion of items. Deletion is confirmed by the user and the item is removed from the database.

4. **API Integration**:
   - The RESTful API exposes endpoints for CRUD operations on items, allowing external clients to interact with the application programmatically.
   - API endpoints are implemented in the `ItemController.cs` file and follow RESTful conventions.

5. **Testing**:
   - Integration tests are written to ensure the functionality of both the front-end and back-end components.
   - Tests cover scenarios for CRUD operations, API endpoints, and error handling to ensure the application behaves as expected.
