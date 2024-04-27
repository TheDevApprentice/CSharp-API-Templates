namespace WebScrapper.DOMAIN;

public class Administrator : User
{
    public bool Active { get; set; }

    public Administrator(User user)
    {
        FirstName = user.FirstName;
        LastName = user.LastName;
        UserName = user.UserName;
        Email = user.Email;
        Password = user.Password;
        UserType = user.UserType;
        Token = user.Token;
        UserPasswordHashed = user.UserPasswordHashed;
        //Team = user.Team;
        UserRequestHeaderInformation = user.UserRequestHeaderInformation;
        TeamId = user.TeamId;

        Active = true;
        UserType = nameof(Guest);
    }

    public Administrator()
    {
        UserType = nameof(Administrator);
    }
}