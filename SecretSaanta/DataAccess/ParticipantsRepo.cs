using SecretSantaa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSaanta.DataAccess
{
    public interface ParticipantsRepo
    {

        void addParticipant(string aGroupName, string aUsername);

        void deleteParticipant(string aGroupName, string aUsername);

        List<User> getParticipants(string aGroupName);
    }
}
