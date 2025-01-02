using Dapper;
using MediatR;
using SatrackBankSystem.Infrastructure.Interfaces;
using SatrackBankSystem.Infrastructure.Resources;
using System.Data;

namespace SatrackBankSystem.Infrastructure.Repositories
{
    public class IndividualClientRepository : IIndividualClientRepository
    {
        private readonly ISqlServerBase<dynamic> _sqlServerBase;

        public IndividualClientRepository(ISqlServerBase<dynamic> sqlServerBase)
        {
            _sqlServerBase = sqlServerBase;
        }

        public async Task<Unit> CreateClient(Client client)
        {
            if (client is not IndividualClient individualClient)
            {
                throw new ArgumentException("El cliente debe ser tipo persona.");
            }

            string sql = SqlResources.CreateIndividualClient;
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@IdentificationNumber", individualClient.Identification, DbType.String);
            parameters.Add("@Name", individualClient.Name, DbType.String);
            parameters.Add("@ClientType", individualClient.ClientType, DbType.Int32);

            await _sqlServerBase.ExecuteAsync(sql, parameters);

            return Unit.Value;
        }
    }
}
