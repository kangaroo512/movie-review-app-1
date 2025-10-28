# 🎬 Movie Review API

A RESTful API built with **ASP.NET Core 8**, **Entity Framework Core**, and **FluentValidation** that allows users to manage movies and reviews.
This backend can serve as the foundation for a movie review platform, handling CRUD operations for movies and their associated reviews.

---

## 🚀 Live Demo

The API is currently deployed on **Render**:
👉 [https://movie-review-app-1-4avq.onrender.com](https://movie-review-app-1-4avq.onrender.com)

> You can explore the API endpoints using Swagger (if enabled) at:
> [https://movie-review-app-1-4avq.onrender.com/swagger](https://movie-review-app-1-4avq.onrender.com/swagger)

---

## 🧱 Features

* CRUD endpoints for managing **Movies** and **Reviews**
* **DTO pattern** for clean data transfer
* **FluentValidation** for request validation
* **Repository and Service Layers** for separation of concerns
* **Entity Framework Core** for database interactions
* Built with **.NET 8**
* Ready for containerization with **Docker**

---

## 🧩 Technologies Used

| Category             | Technologies                       |
| -------------------- | ---------------------------------- |
| Backend Framework    | ASP.NET Core 8                     |
| ORM                  | Entity Framework Core              |
| Validation           | FluentValidation                   |
| Database             | SQL Server / SQLite (configurable) |
| Dependency Injection | Built-in .NET DI                   |
| API Testing          | Swagger / Postman                  |
| Deployment           | Render                             |
| Containerization     | Docker                             |

---

## 🗂️ Project Structure

```bash
Movie Review API/
│
├── Controllers/
│   └── MovieController.cs
│
├── DTOs/
│   ├── Movies/
│   │   ├── MovieInsertDTO.cs
│   │   ├── MovieUpdateDTO.cs
│   │   └── MovieGetDTO.cs
│   └── Reviews/
│       ├── ReviewInsertDTO.cs
│       └── ReviewGetDTO.cs
│
├── Models/
│   ├── Movie.cs
│   └── Review.cs
│
├── Repositories/
│   └── MovieRepositoryImpl.cs
│
├── Services/
│   └── Movies/
│       └── MovieServiceImpl.cs
│
├── Validators/
│   └── Movies/
│       ├── MovieInsertValidator.cs
│       └── MovieUpdateValidator.cs
│
├── Data/
│   └── AppDbContext.cs
│
├── Dockerfile
└── Program.cs
```

---

## ⚙️ Installation and Setup

### 1️⃣ Clone the repository

```bash
git clone https://github.com/<your-username>/Movie-Review-API.git
cd "Movie Review API"
```

### 2️⃣ Restore dependencies

```bash
dotnet restore
```

### 3️⃣ Run the application

```bash
dotnet run
```

By default, the app listens on **port 8080** (Render-compatible).

### 4️⃣ Test the endpoints

Use Postman or curl, for example:

```bash
GET https://movie-review-app-1-4avq.onrender.com/api/movies
```

---

## 🧪 Example Endpoints

| HTTP Method | Endpoint           | Description     |
| ----------- | ------------------ | --------------- |
| `GET`       | `/api/movies`      | Get all movies  |
| `GET`       | `/api/movies/{id}` | Get movie by ID |
| `POST`      | `/api/movies`      | Add a new movie |
| `PUT`       | `/api/movies/{id}` | Update a movie  |
| `DELETE`    | `/api/movies/{id}` | Delete a movie  |

---

## 🧰 Environment Variables

You can define these in your Render dashboard or `.env` file:

```
ConnectionStrings__DefaultConnection=your_database_connection_string
ASPNETCORE_ENVIRONMENT=Production
```

---

## 🐳 Docker Support

To build and run using Docker:

```bash
docker build -t movie-review-api .
docker run -p 8080:8080 movie-review-api
```
---

## 🪪 License

This project is licensed under the MIT License — see the [LICENSE](LICENSE) file for details.
