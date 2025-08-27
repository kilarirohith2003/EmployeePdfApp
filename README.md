# Employee PDF App

This is an **ASP.NET Core MVC application** that generates employee details in **PDF format**.  
It allows you to view employee data in a Razor view and download it as a PDF file.

---

## 🚀 Features
- View all employees with details (ID, Name, Department, Email, Salary).
- Generate a **PDF report** of employees.
- Built using **ASP.NET Core MVC** and **DinkToPdf** library.

---

## 🛠️ Technologies Used
- C#
- ASP.NET Core MVC
- Razor Views
- DinkToPdf (HTML to PDF conversion)
- Entity Framework Core (for data)

---

## 📂 Project Structure
EmployeePdfApp/
│-- Controllers/
│ └── EmployeesController.cs
│-- Models/
│ └── Employee.cs
│-- Views/
│ └── Employees/
│ ├── Index.cshtml
│ └── EmployeePdf.cshtml
│-- wwwroot/
│-- Program.cs
│-- Startup.cs (if applicable)
