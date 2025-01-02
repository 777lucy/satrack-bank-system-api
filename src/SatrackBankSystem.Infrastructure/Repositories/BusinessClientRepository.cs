using Dapper;
using MediatR;
using SatrackBankSystem.Infrastructure.Interfaces;
using SatrackBankSystem.Infrastructure.Resources;
using System.Data;

namespace SatrackBankSystem.Infrastructure.Repositories
{
    public class BusinessClientRepository : IBusinessClientRepository
    {
        private readonly ISqlServerBase<dynamic> _sqlServerBase;

        public BusinessClientRepository(ISqlServerBase<dynamic> sqlServerBase)
        {
            _sqlServerBase = sqlServerBase;
        }

        public async Task<Unit> CreateClient(Client client)
        {
            if (client is not BusinessClient businessClient)
            {
                throw new ArgumentException("El cliente debe ser tipo empresarial.");
            }

            string sql = SqlResources.CreateBusinessClient;

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@IdentificationNumber", businessClient.Identification, DbType.String);
            parameters.Add("@Name", businessClient.Name, DbType.String);
            parameters.Add("@ClientType", businessClient.ClientType, DbType.Int32);
            parameters.Add("@LegalRepresentativeId", businessClient.LegalRepresentative.Identification, DbType.String);
            parameters.Add("@LegalRepresentativeName", businessClient.LegalRepresentative.Name, DbType.String);
            parameters.Add("@LegalRepresentativePhone", businessClient.LegalRepresentative.Phone.Number, DbType.String);

            await _sqlServerBase.ExecuteAsync(sql, parameters);

            return Unit.Value;
        }
    }
}
