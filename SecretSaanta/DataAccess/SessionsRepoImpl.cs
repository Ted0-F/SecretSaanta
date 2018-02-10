using SecretSaanta.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SecretSantaa.DataAccess
{
    public class SessionsRepoImpl : BaseRepo, SessionsRepo
    {
        async Task<string> SessionsRepo.createSession(Models.User aUser)
        {
            var sha512 = new SHA512CryptoServiceProvider();
            var sessionToken = BitConverter.ToString(sha512.ComputeHash(Encoding.ASCII.GetBytes(aUser.username)));
            using (var connection = CreateConnection())
            {

                await connection.OpenAsync();
                var command = connection.CreateCommand();
                command.CommandText = "insert into sessions(username, sessionToken)" +
                                       "values(?username, ?sessionToken)";
                command.Parameters.AddWithValue("?username", aUser.username);
                command.Parameters.AddWithValue("?sessionToken", sessionToken);

                await command.ExecuteNonQueryAsync();

            }
            return sessionToken;
        }

        async void SessionsRepo.deleteSession(string aUsername, string aSession)
        {
            using (var connection = CreateConnection())
            {

                await connection.OpenAsync();
                var command = connection.CreateCommand();
                command.CommandText = "select username from sessions" +
                                       "where session_token = ?sessionToken";
                command.Parameters.AddWithValue("?sessionToken", aSession);

                await command.ExecuteNonQueryAsync();
             
            }
        }

        async Task<string> SessionsRepo.getUsername(string aSession)
        {
            string username = null;
            using (var connection = CreateConnection())
            {

                await connection.OpenAsync();
                var command = connection.CreateCommand();
                command.CommandText = "select username from sessions" +
                                       "where session_token = ?sessionToken";
                command.Parameters.AddWithValue("?sessionToken", aSession);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (reader.Read())
                    {
                        username = reader.GetString(0);
                    }
                }
            }
            return username;
        }
    }
}