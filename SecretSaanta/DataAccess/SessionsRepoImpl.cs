using SecretSaanta.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecretSantaa.DataAccess
{
    public class SessionsRepoImpl : BaseRepo, SessionsRepo
    {
        string SessionsRepo.createSession(Models.User aUser)
        {
            throw new NotImplementedException();
        }

        void SessionsRepo.deleteSession(string aUsername, string aSession)
        {
            throw new NotImplementedException();
        }

        string SessionsRepo.getUsername(string aSession)
        {
            throw new NotImplementedException();
        }
    }
}