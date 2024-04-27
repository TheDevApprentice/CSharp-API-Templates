namespace WebScrapper.DOMAIN;

public interface IUserRepo
{
    User GetUserByUserName(string name);
    User VerifyUserExist(string token);
    User GetUserByEmail(string email);
    User AddUser(User user);
    User ModifyUser(User user);
    List<User> GetAllUsers();
}