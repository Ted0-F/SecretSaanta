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
    public class GroupsController : ApiController
    {
        private readonly GroupsRepo mGroupsRepo;
        private readonly SessionsRepo mSessionsRepo;

        public GroupsController(GroupsRepo aGroupsRepo, SessionsRepo aSessionsRepo)
        {
            mGroupsRepo = aGroupsRepo;
            mSessionsRepo = aSessionsRepo;
        }


        [HttpGet]
        public async Task<List<GroupView>> getGroups([FromUri] string username)
        {
            var skip = HttpUtility.ParseQueryString(Request.RequestUri.Query).Get("skip");
            var take = HttpUtility.ParseQueryString(Request.RequestUri.Query).Get("take");

            List<Models.Group> groups = await mGroupsRepo.getGroups(username, skip, take);
            List<GroupView> groupsView = new List<GroupView>();

            foreach (Models.Group group in groups)
            {
                groupsView.Add(new GroupView{ groupName = group.name, groupAdmin = group.mOwner.username, linked = group.mIsLinked });
            }

            return groupsView;
        }


        [HttpPost]
        public async Task<GroupView> createGroup(Models.Group aGroup) 
        {
            var headerKey = "xAuthToken";
            var headers = Request.Headers;

            var header = headers.GetValues(headerKey).FirstOrDefault(null);

                string username = await mSessionsRepo.getUsername(header);
                if (username != null)
                {
                    mGroupsRepo.createGroup(aGroup.name, username);
                    return new GroupView { groupName = aGroup.name, groupAdmin = username, linked = false };
                }
                else
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
            
        }

    }
}
