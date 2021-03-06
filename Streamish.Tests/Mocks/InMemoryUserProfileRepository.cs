using System;
using System.Collections.Generic;
using System.Linq;
using Streamish.Models;
using Streamish.Repositories;

namespace Streamish.Tests.Mocks
{
    class InMemoryUserProfileRepository : IUserProfileRepository
    {
        private readonly List<UserProfile> _data;

        public List<UserProfile> InternalData
        {
            get
            {
                return _data;
            }
        }

        public InMemoryUserProfileRepository(List<UserProfile> startingData)
        {
            _data = startingData;
        }

        public void Add(UserProfile userProfile)
        {
            var lastUser = _data.Last();
            userProfile.Id = lastUser.Id + 1;
            _data.Add(userProfile);
        }

        public void Delete(int id)
        {
            var userProfileToDelete = _data.FirstOrDefault(p => p.Id == id);
            if (userProfileToDelete == null)
            {
                return;
            }

            _data.Remove(userProfileToDelete);
        }

        public List<UserProfile> GetAll()
        {
            return _data;
        }

        public UserProfile GetById(int id)
        {
            return _data.FirstOrDefault(p => p.Id == id);
        }

        public void Update(UserProfile userProfile)
        {
            var currentuserProfile = _data.FirstOrDefault(p => p.Id == userProfile.Id);
            if (currentuserProfile == null)
            {
                return;
            }

            currentuserProfile.Name = userProfile.Name;
            currentuserProfile.Email = userProfile.Email;
            currentuserProfile.ImageUrl = userProfile.ImageUrl;
            currentuserProfile.DateCreated = userProfile.DateCreated;
        }
    }
}
