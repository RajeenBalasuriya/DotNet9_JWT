using JwtDotNet.Entities;
using Microsoft.EntityFrameworkCore;

namespace JwtDotNet.Data;

public class UserDbContext(DbContextOptions<UserDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }

}
