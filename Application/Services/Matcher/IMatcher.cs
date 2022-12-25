using Domain.Entities;

namespace Application.Services.Matcher;

public interface IMatcher
{
    public Task<UserProfile?> GetRecommendedUserProfile(long profileId);
}