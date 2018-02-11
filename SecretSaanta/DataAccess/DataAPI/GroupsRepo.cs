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

        Task<List<Group>> getGroups(string aUsername, string aSkip, string aTake);

        void createGroup(string aName, string aOwner);

        Task<string> getAdmin(string aGroupName);

    }
}
