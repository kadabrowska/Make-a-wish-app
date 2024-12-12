# Make A Wish App 🎁

The **Make A Wish App** is a platform designed to facilitate gift exchanges within a group of friends or colleagues. It allows assigning "givers" to "receivers" with simplicity and transparency.

---

## Features

- User login and registration using JWT (JSON Web Token).
- Assign users as "givers" and "receivers."
- Validation to ensure users cannot assign themselves or someone who is already assigned.
- Prevention of duplicate assignments.
- Database integration for storing user and assignment data.

---

## Technology Stack

The application consists of two main parts:

### Frontend
- **Framework:** Angular
- **Languages:** TypeScript, HTML, CSS
- **Key Features:**
  - User login and registration handling.
  - Display a list of available users.
  - Real-time updates on assignments.
  - Form validation and dynamic button disabling.

### Backend
- **Framework:** ASP.NET Core
- **Database:** Entity Framework with SQL Server
- **Key Features:**
  - User authentication using JWT.
  - CRUD operations for database management.
  - Validation of assignment logic for givers and receivers.
  - RESTful API for communication with the frontend.
 
  ### To Do:
  - Adding, deleting and updating gifts.
  - Viewing gifts of the chosen person.
  - Styling.

---

## How to Run

### Backend
1. Open the backend project in Visual Studio.
2. Update the `appsettings.json` file with the appropriate configuration (e.g., ConnectionString).
3. Apply database migrations:
   dotnet ef database update

4. Run the backend using Visual Studio or the following command:
dotnet run



### Frontend
1. Navigate to the frontend directory:
cd frontend


2. Install the required dependencies:
npm install


3. Run the application:
ng serve

4. Open your browser and go to http://localhost:4200.

