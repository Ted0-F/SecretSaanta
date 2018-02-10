using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecretSaanta.DataAccess
{
    public class ParticipantsRepoImpl : BaseRepo, ParticipantsRepo
    {
        void ParticipantsRepo.addParticipant(string aGroupName, string aUsername)
        {
            throw new NotImplementedException();
        }

        void ParticipantsRepo.deleteParticipant(string aGroupName, string aUsername)
        {
            throw new NotImplementedException();
        }

        List<SecretSantaa.Models.User> ParticipantsRepo.getParticipants(string aGroupName)
        {
            throw new NotImplementedException();
        }
    }
}