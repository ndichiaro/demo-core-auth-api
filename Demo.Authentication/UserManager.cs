using System;
using Demo.Data.Mongo.Collections;
using Demo.Data.Mongo.Models;
using Demo.Model;

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
            var user = new User
            {
                FirstName = firstname,
                LastName = lastname,
                Email = email,
                Password = password,
                Created = DateTime.Now
            };
            return _userCollection.Add(user);
        }
    }
}