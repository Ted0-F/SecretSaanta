using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecretSaanta.DataAccess.LocalImpl
{
    public class ParticipantsRepoLocal : ParticipantsRepo
    {
        public void addParticipant(string aGroupName, string aUsername)
        {
            throw new NotImplementedException();
        }

        public void deleteParticipant(string aGroupName, string aUsername)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<List<SecretSantaa.Models.User>> getParticipants(string aGroupName)
        {
            throw new NotImplementedException();
        }
    }
}