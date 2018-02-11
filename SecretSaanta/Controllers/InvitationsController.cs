using SecretSaanta.Models.Views;
using SecretSantaa.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace SecretSantaa.Controllers
{
    public class InvitationsController : ApiController
    {
        private readonly InvitationsRepo mInvitationsRepo;

        public InvitationsController(InvitationsRepo aInvitationsRepo)
        {
            mInvitationsRepo = aInvitationsRepo;
        }

        [HttpGet]
        public async Task<List<InvitationView>> getInvitations([FromUri] string username)
        {
            var skip = HttpUtility.ParseQueryString(Request.RequestUri.Query).Get("skip");
            var take = HttpUtility.ParseQueryString(Request.RequestUri.Query).Get("take");
            var order = HttpUtility.ParseQueryString(Request.RequestUri.Query).Get("order");

            List<Models.Invitation> invitations = await mInvitationsRepo.getInvitations(username, skip, take, order);
            List<InvitationView> invitationsView = new List<InvitationView>();

            foreach (Models.Invitation invitation in invitations)
            {
                invitationsView.Add(
                        new InvitationView
                        { 
                            groupName = invitation.groupName, 
                            groupAdmin = invitation.groupAdminName, 
                            received = invitation.date, 
                            id = invitation.id
                        }
                    );
            }

            return invitationsView;
        }

        [HttpDelete]
        public void deleteInvitation([FromBody] string username, [FromUri] string id)
        {
            mInvitationsRepo.deleteInvitation(username, id);
        }

        [HttpPost]
        public async Task<InvitationView> createInvitation([FromBody] Models.Invitation aInvitation, [FromUri] string username)
        {
            aInvitation.username = username;
            string id = await mInvitationsRepo.createInvitation(aInvitation);
            return new InvitationView
            {
                groupName = aInvitation.groupName,
                groupAdmin = aInvitation.groupAdminName,
                received = aInvitation.date,
                id = id
            };
        }

    }
}
