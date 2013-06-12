using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MVC4ValidationUsingFluentValidation.Models
{
    public interface IUserProfileRepository
    {
        void DeleteUserProfile(int userId);

        UserProfile GetUserProfileById(int userId);

        UserProfile GetUserProfileByUserName(string userName);

        IEnumerable<UserProfile> GetUserProfiles();

        void InsertUserProfile(UserProfile profile);

        void Save();

        void UpdateUserProfile(UserProfile profile);
    }

    public class UserProfileRepository : IUserProfileRepository, IDisposable
    {
        private readonly UsersContext context;
        private bool disposed;

        public UserProfileRepository(UsersContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            this.context = context;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<UserProfile> GetUserProfiles()
        {
            return context.UserProfiles.ToList();
        }

        public UserProfile GetUserProfileById(int userId)
        {
            return context.UserProfiles.Find(userId);
        }

        public UserProfile GetUserProfileByUserName(string userName)
        {
            return context.UserProfiles.FirstOrDefault(u => u.UserName == userName);
        }

        public void InsertUserProfile(UserProfile profile)
        {
            context.UserProfiles.Add(profile);
        }

        public void DeleteUserProfile(int userId)
        {
            UserProfile profile = context.UserProfiles.Find(userId);
            if (profile != null)
                context.UserProfiles.Remove(profile);
        }

        public void UpdateUserProfile(UserProfile profile)
        {
            context.Entry(profile)
                   .State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    context.Dispose();
            }
            disposed = true;
        }
    }
}