namespace Domain.Entities;

public class UserProfileMatch
{
    public UserProfileMatch(long id, UserProfile userProfile, UserProfile foreignUserProfile)
    {
        Id = id;
        UserProfile = userProfile;
        ForeignUserProfile = foreignUserProfile;
    }
    
    public long Id { get; }
    public long UserProfileId { get; }
    public UserProfile UserProfile { get; }
    
    public long ForeignUserProfileId { get; }
    public UserProfile ForeignUserProfile { get; }
}