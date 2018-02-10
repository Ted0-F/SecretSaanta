using SecretSantaa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSantaa.DataAccess
{
    public interface GroupsRepo
    {

        async Task<List<Group>> getGroups(string aUsername, string aSkip, string aTake);

        async void createGroup(string aName, string aOwner);

        async Task<string> getAdmin(string aGroupName);

    }
}
