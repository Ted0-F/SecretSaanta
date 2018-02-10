using SecretSaanta.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecretSantaa.DataAccess
{
    public class UsersRepoImpl : BaseRepo, UsersRepo
    {
        public void createUser(Models.User aUser)
        {
            //throw new NotImplementedException();
        }

        public Models.User getUserByUsername(string aUsername)
        {
            throw new NotImplementedException();
        }

        public List<Models.User> getUsers(string aSkip, string aTake, string aSortOrder, string aFilter)
        {
            throw new NotImplementedException();
        }

        List<Models.User> UsersRepo.getUsers(string aSkip, string aTake, string aSortOrder, string aFilter)
        {
            throw new NotImplementedException();
        }

        Models.User UsersRepo.getUserByUsername(string aUsername)
        {
            throw new NotImplementedException();
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