using System;
using Dapper;
using System.Collections.Generic;
using CarServiceScheduler.DataLayer.Interface;
using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace CarServiceScheduler.DataLayer
{
    public abstract class BaseDataAccess
    {
        private readonly IConfiguration _configuration;
        public BaseDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IDbConnection CreateDbConnection()
        {
            string _connectionString = _configuration.GetConnectionString("ConnStr");
            var connection = new SqlConnection(_connectionString);
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            return connection;
        }
        protected IEnumerable<T> ExecuteQuery<T>(string sql, object queryParameters)
        {
            IEnumerable<T> result;

            using (var c = CreateDbConnection())
            {
                result = c.Query<T>(sql, queryParameters);
            }

            return result;
        }
        protected void ExecuteNonQuery(string sql, object queryParameters)
        {

            using (var c = CreateDbConnection())
            {

                var result = c.Execute(sql, queryParameters, commandType: CommandType.Text);

            }

        }
    }
}
