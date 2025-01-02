using Dapper;

namespace SatrackBankSystem.Infrastructure.Interfaces
{
    public interface ISqlServerBase<T> where T : class
    {
        Task<int> ExecuteAsync(string sql, object parameters);
        Task<T?> QueryFirstOrDefaultAsync(string sql, object parameters);
        Task<T?> QueryFirstOrDefaultAsync(string sql);
        Task<int> ExecuteScalarAsync(string sql, DynamicParameters parameters);
        Task<IEnumerable<T>> ExecuteQueryAsync(string sql);
    }
}
