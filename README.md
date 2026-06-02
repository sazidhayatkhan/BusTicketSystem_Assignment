# Bus Ticket Booking & Billing System (Console App)

A C# Object-Oriented Console Application for managing a bus transportation system.  
This project demonstrates **OOP principles, SOLID design, layered architecture, and domain modeling**.

---

#  Features

##  User Management
- Create user with:
  - Full Name
  - Mobile Number (validated: 11 digits, starts with 01)
  - Email (basic validation)
- View all users
- Prevent duplicate users (by mobile number)

---

## Bus Management
- Add bus with:
  - Coach Number (must be unique)
  - Bus Type (ECONOMY / BUSINESS)
- Auto seat generation:
  - Economy → 40 seats
  - Business → 27 seats
- View all buses
- View available and booked seats

---

## Schedule Management
- Each bus can have multiple schedules
- Schedule includes:
  - Departure City
  - Arrival City
  - Departure Date & Time
  - Ticket Price
- View schedules by bus
- Each schedule is linked to a specific bus

---

# Architecture

The project follows a **layered architecture**:

- **UI Layer** → Console interaction (UserUI, BusUI, ScheduleUI)
- **Service Layer** → Business logic (UserService, BusService, ScheduleService)
- **Repository Layer** → In-memory data storage
- **Domain Layer** → Core models (User, Bus, Schedule, Seat)

---

# Project Structure

```
BusTicketSystem/
│
├── Models/
│   ├── User.cs
│   ├── Bus.cs
│   ├── Schedule.cs
│   ├── Seat.cs
│
├── Services/
│   ├── UserService.cs
│   ├── BusService.cs
│   ├── ScheduleService.cs
│
├── Repositories/
│   ├── UserRepository.cs
│   ├── BusRepository.cs
│   ├── ScheduleRepository.cs
│
├── Interfaces/
│   ├── IUserRepository.cs
│   ├── IBusRepository.cs
│   ├── IScheduleRepository.cs
│
├── UI/
│   ├── UserUI.cs
│   ├── BusUI.cs
│   ├── ScheduleUI.cs
│
├── Enums/
│   ├── BusType.cs
│
└── Program.cs
```


---

# How to Run

## 1. Clone the project
```bash
git clone <repo-url>

dotnet build

dotnet run

# Application Menu

=== Bus Ticket System ===
1. See all users
2. Add user
3. Add Bus
4. View Buses
5. Add Schedule
6. View Schedules by Bus
7. Exit
