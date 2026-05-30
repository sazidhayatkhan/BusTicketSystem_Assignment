using BusTicketSystem.Interfaces;
using BusTicketSystem.Models;

namespace BusTicketSystem.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public User RegisterUser(
        string fullName,
        string mobileNumber,
        string email)
    {
        ValidateUserInput(
            fullName,
            mobileNumber,
            email);

        var existingUser =
            _userRepository.GetByMobileNumber(mobileNumber);

        if (existingUser != null)
        {
            throw new Exception(
                "User already exists with this mobile number.");
        }

        var user = new User(
            fullName,
            mobileNumber,
            email);

        _userRepository.Add(user);

        return user;
    }

    private void ValidateUserInput(
        string fullName,
        string mobileNumber,
        string email)
    {
        if (string.IsNullOrWhiteSpace(fullName))
        {
            throw new Exception("Full name is required.");
        }

        if (string.IsNullOrWhiteSpace(mobileNumber))
        {
            throw new Exception("Mobile number is required.");
        }

        if (string.IsNullOrWhiteSpace(email))
        {
            throw new Exception("Email is required.");
        }
    }
}