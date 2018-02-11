using SecretSantaa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecretSaanta.DataAccess
{
    public class ParticipantsRepoImpl : BaseRepo, ParticipantsRepo
    {

        public async void addParticipant(string aGroupName, string aUsername)
        {
            using (var connection = CreateConnection())
            {

                await connection.OpenAsync();
                var command = connection.CreateCommand();
                command.CommandText = "insert into Participants(groupName, participantUsername)" +
                                       "values(?groupName, ?participantUsername)";
                command.Parameters.AddWithValue("?groupName", aGroupName);
                command.Parameters.AddWithValue("?participantUsername", aUsername);

                await command.ExecuteNonQueryAsync();

            }
        }

        public async void deleteParticipant(string aGroupName, string aUsername)
        {
            using (var connection = CreateConnection())
            {

                await connection.OpenAsync();
                var command = connection.CreateCommand();
                command.CommandText = "delete from Participants " +
                                       "where groupName = ?groupName and participantUsername = ?participantUsername";
                command.Parameters.AddWithValue("?groupName", aGroupName);
                command.Parameters.AddWithValue("?participantUsername", aUsername);

                await command.ExecuteNonQueryAsync();

            }
        }

        public async System.Threading.Tasks.Task<List<SecretSantaa.Models.User>> getParticipants(string aGroupName)
        {
            List<User> users = new List<User>();
            using (var connection = CreateConnection())
            {

                await connection.OpenAsync();
                var command = connection.CreateCommand();
                command.CommandText = "select participantUsername  from Participants " +
                                       "where groupName = ?groupName";
                command.Parameters.AddWithValue("?groupName", aGroupName);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (reader.Read())
                    {
                        users.Add( new User { username = reader.GetString(0) });
                    }
                }
            }

            return users;
        }
    }
}