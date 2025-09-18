using System;
using JwtDotNet.Entities;
using JwtDotNet.Models;

namespace JwtDotNet.Services;

public interface IAuthService
{
    Task<User?> RegisterAsync(UserDto request);
    Task<string?> LoginAsync(UserDto request);

}
