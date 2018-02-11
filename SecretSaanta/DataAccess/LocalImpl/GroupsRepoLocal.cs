using SecretSantaa.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecretSaanta.DataAccess.LocalImpl
{
    public class GroupsRepoLocal : GroupsRepo
    {
        public System.Threading.Tasks.Task<List<SecretSantaa.Models.Group>> getGroups(string aUsername, string aSkip, string aTake)
        {
            throw new NotImplementedException();
        }

        public void createGroup(string aName, string aOwner)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<string> getAdmin(string aGroupName)
        {
            throw new NotImplementedException();
        }
    }
}