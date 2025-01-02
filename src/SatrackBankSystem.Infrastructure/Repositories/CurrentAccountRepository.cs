using Dapper;
using MediatR;
using SatrackBankSystem.Domain.Entities;
using SatrackBankSystem.Domain.Enums;
using SatrackBankSystem.Infrastructure.Interfaces;
using SatrackBankSystem.Infrastructure.Mappers;
using SatrackBankSystem.Infrastructure.Resources;
using System.Data;

namespace SatrackBankSystem.Infrastructure.Repositories
{
    public class CurrentAccountRepository : IFinancialProductRepositoryBase, ICurrentAccountRepository
    {
        private readonly ISqlServerBase<dynamic> _sqlServerBase;

        public CurrentAccountRepository(ISqlServerBase<dynamic> sqlServerBase)
        {
            _sqlServerBase = sqlServerBase;
        }

        public async Task<Unit> CreateFinancialProduct(FinancialProduct product)
        {
            if (product is not CurrentAccount currentAccount)
            {
                throw new ArgumentException("El producto debe ser cuenta corriente.");
            }

            string sql = SqlResources.CreateCurrentAccount;

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ProductId", currentAccount.Id, DbType.Guid);
            parameters.Add("@IdentificationNumber", currentAccount.ClientId, DbType.String);
            parameters.Add("@ProductType", AccountType.Current, DbType.Int32);
            parameters.Add("@Balance", currentAccount.Balance, DbType.Decimal);

            await _sqlServerBase.ExecuteAsync(sql, parameters);

            return Unit.Value;
        }

        public async Task<Unit> ApplyTransaction(CurrentAccount currentAccount)
        {
            string sql = SqlResources.ApplyTransactionCurrent;

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ProductId", currentAccount.Id, DbType.Guid);
            parameters.Add("@Balance", currentAccount.Balance, DbType.Decimal);

            await _sqlServerBase.ExecuteAsync(sql, parameters);

            return Unit.Value;
        }

        public async Task<FinancialProduct?> GetById(Guid id)
        {
            string sql = SqlResources.GetCurrentAccountById;

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@AccountId", id, DbType.Guid);

            dynamic? result = await _sqlServerBase.QueryFirstOrDefaultAsync(sql, parameters);

            return result == null ? null : FinancialProductMapper.MapToFinancialProduct(result);
        }
    }
}
