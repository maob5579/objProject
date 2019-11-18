using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MoodWcfService.Entities;
using MoodWcfService.Model;
using MoodWcfService.IServices;

namespace MoodWcfService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserService.svc or UserService.svc.cs at the Solution Explorer and start debugging.
    public class UserService : IUserService
    {
        public List<User_> GetAllUsers()
        {
            using (MFDatabaseEntities moodFullDb = new MFDatabaseEntities())
            {
                return moodFullDb.Users.Select(x => new User_
                {
                    UserId = x.UserId,
                    Username = x.Username,
                    Password = x.Password,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    UserType = x.UserType
                }).ToList();
            };
        }
        public User_ GetUserById(string userId)
        {
            using (MFDatabaseEntities moodFullDb = new MFDatabaseEntities())
            {
                int usernameID = Convert.ToInt32(userId);
                return moodFullDb.Users.Where(x => x.UserId == usernameID).Select(x => new User_
                {
                    UserId = x.UserId,
                    Username = x.Username,
                    Password = x.Password,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    UserType = x.UserType
                }).FirstOrDefault();
            }
        }

        public User_ SearchUser(string username, string password)
        {
            using (MFDatabaseEntities moodFullDb = new MFDatabaseEntities())
            {
                return moodFullDb.Users.Where(x => x.Username == username && x.Password == password).Select(x => new User_
                {
                    UserId = x.UserId,
                    Username = x.Username,
                    Password = x.Password,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    UserType = x.UserType
                }).FirstOrDefault();
            }
        }

        public bool CreateUser(User_ user)
        {
            using (MFDatabaseEntities moodFullDb = new MFDatabaseEntities())
            {
                try
                {
                    User xe = new User();
                    xe.Username = user.Username;
                    xe.Password = user.Password;
                    xe.FirstName = user.FirstName;
                    xe.LastName = user.LastName;
                    xe.UserType = user.UserType;
                    moodFullDb.Users.Add(xe);
                    moodFullDb.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool EditUser(User_ user)
        {
            using (MFDatabaseEntities moodFullDb = new MFDatabaseEntities())
            {
                try
                {
                    int usernameId = Convert.ToInt32(user.UserId);
                    User xe = moodFullDb.Users.Single(x => x.UserId == usernameId);
                    xe.Username = user.Username;
                    xe.Password = user.Password;
                    xe.FirstName = user.FirstName;
                    xe.LastName = user.LastName;
                    xe.UserType = user.UserType;
                    moodFullDb.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            };
        }
        public bool DeleteUser(User_ user)
        {
            using (MFDatabaseEntities moodFullDb = new MFDatabaseEntities())
            {
                try
                {
                    int usernameID = Convert.ToInt32(user.UserId);
                    User xe = moodFullDb.Users.Single(x => x.UserId == usernameID);
                    moodFullDb.Users.Remove(xe);
                    moodFullDb.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }

        }
    }
}
