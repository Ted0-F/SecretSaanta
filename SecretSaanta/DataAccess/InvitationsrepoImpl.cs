using SecretSaanta.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecretSantaa.DataAccess
{
    public class InvitationsRepoImpl : BaseRepo, InvitationsRepo
    {
        List<Models.Invitation> InvitationsRepo.getInvitations(string username, string skip, string take, string sortOrder)
        {
            throw new NotImplementedException();
        }

        void InvitationsRepo.deleteInvitation(string username, string id)
        {
            throw new NotImplementedException();
        }

        string InvitationsRepo.createInvitation(Models.Invitation aInvitation)
        {
            throw new NotImplementedException();
        }
    }
}