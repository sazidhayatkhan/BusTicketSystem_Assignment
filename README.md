# Bus Ticket Booking & Billing System (Console App)

A C# Object-Oriented Console Application for managing a bus transportation system.  
This project demonstrates **OOP principles, SOLID design, layered architecture, and domain modeling**.

---

# Features

## User Management

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

## Ticket Management

- Book ticket for a user on a specific schedule
- Select seat number during booking
- Prevent duplicate seat booking per schedule
- View tickets by:
  - User
  - Schedule
- Ticket contains:
  - Ticket ID
  - User ID
  - Schedule ID
  - Seat Number
  - Booking Date

---

# Architecture

The project follows a **layered architecture**:

- **UI Layer** → Console interaction (UserUI, BusUI, ScheduleUI, TicketUI)
- **Service Layer** → Business logic (UserService, BusService, ScheduleService, TicketService)
- **Repository Layer** → In-memory data storage
- **Domain Layer** → Core models (User, Bus, Schedule, Seat, Ticket)

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
│   ├── Ticket.cs
│
├── Services/
│   ├── UserService.cs
│   ├── BusService.cs
│   ├── ScheduleService.cs
│   ├── TicketService.cs
│
├── Repositories/
│   ├── UserRepository.cs
│   ├── BusRepository.cs
│   ├── ScheduleRepository.cs
│   ├── TicketRepository.cs
│
├── Interfaces/
│   ├── IUserRepository.cs
│   ├── IBusRepository.cs
│   ├── IScheduleRepository.cs
│   ├── ITicketRepository.cs
│
├── UI/
│   ├── UserUI.cs
│   ├── BusUI.cs
│   ├── ScheduleUI.cs
│   ├── TicketUI.cs
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
6. See All Schedules
7. View Schedule of Bus
8. Book Ticket
9. View User Tickets
10. View Schedule Tickets
11. Exit
```
