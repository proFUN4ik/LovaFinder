using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public interface ILoveFinderContext : IAsyncDisposable, IDisposable
{
    public DbSet<UsersGroup> UsersGroups { get; }
    public DbSet<UserProfile> UserProfiles { get; }
    public DbSet<UserProfileMatch> UserProfileMatches { get; }
    
    public Task<int> SaveChangesAsync(CancellationToken ct);
}