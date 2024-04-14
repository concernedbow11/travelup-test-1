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
  
# Components

## ItemController.cs

The `ItemController.cs` file is a C# class that acts as the controller for the application's item-related functionality. It handles incoming HTTP requests and implements CRUD operations (Create, Read, Update, Delete) for managing items in the application.

### Responsibilities:
- Handle requests for displaying a list of items, adding a new item, editing an existing item, and deleting an item.
- Interact with the database using Entity Framework Core to perform database operations such as querying, inserting, updating, and deleting items.
- Implement API endpoints for exposing CRUD operations on items to external clients.
- Manage the flow of data between the views (UI) and the models (data) in the application.

### Key Methods:
- **Index**: Displays a list of items retrieved from the database.
- **Create**: Handles the creation of a new item and stores it in the database.
- **Edit**: Allows editing of an existing item and updates it in the database.
- **Delete**: Handles the deletion of an item from the database.

## Index.cshtml

The `Index.cshtml` file is a Razor view that displays a list of items retrieved from the controller. It is responsible for rendering the user interface to show the items in a tabular format.

### Responsibilities:
- Render a table to display the list of items.
- Iterate through each item in the model and display its details such as ID, name, and price.
- Provide navigation links for adding a new item and deleting an item.

### Key Components:
- **Table**: Renders a table structure to display item details.
- **@foreach Loop**: Iterates through each item in the model and generates a table row for each item.
- **Navigation Links**: Provides links for navigating to the Create and Delete actions.

## Create.cshtml

The `Create.cshtml` file is a Razor view that allows users to add a new item to the system. It provides input fields for entering the details of the new item and a submit button to save the item.

### Responsibilities:
- Render a form for capturing details of a new item.
- Provide input fields for entering the name and price of the item.
- Validate user input and display validation errors if necessary.

### Key Components:
- **Form**: Renders an HTML form element to collect user input.
- **Input Fields**: Provides fields for entering the name and price of the new item.
- **Validation**: Uses ASP.NET Core's built-in validation features to ensure data integrity.


## Edit.cshtml

The `Edit.cshtml` file is a Razor view that allows users to modify the details of an existing item. It presents input fields populated with the current values of the item, allowing users to update them.

### Responsibilities:
- Render a form pre-populated with the current details of the item.
- Provide input fields for modifying the name and price of the item.
- Validate user input and display validation errors if necessary.

### Key Components:
- **Form**: Renders an HTML form element to edit the item.
- **Input Fields**: Pre-populated with the current values of the item for editing.
- **Validation**: Ensures that the user input conforms to specified criteria.

## Delete.cshtml

The `Delete.cshtml` file is a Razor view that prompts users to confirm the deletion of an item. It displays the details of the item to be deleted and asks for user confirmation before proceeding.

### Responsibilities:
- Display details of the item to be deleted.
- Prompt the user to confirm the deletion action.
- Provide options for confirming or canceling the deletion.

### Key Components:
- **Item Details**: Displays the name of the item to be deleted.
- **Confirmation Message**: Asks the user to confirm the deletion action.
- **Buttons**: Provides options for confirming or canceling the deletion.

