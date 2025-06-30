using InventorySystem.Domain.Users.Constants;

namespace InventorySystem.Domain.Users.ValueObjects;

public class UserName
{
    public string FirstName { get; }
    public string LastName { get; }

    private UserName(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    
    public static UserName FromFirstAndLastName(string firstName, string lastName)
    {
        if (!ValidName(firstName))
        {
            throw new ArgumentException("Invalid first name");
        }
        if (!ValidName(lastName))
        {
            throw new ArgumentException("Invalid last name");
        }
        return new UserName(firstName, lastName);
    }

    private static bool ValidName(string name)
    {
        var trimmedName = name.Trim().ToLower();

        if (string.IsNullOrEmpty(trimmedName) || trimmedName is { Length: < 2 or > UserConstants.MaxNameLength })
        {
            return false;
        }
        
        return true;
    }
}