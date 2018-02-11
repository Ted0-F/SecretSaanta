using SecretSantaa.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecretSaanta.DataAccess.LocalImpl
{
    public class SessionsRepoLocal : SessionsRepo
    {
        public System.Threading.Tasks.Task<string> createSession(SecretSantaa.Models.User aUser)
        {
            throw new NotImplementedException();
        }

        public void deleteSession(string aUsername, string aSession)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<string> getUsername(string aSession)
        {
            throw new NotImplementedException();
        }
    }
}