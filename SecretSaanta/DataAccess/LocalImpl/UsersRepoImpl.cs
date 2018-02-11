using SecretSantaa.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecretSaanta.DataAccess.LocalImpl
{
    public class UsersRepoImpl : UsersRepo
    {
        public System.Threading.Tasks.Task<List<SecretSantaa.Models.User>> getUsers(string aSkip, string aTake, string aSortOrder, string aFilter)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<SecretSantaa.Models.User> getUserByUsername(string aUsername)
        {
            throw new NotImplementedException();
        }

        public void createUser(SecretSantaa.Models.User aUser)
        {
            throw new NotImplementedException();
        }
    }
}