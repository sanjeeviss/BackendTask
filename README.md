# TaskInterview Backend API

A RESTful backend API built with **ASP.NET Core Web API** and **Entity Framework Core**, designed for a task/interview management system. This backend handles authentication, task management, session handling, and database operations.

---

## 🚀 Tech Stack

* **ASP.NET Core Web API (.NET)**
* **Entity Framework Core**
* **SQL Server**
* **Swagger (OpenAPI)**
* **Session Management**
* **CORS Enabled**

---

## 📁 Project Structure

```
TaskInterview/
│── Controllers/
│── Data/
│   └── AppDbContext.cs
│── Models/
│── Program.cs
│── appsettings.json
│── TaskInterview.csproj
│── .gitignore
```

---

## ⚙️ Configuration

### 🔹 Database Connection

Update your **appsettings.json**:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=TaskInterviewDB;Trusted_Connection=True;TrustServerCertificate=True"
}
```

---

## ▶️ How to Run the Project

### 1️⃣ Clone Repository

```bash
git clone https://github.com/sanjeeviss/BackendTask.git
cd BackendTask
```

### 2️⃣ Restore Packages

```bash
dotnet restore
```

### 3️⃣ Update Database (if migrations exist)

```bash
dotnet ef database update
```

### 4️⃣ Run Application

```bash
dotnet run
```

API will run at:

```
https://localhost:5074
```

Swagger UI:

```
https://localhost:5074/swagger
```

---

## 🌐 Frontend Integration

Frontend runs on:

```
http://localhost:5173
```

CORS is configured in **Program.cs** to allow frontend requests.

---

## 🔐 Features

* User Authentication (Login/Register)
* Task CRUD Operations
* Session Handling
* Secure API Endpoints
* Swagger API Documentation

---

## 📦 .gitignore (Important)

```
.vs/
bin/
obj/
*.user
*.suo
```

---

## 🧪 API Testing

You can test APIs using:

* Swagger UI
* Postman
* Frontend UI

---

## 👨‍💻 Author

**Sanjeevi P**
Backend Developer

---

## 📄 License

This project is for interview and learning purposes.

---

⭐ If you like this project, give it a star on GitHub!
