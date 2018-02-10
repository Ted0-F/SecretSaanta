using SecretSaanta.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecretSantaa.DataAccess
{
    public class InvitationsRepoImpl : BaseRepo, InvitationsRepo
    {

        public async System.Threading.Tasks.Task<List<Models.Invitation>> getInvitations(string username, string skip, string take, string sortOrder)
        {
            throw new NotImplementedException();
        }

        public async void deleteInvitation(string username, string id)
        {
            throw new NotImplementedException();
        }

        public async System.Threading.Tasks.Task<string> createInvitation(Models.Invitation aInvitation)
        {
            string id = Guid.NewGuid().ToString();
            throw new NotImplementedException();
        }
    }
}