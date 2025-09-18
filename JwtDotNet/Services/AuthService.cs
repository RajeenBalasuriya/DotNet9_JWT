using System;
using JwtDotNet.Data;
using JwtDotNet.Entities;
using JwtDotNet.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JwtDotNet.Services;

public class AuthService(UserDbContext context, IConfiguration configuration) : IAuthService
{
    // public Task<string?> LoginAsync(UserDto request)
    // {
    //      if (user.Username != request.Username)
    //         {
    //             return BadRequest("User not found.");
    //         }

    //         if (new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, request.Password) == PasswordVerificationResult.Failed)
    //         {
    //             return BadRequest("Wrong password.");
    //         }

    //         string token = CreateToken(user);
    //         return Ok(token);
    // }

    public async Task<User?> RegisterAsync(UserDto request)
    {

        if (await context.Users.AnyAsync(u => u.Username == request.Username))
        {
            return null;
        }
        var user = new User();
        var hashedPassword = new PasswordHasher<User>().HashPassword(user, request.Password);
        user.Username = request.Username;
        user.PasswordHash = hashedPassword;
        // Registration logic here (e.g., save user to database)
        user.Username = request.Username;
        user.PasswordHash = hashedPassword;

        context.Users.Add(user);

        //commit to database
        await context.SaveChangesAsync();
        
        return user;
    }
}
