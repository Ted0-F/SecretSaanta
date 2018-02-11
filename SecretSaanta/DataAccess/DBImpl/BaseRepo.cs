using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SecretSaanta.DataAccess
{
    public class BaseRepo
    {
        private string _connectionString;

        public BaseRepo()
        {
            _connectionString = ConfigurationManager.AppSettings["Db.ConnectionString"];
        }

        protected SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}