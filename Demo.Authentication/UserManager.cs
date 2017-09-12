using System;
using System.Linq;
using Demo.Data.Mongo.Collections;
using Demo.Data.Mongo.Models;
using Demo.Model;
using Demo.Authentication.Security;

namespace Demo.Authentication
{
    public class UserManager : IUserManager
    {
        private UserCollection _userCollection;
        
        public UserManager(string connectionString)
        {
            _userCollection = new UserCollection(connectionString);
        }

        public IUser CreateUser(string firstname, string lastname, string email, string password)
        {
            var hash = SaltEncryption.Hash(password);
            var user = new User
            {
                FirstName = firstname,
                LastName = lastname,
                Email = email,
                Password = hash,
                Created = DateTime.Now
            };
            return _userCollection.Add(user);
        }

        public IUser AuthenticateUser(string email, string password)
        {
            var user = _userCollection.Find(x => x.Email == email).FirstOrDefault();
            if(user != null && SaltEncryption.ValidatePassword(password, user.Password)) return user;
            return null;
        }
    }
}