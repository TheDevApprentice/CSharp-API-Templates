using WebScrapper.DOMAIN.DTO;

namespace WebScrapper.DOMAIN
{
    /// <summary>
    /// Represents a service for managing users.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Gets a user by their username.
        /// </summary>
        User GetUserByUsernName(string name);

        /// <summary>
        /// Verifies if a user exists based on their token.
        /// </summary>
        User VerifyUserExist(string token);

        /// <summary>
        /// Gets a user by their email address.
        /// </summary>
        User GetUserByEmail(string email);

        /// <summary>
        /// Adds a new user.
        /// </summary>
        User AddUser(User user);

        /// <summary>
        /// Modifies an existing user.
        /// </summary>
        User ModifyUser(User user);

        /// <summary>
        /// Gets all users.
        /// </summary>
        List<User> GetAllUsers();

        /// <summary>
        /// Creates a new registered user.
        /// </summary>
        User CreateUserRegistered(RegisterationDTO registrationDTO, UserRequestHeaderInformation clientInformationScanner);

        /// <summary>
        /// Creates a new registered user with login information.
        /// </summary>
        User CreateUserRegisteredLogin(LoginDTO registrationDTO, UserRequestHeaderInformation clientInformationScanner, User usertoLogin);

        /// <summary>
        /// Verifies the password of a user during login.
        /// </summary>
        bool VerifyPassword(User userToLogin, LoginDTO loginDto);
    }
}