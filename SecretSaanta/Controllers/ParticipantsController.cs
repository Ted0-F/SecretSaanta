using SecretSaanta.DataAccess;
using SecretSaanta.Models.Views;
using SecretSantaa.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace SecretSantaa.Controllers
{
    public class ParticipantsController : ApiController
    {
        private readonly ParticipantsRepo mParticipantsRepo;
        private readonly SessionsRepo mSessionsRepo;
        private readonly GroupsRepo mGroupsRepo;

        public ParticipantsController(ParticipantsRepo aParticipantsRepo, SessionsRepo aSessionsRepo, GroupsRepo aGroupsRepo)
        {
            mParticipantsRepo = aParticipantsRepo;
            mSessionsRepo = aSessionsRepo;
            mGroupsRepo = aGroupsRepo;
        }

        [HttpDelete]
        public async void deleteParticipant([FromUri] string groupName, [FromUri] string username)
        {
            var headerKey = "xAuthToken";
            var headers = Request.Headers;

            var header = headers.GetValues(headerKey).FirstOrDefault(null);

            if (header != null)
            {
                string currentUsername = await mSessionsRepo.getUsername(header);
                string groupAdmin = await mGroupsRepo.getAdmin(groupName);
                if (currentUsername != null && groupAdmin != null && currentUsername == groupAdmin)
                {
                    mParticipantsRepo.deleteParticipant(groupName, username);
                }

            }
            throw new HttpResponseException(HttpStatusCode.BadRequest);
        }

        [HttpGet]
        public async Task<List<UserView>> getParticipants([FromUri] string groupName)
        {
            var headerKey = "xAuthToken";
            var headers = Request.Headers;

            //the header is checked to be present in the authentication filter
            var header = headers.GetValues(headerKey).FirstOrDefault(null);
            List<Models.User> participants;
            List<UserView> participantsView = null;

            string currentUsername = await mSessionsRepo.getUsername(header);
            string groupAdmin = await mGroupsRepo.getAdmin(groupName);
            if (currentUsername != null && groupAdmin != null && currentUsername == groupAdmin)
            {
                participants = await mParticipantsRepo.getParticipants(groupName);
                participantsView = new List<UserView>();
                foreach (Models.User participant in participants)
                {
                    participantsView.Add(new UserView { username = participant.username, displayName = participant.displayName });
                }
                return participantsView;
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.Forbidden);
            }


        }
        
        [HttpPost]
        public async void addParticipant([FromUri] string groupName, [FromBody] string username)
        {
            var headerKey = "xAuthToken";
            var headers = Request.Headers;

            var header = headers.GetValues(headerKey).FirstOrDefault(null);

            if (header != null)
            {
                string currentUsername = await mSessionsRepo.getUsername(header);
                string groupAdmin = await mGroupsRepo.getAdmin(groupName);
                if (currentUsername != null && groupAdmin != null && currentUsername == groupAdmin)
                {
                    mParticipantsRepo.addParticipant(groupName, username);
                }
            }
        }


    }
}
