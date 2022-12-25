using Domain.Enums;

namespace Domain.Entities;

public class UserProfile
{
    public UserProfile(int id, string name, Sex sex, string description, UserPreferenceSet preferences, UsersGroup group)
    {
        Id = id;
        Name = name;
        Sex = sex;
        Description = description;
        Preferences = preferences;
        UsersGroup = group;
    }

    private UserProfile()
    {
        //ef core
    }
    
    public long Id { get; }
    public string Name { get; set; }
    public Sex Sex { get; set; }
    public string Description { get; set; }
    public UserPreferenceSet Preferences { get; set; }

    public long UserGroupId { get; }
    public UsersGroup UsersGroup { get; }
}