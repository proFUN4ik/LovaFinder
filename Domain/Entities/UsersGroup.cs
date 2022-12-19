namespace Domain.Entities;

public class UsersGroup
{
    public UsersGroup(int id, string tag, string name, string description, List<UserProfile> userProfiles)
    {
        Id = id;
        Tag = tag;
        Name = name;
        Description = description;
        UserProfiles = userProfiles;
    }

    private UsersGroup()
    {
        //ef core
    }
    
    public long Id { get; }
    public string Tag { get; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<UserProfile> UserProfiles { get; set; }
}