using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace learn_v2.Database
{
    public class MySqlDapper
    {
        private readonly string _ServerName;
        public MySqlDapper()
        {
            _ServerName = "Server=localhost;Port=3306;Database=aspnet;Uid=root;Pwd=root";
        }
        public IEnumerable<T> Query<T>(string sql, object param = null)
        {
            var sqlConnection = new MySqlConnection(_ServerName);
            using (var conn = sqlConnection)
            {
                return conn.Query<T>(sql, param);
            }
        }
        public IEnumerable<T> ExecuteProcedure<T>(string sql, object param = null)
        {
            var sqlConnection = new MySqlConnection(_ServerName);
            using (var conn = sqlConnection)
            {
                return conn.Query<T>(sql, param, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
