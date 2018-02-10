using SecretSaanta.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecretSantaa.DataAccess
{
    public class GroupsRepoImpl : BaseRepo, GroupsRepo
    {

        public async System.Threading.Tasks.Task<List<Models.Group>> getGroups(string aUsername, string aSkip, string aTake)
        {
            throw new NotImplementedException();
        }

        public async void createGroup(string aName, string aOwner)
        {
            throw new NotImplementedException();
        }

        public async System.Threading.Tasks.Task<string> getAdmin(string aGroupName)
        {
            throw new NotImplementedException();
        }
    }
}