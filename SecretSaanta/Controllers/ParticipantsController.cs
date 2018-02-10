using SecretSaanta.DataAccess;
using SecretSantaa.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<Object> deleteParticipant([FromUri] string groupName, [FromUri] string username)
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
            return BadRequest();
        }

        [HttpGet]
        public async Task<Object> getParticipants([FromUri] string groupName)
        {
            var headerKey = "xAuthToken";
            var headers = Request.Headers;

            var header = headers.GetValues(headerKey).FirstOrDefault(null);
            List<Models.User> participants;
            List<Object> participantsView = null;

            if (header != null)
            {
                string currentUsername = await mSessionsRepo.getUsername(header);
                string groupAdmin = await mGroupsRepo.getAdmin(groupName);
                if (currentUsername != null && groupAdmin != null && currentUsername == groupAdmin)
                {
                    participants = await mParticipantsRepo.getParticipants(groupName);
                    participantsView = new List<Object>();
                    foreach (Models.User participant in participants)
                    {
                        participantsView.Add(new { username = participant.username, displayName = participant.displayName});
                    }
                }
                else
                {
                    //return Forbidden;
                }

            }
            //return BadRequest;
            return participantsView;

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
