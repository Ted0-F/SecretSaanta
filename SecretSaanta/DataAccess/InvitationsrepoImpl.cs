using SecretSaanta.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecretSantaa.DataAccess
{
    public class InvitationsRepoImpl : BaseRepo, InvitationsRepo
    {

        public async System.Threading.Tasks.Task<List<Models.Invitation>> getInvitations(string username, string skip, string take, string sortOrder)
        {
            List<Models.Invitation> invitations = new List<Models.Invitation>();
            using (var connection = CreateConnection())
            {

                await connection.OpenAsync();
                var command = connection.CreateCommand();
                command.CommandText = "select groupName, issued, id  from Invitations" +
                                       "where invitedUsername = ?username";
                command.Parameters.AddWithValue("?username", username);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (reader.Read())
                    {
                        invitations.Add(
                            new Models.Invitation{ 
                                groupName = reader.GetString(0), 
                                date = reader.GetDateTime(1), 
                                id = reader.GetString(2)
                            }
                         );
                    }
                }
            }
            return invitations;


        }

        public async void deleteInvitation(string username, string id)
        {
            using (var connection = CreateConnection())
            {
                await connection.OpenAsync();
                var command = connection.CreateCommand();
                command.CommandText = "delete from Invitations where id = ?id";
                command.Parameters.AddWithValue("?id", id);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async System.Threading.Tasks.Task<string> createInvitation(Models.Invitation aInvitation)
        {
            string id = Guid.NewGuid().ToString();
            using (var connection = CreateConnection())
            {

                await connection.OpenAsync();
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Invitations(groupName, invitedUsername, id)" +
                                       "VALUES (?groupName, ?invitedUsername, ?id)";
                command.Parameters.AddWithValue("?groupName", aInvitation.groupName);
                command.Parameters.AddWithValue("?invitedUsername", aInvitation.username);
                command.Parameters.AddWithValue("?id", id);
                await command.ExecuteNonQueryAsync();
            }
            return id;
        }
    }
}