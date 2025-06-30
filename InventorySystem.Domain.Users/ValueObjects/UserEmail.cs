using InventorySystem.Domain.Users.Constants;

namespace InventorySystem.Domain.Users.ValueObjects;

public class UserEmail
{
    public string Email { get; }

    private UserEmail(string email)
    {
        Email = email;
    }

    public static UserEmail FromString(string email)
    {
        if (!ValidEmail(email))
        {
            throw new ArgumentException("Invalid email");
        }
        return new UserEmail(email);
    }

    private static bool ValidEmail(string email)
    {   
        if (string.IsNullOrWhiteSpace(email))
        {
            return false;
        }
        
        var trimmedEmail = email.Trim();

        if (trimmedEmail.EndsWith('.') || trimmedEmail is { Length: > UserConstants.MaxEmailLength }) 
        {
            return false;
        }
        
        try {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == trimmedEmail;
        }
        catch {
            return false;
        }
    }
    
}