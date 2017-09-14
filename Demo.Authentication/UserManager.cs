using System;
using System.Linq;
using Demo.Data.Mongo.Collections;
using Demo.Data.Mongo.Models;
using Domain = Demo.Model;
using Demo.Authentication.Security;
using Demo.Data.Mongo;

namespace Demo.Authentication
{
    public class UserManager : IUserManager
    {
        private UserCollection _userCollection;
        
        public UserManager(MongoDbContext context)
        {
            _userCollection = new UserCollection(context);
        }

        public Domain.User CreateUser(string firstname, string lastname, string email, string password)
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
            var result = _userCollection.Add(user);
            
            return new Domain.User
            {
                Id = result.Id,
                FirstName = result.FirstName,
                LastName = result.LastName,
                Email = result.Email,
                Created = DateTime.Now
            };
        }

        public Domain.User AuthenticateUser(string email, string password)
        {
            var result = _userCollection.Find(x => x.Email == email).FirstOrDefault();

            var user = new Domain.User
            {
                Id = result.Id,
                FirstName = result.FirstName,
                LastName = result.LastName,
                Email = result.Email,
                Created = DateTime.Now
            };

            if(result != null && SaltEncryption.ValidatePassword(password, result.Password)) return user;
            return null;
        }
    }
}