using BusTicketSystem.Enums;
using BusTicketSystem.Services;

namespace BusTicketSystem;

public static class DemoData
{
    public static void Seed(
        UserService userService,
        BusService busService,
        ScheduleService scheduleService)
    {
        // Users
        userService.RegisterUser(
            "Sazid Hasan",
            "01712345678",
            "sazid@gmail.com"
        );

        userService.RegisterUser(
            "John Doe",
            "01812345678",
            "john@gmail.com"
        );

        // Buses
        var bus1 = busService.CreateBus(
            "DHK-101",
            BusType.ECONOMY
        );

        var bus2 = busService.CreateBus(
            "DHK-201",
            BusType.BUSINESS
        );

        // Schedules
        scheduleService.CreateSchedule(
            bus1.BusId,
            "Dhaka",
            "Chattogram",
            new DateTime(2026, 6, 15, 8, 0, 0),
            1200
        );

        scheduleService.CreateSchedule(
            bus2.BusId,
            "Dhaka",
            "Cox's Bazar",
            new DateTime(2026, 6, 16, 22, 0, 0),
            1800
        );
    }
}