using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSantaa.DataAccess
{
    public interface SessionsRepo
    {

        string createSession(Models.User aUser);

        void deleteSession(string aUsername, string aSession);

        string getUsername(string aSession);
    }
}
