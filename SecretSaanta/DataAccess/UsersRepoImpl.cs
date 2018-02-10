using SecretSaanta.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SecretSantaa.DataAccess
{
    public class UsersRepoImpl : BaseRepo, UsersRepo
    {

        async Task<List<Models.User>> UsersRepo.getUsers(string aSkip, string aTake, string aSortOrder, string aFilter)
        {
            List<Models.User> users = new List<Models.User>;
            using (var connection = CreateConnection())
            {

                await connection.OpenAsync();
                var command = connection.CreateCommand();
                command.CommandText = "select username, displayName  from Users" +
                                       "where username like ?filter" +
                                       "order by displayName ?sortOrder" +
                                       "offset ?skip fetch next ?take rows only";
                if (aSkip == null || aTake == null)
                {
                    command.CommandText = "select username, displayName  from Users" +
                                       "where username like ?filter" +
                                       "order by displayName ?sortOrder";
                }
                else
                {
                    command.Parameters.AddWithValue("?skip", aSkip);
                    command.Parameters.AddWithValue("?take", aTake);
                }
                command.Parameters.AddWithValue("?filter", aFilter != null ? aFilter : "");
                command.Parameters.AddWithValue("?aSortOrder", aSortOrder != null && aSortOrder == "ASC" ? aSortOrder : "DESC");


                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (reader.Read())
                    {
                        users.Add(new Models.User { username = reader.GetString(0), displayName = reader.GetString(1) });
                    }
                }
            }
            throw new NotImplementedException();
        }

        async Task<Models.User> UsersRepo.getUserByUsername(string aUsername)
        {
            Models.User user = null;
            using (var connection = CreateConnection())
            {
                
                await connection.OpenAsync();
                var command = connection.CreateCommand();
                command.CommandText = "select username, displayName  from Users" +
                                       "where username = ?username";
                command.Parameters.AddWithValue("?username", aUsername);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (reader.Read()) 
                    {
                        user = new Models.User{ username = reader.GetString(0), displayName = reader.GetString(1) };
                    }
                }
            }

            return user;
        }

        async void UsersRepo.createUser(Models.User aUser)
        {
            using (var connection = CreateConnection()) {
                
                await connection.OpenAsync();
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Users(username, displayname, password)" +
                                       "VALUES (?username, ?displayname, ?password)";
                command.Parameters.AddWithValue("?username", aUser.username);
                command.Parameters.AddWithValue("?displayname", aUser.displayName);
                command.Parameters.AddWithValue("?password", aUser.password);
                await command.ExecuteNonQueryAsync();
            }

        }
    }
}