using SecretSantaa.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecretSaanta.DataAccess.LocalImpl
{
    public class InvitationsRepoLocal : InvitationsRepo
    {
        public System.Threading.Tasks.Task<List<SecretSantaa.Models.Invitation>> getInvitations(string username, string skip, string take, string sortOrder)
        {
            throw new NotImplementedException();
        }

        public void deleteInvitation(string username, string id)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<string> createInvitation(SecretSantaa.Models.Invitation aInvitation)
        {
            throw new NotImplementedException();
        }
    }
}