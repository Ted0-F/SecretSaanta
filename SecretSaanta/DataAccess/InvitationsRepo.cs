using SecretSantaa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecretSantaa.DataAccess
{
    public interface InvitationsRepo
    {

        List<Invitation> getInvitations(string username, string skip, string take, string sortOrder);

        void deleteInvitation(string username, string id);

        string createInvitation(Invitation aInvitation);
    }
}