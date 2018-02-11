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
    public class LoginsController : ApiController
    {

        private readonly SessionsRepo mSessionsRepo;

        public LoginsController(SessionsRepo aSessionsRepo)
        {
            mSessionsRepo = aSessionsRepo;
        }

        [HttpPost]
        public async Task<SessionView> createSession(Models.User user)
        {
            SessionView session = new SessionView();

            string sessionToken = await mSessionsRepo.createSession(user);

            session.xAuthToken = sessionToken;
            return session;
        }

        [HttpDelete]
        public void deleteSession([FromUri] string username)
        {
            var headerKey = "xAuthToken";
            var headers = Request.Headers;

            var header = headers.GetValues(headerKey).FirstOrDefault(null);

            if (header != null)
            {
                mSessionsRepo.deleteSession(username, header);
            }

        }

    }
}
