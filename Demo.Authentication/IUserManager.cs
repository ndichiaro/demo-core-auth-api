using Demo.Model;

namespace Demo.Authentication
{
    public interface IUserManager
    {
        User CreateUser(string firstname, string lastname, string email, string password);
        User AuthenticateUser(string email, string password);
    }
}