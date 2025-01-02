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
    public class SavingsAccountRepository : IFinancialProductRepositoryBase, ISavingsAccountRepository
    {
        private readonly ISqlServerBase<dynamic> _sqlServerBase;

        public SavingsAccountRepository(ISqlServerBase<dynamic> sqlServerBase)
        {
            _sqlServerBase = sqlServerBase;
        }

        public async Task<Unit> ApplyTransaction(SavingsAccount savingsAccount)
        {
            string sql = SqlResources.ApplyTransactionSavings;

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ProductId", savingsAccount.Id, DbType.Guid);
            parameters.Add("@Balance", savingsAccount.Balance, DbType.Decimal);

            await _sqlServerBase.ExecuteAsync(sql, parameters);

            return Unit.Value;
        }

        public async Task<Unit> CreateFinancialProduct(FinancialProduct product)
        {
            if (product is not SavingsAccount savingsAccount)
            {
                throw new ArgumentException("El producto debe ser cuenta de ahorros.");
            }

            string sql = SqlResources.CreateSavingsAccount;

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ProductId", savingsAccount.Id, DbType.Guid);
            parameters.Add("@IdentificationNumber", savingsAccount.ClientId, DbType.String);
            parameters.Add("@ProductType", AccountType.Savings, DbType.Int32);
            parameters.Add("@InterestRate", SavingsAccount._INTEREST_RATE, DbType.Decimal);
            parameters.Add("@Balance", savingsAccount.Balance, DbType.Decimal);

            await _sqlServerBase.ExecuteAsync(sql, parameters);

            return Unit.Value;
        }

        public async Task<FinancialProduct?> GetById(Guid id)
        {
            string sql = SqlResources.GetSavingsAccountById;

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@AccountId", id, DbType.Guid);

            dynamic? result = await _sqlServerBase.QueryFirstOrDefaultAsync(sql, parameters);

            return result == null ? null : FinancialProductMapper.MapToFinancialProduct(result);
        }

        public async Task<FinancialProduct?> GetByIdentification(string identification)
        {
            string sql = SqlResources.GetSavingsAccountByIdentification;

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Identification", identification, DbType.String);

            dynamic? result = await _sqlServerBase.QueryFirstOrDefaultAsync(sql, parameters);

            return result == null ? null : FinancialProductMapper.MapToFinancialProduct(result);
        }
    }
}
