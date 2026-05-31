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

    public User RegisterUser(string fullName, string mobileNumber, string email)
    {
        ValidateUser(fullName, mobileNumber, email);

        var existingUserByMobile = _userRepository.GetByMobileNumber(mobileNumber);

        if (existingUserByMobile != null)
        {
            throw new Exception("User already exists with this mobile number");
        }

        var user = new User(fullName, mobileNumber, email);

        _userRepository.Add(user);

        return user;
    }
    private void ValidateUser(string fullName, string mobileNumber, string email)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            throw new Exception("Full name is required");

        ValidateMobile(mobileNumber);
        ValidateEmail(email);
    }

    private void ValidateMobile(string mobile)
    {
        if (string.IsNullOrWhiteSpace(mobile))
            throw new Exception("Mobile number is required");

        if (mobile.Length != 11)
            throw new Exception("Mobile number must be 11 digits");

        if (!mobile.StartsWith("01"))
            throw new Exception("Mobile number must start with 01");

        if (!mobile.All(char.IsDigit))
            throw new Exception("Mobile number must contain only digits");
    }
    
    private void ValidateEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new Exception("Email is required");

        if (!email.Contains("@") || !email.Contains("."))
            throw new Exception("Invalid email format");
    }
}