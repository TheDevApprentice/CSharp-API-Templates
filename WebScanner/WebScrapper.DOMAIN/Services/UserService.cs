using Microsoft.Extensions.Configuration;
using WebScrapper.DOMAIN.DTO;

namespace WebScrapper.DOMAIN;

public class UserService : IUserService
{
    private IUserRepo _repoUser;
    private IConfiguration _configuration;
    private EncryptionHelper _encryptionHelper;

    public UserService(
        IUserRepo userRepo,
        IConfiguration configuration
    )
    {
        _configuration = configuration;

        _encryptionHelper =
             new EncryptionHelper(configuration);

        _repoUser = userRepo;
    }

    public bool VerifyPassword(
        User userToLogin,
        LoginDTO loginDto
    )
    {
        if (!string.IsNullOrEmpty(loginDto.Password))
        {
            if (_encryptionHelper
                .VerifyPassword(
                    loginDto.Password,
                    userToLogin.UserPasswordHashed))
            {
                return true;
            }
        }

        return false;
    }

    public User CreateUserRegistered(
        RegisterationDTO registrationDTO,
        UserRequestHeaderInformation clientInformationScanner
    )
    {
        User newUser = new User()
        {
            FirstName = registrationDTO.FirstName,
            LastName = registrationDTO.LastName,
            UserName = registrationDTO.UserName,
            Email = registrationDTO.Email,
            UserType = nameof(RegistreredUser),
            Token = registrationDTO.Token,
            UserPasswordHashed = _encryptionHelper
                                   .HashPassword(registrationDTO.Password),
            UserRequestHeaderInformation = clientInformationScanner,
        };

        return newUser;
    }

    public User CreateUserRegisteredLogin(
        LoginDTO registrationDTO,
        UserRequestHeaderInformation clientInformationScanner,
        User usertoLogin
    )
    {
        User newUser = new User()
        {
            FirstName = usertoLogin.FirstName,
            LastName = usertoLogin.LastName,
            UserName = usertoLogin.UserName,
            Email = usertoLogin.Email,
            UserType = nameof(RegistreredUser),
            Token = registrationDTO.Token,
            UserPasswordHashed = _encryptionHelper
                                  .HashPassword(usertoLogin.Password),
            UserRequestHeaderInformation = clientInformationScanner,
        };

        return newUser;
    }

    public User AddUser(User user)
    {
        return _repoUser
                .AddUser(user);
    }

    public List<User> GetAllUsers()
    {
        return _repoUser
                .GetAllUsers();
    }

    public User GetUserByEmail(string email)
    {
        var userLogin = _repoUser
            .GetUserByEmail(email);

        if (userLogin != null)
        {
            if (userLogin.Email == "")
            {
                throw new ArgumentException(
                    "Please enter valid data for email and password");
            }

            return userLogin;
        }
        return null;
    }

    public User VerifyUserExist(string token)
    {
        var userLogin = _repoUser.VerifyUserExist(token);

        if (userLogin != null)
        {
            return userLogin;
        }

        return null;
    }

    public User GetUserByUsernName(string name)
    {
        User user = _repoUser.GetUserByUserName(name);

        if (user != null)
        {
            if (user.Email == "")
            {
                throw new ArgumentException(
                    "The user email cannot be empty.");
            }

            return user;
        }

        return null;
    }

    public User ModifyUser(User user)
    {
        var userToModified = _repoUser
            .ModifyUser(user);

        if (user.Email == ""
            ||
            user.UserPasswordHashed == "")
        {
            throw new ArgumentException(
                "The user you are trying to modify does not exist or cannot be found.");
        }

        return userToModified;
    }
}