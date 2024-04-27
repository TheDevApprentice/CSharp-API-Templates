using Microsoft.EntityFrameworkCore;
using WebScrapper.DOMAIN;

namespace WebScrapper.INFRA
{
    public class UserRepo : IUserRepo
    {
        private ApiDbContext _dbApiCbaCtf;

        public UserRepo(ApiDbContext dbApiCbaCtf)
        {
            _dbApiCbaCtf = dbApiCbaCtf;
        }

        public User AddUser(User user)
        {
            if (user.UserType == nameof(Guest))
            {
                user = _dbApiCbaCtf
                    .Set<Guest>()
                    .Add(new Guest(user)).Entity;

                _dbApiCbaCtf
                    .SaveChanges();
            }
            if (user.UserType == nameof(Administrator))
            {
                user = _dbApiCbaCtf
                    .Set<Administrator>()
                    .Add(new Administrator(user)).Entity;

                _dbApiCbaCtf
                    .SaveChanges();
            }
            if (user.UserType == nameof(RegistreredUser))
            {
                user = _dbApiCbaCtf
                    .Set<RegistreredUser>()
                    .Add(new RegistreredUser(user)).Entity;

                _dbApiCbaCtf
                    .SaveChanges();
            }

            return user;
        }

        public List<User> GetAllUsers()
        {
            var user_list = _dbApiCbaCtf.Users
                .Include(a => a.UserRequestHeaderInformation)
                .Distinct()
                .ToList();

            return user_list;
        }

        public User GetUserByEmail(string newEmail)
        {
            User email = _dbApiCbaCtf.Users
                .Where(email => email.Email == newEmail)
                .FirstOrDefault();

            if (email == null)
                return null;
            return email;
        }

        public User VerifyUserExist(string token)
        {
            User user = _dbApiCbaCtf.Users
                .Where(user => user.Token == token)
                .FirstOrDefault();

            if (user != null)
            {
                if (user.Token == "")
                {
                    throw new ArgumentException("There is no users with that token.");
                }

                return user;
            }
            return null;
        }

        public User GetUserByUserName(string newUsername)
        {
            User userName = _dbApiCbaCtf.Users
                .FirstOrDefault(userName => userName.FirstName == newUsername);

            if (userName == null)
                return null;
            return userName;
        }

        public User ModifyUser(User user)
        {
            User userToModify = _dbApiCbaCtf.Users
                .FirstOrDefault(e => e.UserName == user.UserName);

            if (userToModify != null) // login cause email would be already registered
            {
                var userModified = _dbApiCbaCtf.Users
                    .Remove(userToModify);

                var newUser = _dbApiCbaCtf.Users
                    .Add(new RegistreredUser(user)).Entity;

                _dbApiCbaCtf
                    .SaveChanges();

                return newUser;
            }
            else // registration cause token would be the same 
            {
                User userToModifys = _dbApiCbaCtf.Users
                     .FirstOrDefault(e => e.Token == user.Token);

                if (userToModifys != null)
                {
                    var userModified = _dbApiCbaCtf.Users
                        .Remove(userToModifys);

                    var newUser = _dbApiCbaCtf.Users
                        .Add(new RegistreredUser(user)).Entity;

                    _dbApiCbaCtf
                        .SaveChanges();

                    return newUser;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
