namespace WebScrapper.DOMAIN;

public class Guest : User
{
    public bool Active { get; set; }

    public Guest()
    {
        Active = true;
        UserType = nameof(Guest);
    }

    public Guest(User user)
    {
        FirstName = user.FirstName;
        LastName = user.LastName;
        UserName = user.UserName;
        Email = user.Email;
        Password = user.Password;
        UserType = user.UserType;
        Token = user.Token;
        UserPasswordHashed = user.UserPasswordHashed;
        UserRequestHeaderInformation = user.UserRequestHeaderInformation;
        TeamId = user.TeamId;

        Active = true;
        UserType = nameof(Guest);
    }

    public enum Experience
    {
        JUNIOR,
        SENIOR
    }
}