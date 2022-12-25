using Application.Data;
using Domain.Entities;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class LoveFinderContext : DbContext, ILoveFinderContext
{
    public LoveFinderContext(DbContextOptions<LoveFinderContext> ctx) : base(ctx)
    {
        
    }

    public DbSet<UsersGroup> UsersGroups { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<UserProfileMatch> UserProfileMatches { get; set; }

    protected override void OnModelCreating(ModelBuilder m)
    {
        m.Entity<UserProfile>().HasKey(p => p.Id);
        m.Entity<UserProfile>().OwnsOne(p => p.Preferences);

        m.Entity<UsersGroup>().HasKey(g => g.Id);

        m.Entity<UserProfileMatch>().HasKey(m => m.Id);
        
        m.ToSnakeCase();
    }
}