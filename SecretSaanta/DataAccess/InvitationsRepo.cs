using SecretSantaa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SecretSantaa.DataAccess
{
    public interface InvitationsRepo
    {

        async Task<List<Invitation>> getInvitations(string username, string skip, string take, string sortOrder);

        async void deleteInvitation(string username, string id);

        async Task<string> createInvitation(Invitation aInvitation);
    }
}