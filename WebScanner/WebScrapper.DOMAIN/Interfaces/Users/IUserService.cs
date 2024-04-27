using WebScrapper.DOMAIN.DTO;

namespace WebScrapper.DOMAIN;

public interface IUserService
{
    User GetUserByUsernName(string name);
    User VerifyUserExist(string token);
    User GetUserByEmail(string email);
    User AddUser(User user);
    User ModifyUser(User user);
    List<User> GetAllUsers();

    User CreateUserRegistered(
        RegisterationDTO registrationDTO,
        UserRequestHeaderInformation clientInformationScanner
    );

    User CreateUserRegisteredLogin(
        LoginDTO registrationDTO,
        UserRequestHeaderInformation clientInformationScanner,
        User usertoLogin
    );

    bool VerifyPassword(
        User userToLogin,
        LoginDTO loginDto
    );
}