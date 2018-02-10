using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSantaa.DataAccess
{
    public interface SessionsRepo
    {

        async Task<string> createSession(Models.User aUser);

        async void deleteSession(string aUsername, string aSession);

        async Task<string> getUsername(string aSession);
    }
}
