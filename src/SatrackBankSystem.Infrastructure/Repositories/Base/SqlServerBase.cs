using Dapper;
using Microsoft.Data.SqlClient;
using SatrackBankSystem.Infrastructure.Interfaces;
using System.Data;

namespace SatrackBankSystem.Infrastructure.Repositories.Base
{
    public class SqlServerBase<T> : ISqlServerBase<T> where T : class
    {
        public string _connectionString;

        public SqlServerBase(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> ExecuteAsync(string sql, object parameters)
        {
            int affectedRows;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                affectedRows = await conn.ExecuteAsync(sql, parameters, commandTimeout: 120);
            }
            return affectedRows;
        }
        public async Task<T?> QueryFirstOrDefaultAsync(string sql)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                return await conn.QueryFirstOrDefaultAsync<T>(sql, commandTimeout: 120);
            }
        }

        public async Task<T?> QueryFirstOrDefaultAsync(string sql, object parameters)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                return await conn.QueryFirstOrDefaultAsync<T>(sql, parameters, commandTimeout: 120);
            }
        }

        public async Task<int> ExecuteScalarAsync(string sql, DynamicParameters parameters)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                return await connection.ExecuteScalarAsync<int>(sql, parameters);
            }
        }
        public async Task<IEnumerable<T>> ExecuteQueryAsync(string sql)
        {
            IEnumerable<T> rows = new List<T>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                rows = await connection.QueryAsync<T>(sql, commandTimeout: 120);
                connection.Close();
            }
            return rows;
        }
    }
}
