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

        async void addParticipant(string aGroupName, string aUsername);

        async void deleteParticipant(string aGroupName, string aUsername);

        async Task<List<User>> getParticipants(string aGroupName);
    }
}
