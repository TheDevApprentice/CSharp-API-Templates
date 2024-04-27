using System.Text.Json.Serialization;

namespace WebScrapper.DOMAIN;

public class RegistreredUser : User
{
    public RegistreredUser(User user)
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
        UserType = nameof(RegistreredUser);
    }
    public RegistreredUser()
    {
        Active = true;
        UserType = nameof(RegistreredUser);
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Experience EmployeeExperience { get; set; }

    public enum Experience
    {
        JUNIOR,
        SENIOR
    }

    public bool Active { get; set; }
}