# Task Manager API

A RESTful **ASP.NET Core 9 Web API** for tracking tasks.  
Built with **Entity Framework Core**, **JWT Authentication**, and **N-Layer Architecture** principles. 

---

## 🚀 Features
- User registration & login with JWT authentication
- Role-permission based authorization (Admin, User)
- Tasks and groups management
- User creation of tasks and setting it to groups
- Swagger/OpenAPI documentation
- EF Core with code-first migrations
- Docker support for containerized deployment

---

## 🛠️ Tech Stack
- ASP.NET Core 9
- Entity Framework Core
- PostgreSQL
- Docker
- JWT Bearer Authentication
- Bcrypt
- Swagger
- N-Layer Architecture

## Getting Started

### 📋 Prerequisites
- .NET 9 SDK
- PostgreSQL

---

### ⚙️ Installation
```bash
git clone https://github.com/kozmamisha/TaskManagerApi.git
cd TaskManagerApi
dotnet build
```

---

### Run Database Migrations
```bash
dotnet ef database update
```

---

### Run the API
```bash
dotnet run --project TaskManagerApi
```

API will be available at:
👉 http://localhost:5000 (or configured port)
