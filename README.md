# Comrades Marathon Management System

A full-stack race management platform built for the **Comrades Marathon**. This project was developed for the PROG6212 POE (Portfolio of Evidence).

The solution consists of two main projects:
1. **ComradesMarathonAPI**: A RESTful Web API built with ASP.NET Core 8, Entity Framework Core, and SQL Server.
2. **ComradesMarathonMVC**: A front-end web application that consumes the API, built with ASP.NET Core MVC, Razor Views, and Bootstrap 5.

## Features

### Organiser Interface
- **Dashboard**: View all created events, total enrolments, and upcoming dates.
- **Event Management**: Create and edit events (Name, Description, Date, Location, Distance, Event Type).
- **Image Upload**: Upload event banner images securely to Azure Blob Storage (via the API).
- **Category Management**: Add age groups or distance categories to events.
- **Enrolments**: View all participants enrolled in a specific event.
- **Results**: Capture and publish finish times and positions for enrolled participants.

### Participant Interface
- **Home Page**: Browse upcoming events with filtering options (location/date).
- **Event Details**: View full event information and available categories.
- **Enrolment**: Enrol in a specific category for an event.
- **My Enrolments**: View a personal history of enrolled events and statuses (color-coded for Confirmed/Pending).
- **My Results**: View personal race history, including finish times and positions.
- **Profile**: View and update personal information.

## Tech Stack
- **Framework:** .NET 8.0 (ASP.NET Core Web API & MVC)
- **Database:** SQL Server / LocalDB (EF Core Code-First)
- **Authentication:** Session-based authentication via API cookies, forwarded through the MVC `HttpClient`.
- **Storage:** Azure Blob Storage (Azurite emulator supported for local dev).
- **Testing:** xUnit + EF Core InMemory.
- **CI/CD:** GitHub Actions.
- **Containerisation:** Docker.

---

## 🚀 Setup Instructions (Local Development)

### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) (with ASP.NET and web development workload)
- SQL Server Express or LocalDB

### 1. Clone the repository
```bash
git clone https://github.com/YOUR-USERNAME/YOUR-REPO.git
cd YOUR-REPO
