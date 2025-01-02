using Dapper;
using SatrackBankSystem.Infrastructure.Dtos;
using SatrackBankSystem.Infrastructure.Interfaces;
using SatrackBankSystem.Infrastructure.Mappers;
using SatrackBankSystem.Infrastructure.Resources;
using System.Data;

namespace SatrackBankSystem.Infrastructure.Repositories
{
    public class FinancialProductsQueryRepository : IFinancialProductsQueryRepository
    {
        private readonly ISqlServerBase<dynamic> _sqlServerBase;

        public FinancialProductsQueryRepository(ISqlServerBase<dynamic> sqlServerBase)
        {
            _sqlServerBase = sqlServerBase;
        }

        public async Task<InterestProjectionDto?> GetInterestProjection(Guid accountId, int projectionMonths)
        {
            string sql = SqlResources.GetProjectionMonths;

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@AccountId", accountId, DbType.Guid);
            parameters.Add("@ProjectionMonths", projectionMonths, DbType.Int32);

            dynamic? result = await _sqlServerBase.QueryFirstOrDefaultAsync(sql, parameters);

            return result == null ? null : InterestProjectionMonthsMapper.dynamicTointerestProjectionDto(result);
        }
    }
}
