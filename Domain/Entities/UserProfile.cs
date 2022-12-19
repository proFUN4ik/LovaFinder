namespace Domain.Entities;

public class UserProfile
{
    public UserProfile(int id, string name, string description, UsersGroup group)
    {
        Id = id;
        Name = name;
        Description = description;
        UsersGroup = group;
    }
    
    public long Id { get; }
    public string Name { get; set; }
    public string Description { get; set; }

    public long UserGroupId { get; }
    public UsersGroup UsersGroup { get; }
}