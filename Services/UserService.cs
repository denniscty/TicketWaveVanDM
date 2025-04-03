namespace TicketWave.Services;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TicketWave.Data; // Namespace where your DbContext is
using TicketWave.Models; // Namespace where your User model is

public class UserService
{
    private readonly TicketWaveContext _context;

    public UserService(TicketWaveContext context)
    {
        _context = context;
    }

    // Register a new user
    public bool RegisterUser(string username, string email, string password)
    {
        if (_context.Users.Any(u => u.Email == email || u.UserName == username))
        {
            return false; // Prevent duplicate users
        }

        PasswordHelper.CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

        User newUser = new User
        {
            UserName = username,
            Email = email,
            PasswordHash = Convert.ToBase64String(passwordHash), // Store Base64 hash
            Role = "User"
        };

        _context.Users.Add(newUser);
        _context.SaveChanges();
        return true;
    }

    // Authenticate User (Login)
    public User? AuthenticateUser(string email, string password)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == email);
        if (user == null) return null;

        byte[] storedHash = Convert.FromBase64String(user.PasswordHash);
        bool isValid = PasswordHelper.VerifyPasswordHash(password, storedHash, user.PasswordSalt);

        return isValid ? user : null;
    }

    // Get user by ID
    public User? GetUserById(int id)
    {
        return _context.Users.Find(id);
    }
}
