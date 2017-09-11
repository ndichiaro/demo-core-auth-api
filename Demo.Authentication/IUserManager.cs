using Demo.Model;

namespace Demo.Authentication
{
    public interface IUserManager
    {
        IUser CreateUser(string firstname, string lastname, string email, string password);
    }
}