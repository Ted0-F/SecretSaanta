using SecretSaanta.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecretSantaa.DataAccess
{
    public class GroupsRepoImpl : BaseRepo, GroupsRepo
    {
        List<Models.Group> GroupsRepo.getGroups(string aUsername, string aSkip, string aTake)
        {
            throw new NotImplementedException();
        }

        void GroupsRepo.createGroup(string aName, string aOwner)
        {
            throw new NotImplementedException();
        }

        string GroupsRepo.getAdmin(string aGroupName)
        {
            throw new NotImplementedException();
        }
    }
}