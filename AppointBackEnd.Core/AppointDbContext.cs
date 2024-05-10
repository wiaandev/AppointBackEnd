namespace AppointBackEnd.Core;

using AppointBackEnd.Core.Entities.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


public class AppointDbContext : IdentityDbContext<User, IdentityRole<int>, int>
{
    public AppointDbContext(DbContextOptions options)
        : base(options)
    {
    }

    // TODO: Set tables / entities

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // TODO: Add entity relationships
    }
}