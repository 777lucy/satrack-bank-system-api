using Dapper;
using SatrackBankSystem.Domain.Enums;
using SatrackBankSystem.Infrastructure.Interfaces;
using SatrackBankSystem.Infrastructure.Resources;
using System.Data;

namespace SatrackBankSystem.Infrastructure.Services
{
    public class ValidationService : IValidationService
    {
        private readonly ISqlServerBase<dynamic> _sqlServerBase;

        public ValidationService(ISqlServerBase<dynamic> sqlServerBase)
        {
            _sqlServerBase = sqlServerBase;
        }

        public async Task<bool> ClientExist(string identification)
        {
            string sql = SqlResources.ClientExist;

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Identification", identification, DbType.String);

            int result = await _sqlServerBase.ExecuteScalarAsync(sql, parameters);

            return result > 0;
        }

        public async Task<bool> AccountExistByIdentificationAndAccountType(string identification, AccountType accountType)
        {
            string sql = SqlResources.AccountExist;

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Identification", identification, DbType.String);
            parameters.Add("@ProductType", accountType, DbType.Int32);

            int result = await _sqlServerBase.ExecuteScalarAsync(sql, parameters);

            return result > 0;
        }

        public async Task<bool> AccountExistByIdAndType(Guid id, AccountType accountType)
        {
            string sql = SqlResources.AccountExistByIdAndType;

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@AccountId", id, DbType.Guid);
            parameters.Add("@ProductType", accountType, DbType.Int32);

            int result = await _sqlServerBase.ExecuteScalarAsync(sql, parameters);

            return result > 0;
        }

        public async Task<bool> AccountExistByAccountId(Guid accountId)
        {
            string sql = SqlResources.AccountExistByAccountId;

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@AccountId", accountId, DbType.Guid);

            int result = await _sqlServerBase.ExecuteScalarAsync(sql, parameters);

            return result > 0;
        }

        public async Task<bool> HaveSavingsAccountByCDTAccount(Guid cdtAccountId)
        {
            string sql = SqlResources.HaveSavingsAccountByCDTAccount;

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CDTAccountId", cdtAccountId, DbType.Guid);

            int result = await _sqlServerBase.ExecuteScalarAsync(sql, parameters);

            return result > 0;
        }
    }
}
