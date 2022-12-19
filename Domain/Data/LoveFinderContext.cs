using Domain.Entities;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Domain.Data;

public class LoveFinderContext : DbContext
{
    public LoveFinderContext(DbContextOptions<LoveFinderContext> ctx) : base(ctx)
    {
        
    }

    public DbSet<UsersGroup> UsersGroups { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<UserProfileMatch> UserProfileMatches { get; set; }

    protected override void OnModelCreating(ModelBuilder m)
    {
        m.ToSnakeCase();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.ConfigureWarnings(b => b.Ignore(CoreEventId.RowLimitingOperationWithoutOrderByWarning));
    }
}