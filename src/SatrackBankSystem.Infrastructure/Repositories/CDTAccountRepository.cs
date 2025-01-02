using Dapper;
using MediatR;
using SatrackBankSystem.Domain.Entities;
using SatrackBankSystem.Domain.Enums;
using SatrackBankSystem.Infrastructure.Interfaces;
using SatrackBankSystem.Infrastructure.Resources;
using System.Data;

namespace SatrackBankSystem.Infrastructure.Repositories
{
    public class CDTAccountRepository : IFinancialProductRepositoryBase, ICDTAccountRepository
    {
        private readonly ISqlServerBase<dynamic> _sqlServerBase;

        public CDTAccountRepository(ISqlServerBase<dynamic> sqlServerBase)
        {
            _sqlServerBase = sqlServerBase;
        }

        public async Task<Unit> CancelCDT(Guid accountId)
        {
            string sql = SqlResources.CancelCDT;

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@AccountId", accountId, DbType.Guid);

            await _sqlServerBase.ExecuteAsync(sql, parameters);

            return Unit.Value;
        }

        public async Task<Unit> CreateFinancialProduct(FinancialProduct product)
        {
            if (product is not CDTAccount cdtAccount)
            {
                throw new ArgumentException("El producto debe ser cuenta CDT.");
            }

            string sql = SqlResources.CreateCDTAccount;

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ProductId", cdtAccount.Id, DbType.Guid);
            parameters.Add("@IdentificationNumber", cdtAccount.ClientId, DbType.String);
            parameters.Add("@ProductType", AccountType.CDT, DbType.Int32);
            parameters.Add("@InterestRate", cdtAccount.InterestRate, DbType.Decimal);
            parameters.Add("@DepositAmount", cdtAccount.DepositAmount, DbType.Decimal);
            parameters.Add("@MaturityDate", cdtAccount.MaturityDate, DbType.Date);

            await _sqlServerBase.ExecuteAsync(sql, parameters);

            return Unit.Value;
        }

        public Task<FinancialProduct?> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
