using Application.Data;
using Application.Services.DislikeService;
using Application.Services.LikeService;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Matcher;

public class Matcher : IMatcher
{
    private readonly ILoveFinderContext db;
    private readonly ILikeService likeService;
    private readonly IDislikeService dislikeService;

    public Matcher(ILoveFinderContext db, ILikeService likeService, IDislikeService dislikeService)
    {
        this.db = db;
        this.likeService = likeService;
        this.dislikeService = dislikeService;
    }
    
    public async Task<UserProfile?> GetRecommendedUserProfile(long profileId)
    {
        var userProfile = await db.UserProfiles
            .SingleOrDefaultAsync(p => p.Id == profileId);

        if (userProfile is null)
            throw new ArgumentException($"Profile not found with id: {profileId}");
        
        var likedUsers = await likeService.GetLikedProfileIds(profileId);

        if (likedUsers.Count != 0)
            return await db.UserProfiles.SingleAsync(p => p.Id == likedUsers.First());

        var dislikedProfiles = await dislikeService.GetDislikedProfileIds(profileId);

        var recommendedProfile = await db.UserProfiles
            .Where(p => p.UserGroupId == userProfile.UserGroupId)
            .Where(p => p.Id != profileId)
            .Where(p => !dislikedProfiles.Contains(p.Id))
            .Where(p => p.Sex == userProfile.Preferences.Sex)
            .SingleOrDefaultAsync();

        return recommendedProfile;
    }
}