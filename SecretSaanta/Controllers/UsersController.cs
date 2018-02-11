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
    public class UsersController : ApiController
    {
        private readonly UsersRepo mUsersRepo;

        public UsersController(UsersRepo aUsersRepo)
        {
            mUsersRepo = aUsersRepo;
        }



        [HttpGet]
        public async Task<List<UserView>> getUsers()
        {
            var skip = HttpUtility.ParseQueryString(Request.RequestUri.Query).Get("skip");
            var take = HttpUtility.ParseQueryString(Request.RequestUri.Query).Get("take");
            var order = HttpUtility.ParseQueryString(Request.RequestUri.Query).Get("order");
            var search = HttpUtility.ParseQueryString(Request.RequestUri.Query).Get("search");

            List<Models.User> usersList = await mUsersRepo.getUsers(skip, take, order, search);
            List<UserView> usersViewList = new List<UserView>();
            foreach(Models.User user in usersList) {
                usersViewList.Add(new UserView { username = user.username, displayName = user.displayName });
            }

            return usersViewList;
        }

        [HttpGet]
        public async Task<UserView> getUser([FromUri] string username)
        {
            Models.User user = await mUsersRepo.getUserByUsername(username);
            return new UserView{ username = user.username, displayName = user.displayName };
        }

        [HttpPost]
        public UserView createUser(Models.User aUser)
        {
            aUser.setPassword(aUser.getPassword());

            mUsersRepo.createUser(aUser);

            return new UserView{ username = aUser.username, displayName = aUser.displayName };
        }
    }
}
