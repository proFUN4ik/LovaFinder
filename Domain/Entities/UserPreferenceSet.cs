using Domain.Enums;

namespace Domain.Entities;

public class UserPreferenceSet
{
    public UserPreferenceSet(Sex sex)
    {
        Sex = sex;
    }
    
    public Sex Sex { get; set; }
}