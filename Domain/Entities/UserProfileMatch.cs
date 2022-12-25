namespace Domain.Entities;

public class UserProfileMatch
{
    public UserProfileMatch(long id, long userProfileId, long foreignUserProfileId)
    {
        Id = id;
        UserProfileId = Math.Min(userProfileId, foreignUserProfileId);
        ForeignUserProfileId = Math.Max(userProfileId, foreignUserProfileId);
    }

    private UserProfileMatch()
    {
        //ef core
    }
    
    public long Id { get; }
    public long UserProfileId { get; }
    public UserProfile UserProfile { get; }
    
    public long ForeignUserProfileId { get; }
    public UserProfile ForeignUserProfile { get; }
}