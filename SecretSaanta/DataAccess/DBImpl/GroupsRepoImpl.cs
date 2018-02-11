using SecretSaanta.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecretSantaa.DataAccess
{
    public class GroupsRepoImpl : BaseRepo, GroupsRepo
    {

        public async System.Threading.Tasks.Task<List<Models.Group>> getGroups(string aUsername, string aSkip, string aTake)
        {
            List<Models.Group> groups = new List<Models.Group>();
            using (var connection = CreateConnection())
            {

                await connection.OpenAsync();
                var command = connection.CreateCommand();
                command.CommandText = "select groupName, adminName, linked from Groups " +
                                       "order by groupName ASC " +
                                       "offset ?skip fetch next ?take rows only ";
                if (aSkip == null || aTake == null)
                {
                    command.CommandText = command.CommandText = "select groupName, adminName, linked from Groups";
                }
                else
                {
                    command.Parameters.AddWithValue("?skip", aSkip);
                    command.Parameters.AddWithValue("?take", aTake);
                }


                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (reader.Read())
                    {
                        groups.Add(
                            new Models.Group{ 
                                name = reader.GetString(0), 
                                mOwner = new Models.User{ username = reader.GetString(1)}, 
                                mIsLinked = reader.GetBoolean(2) 
                            }
                        );

                    }
                }
            }
            return groups;
        }

        public async void createGroup(string aName, string aOwner)
        {
            using (var connection = CreateConnection())
            {

                await connection.OpenAsync();
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Groups(groupName, adminName, linked)" +
                                       "VALUES (?groupName, ?adminName, ?linked)";
                command.Parameters.AddWithValue("?groupName", aName);
                command.Parameters.AddWithValue("?adminName", aOwner);
                command.Parameters.AddWithValue("?linked", 0);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async System.Threading.Tasks.Task<string> getAdmin(string aGroupName)
        {
            string admin = null;
            using (var connection = CreateConnection())
            {

                await connection.OpenAsync();
                var command = connection.CreateCommand();
                command.CommandText = "select adminName from Groups " +
                                       "where groupName = ?groupName";
                command.Parameters.AddWithValue("?groupName", aGroupName);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (reader.Read())
                    {
                        admin = reader.GetString(0);
                    }
                }
            }

            return admin;
        }
    }
}