using SecretSantaa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSantaa.DataAccess
{
    public interface UsersRepo
    {
        async Task<List<User>> getUsers(string aSkip, string aTake, string aSortOrder, string aFilter);

        async Task<User> getUserByUsername(string aUsername);

        async void createUser(User aUser);
    }
}
