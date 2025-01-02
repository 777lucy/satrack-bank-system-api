using SatrackBankSystem.Infrastructure.Dtos;

namespace SatrackBankSystem.Infrastructure.Mappers
{
    public static class GroupedTopClientsBalanceMapper
    {
        public static IEnumerable<GroupedTopClientsBalanceDto> ToGroupedTopClientsBalanceDtos(IEnumerable<dynamic> results)
        {
            List<GroupedTopClientsBalanceDto> groupedResults = new List<GroupedTopClientsBalanceDto>();

            foreach (IGrouping<dynamic, dynamic> group in results.GroupBy(x => x.ClientType))
            {
                GroupedTopClientsBalanceDto groupedDto = new GroupedTopClientsBalanceDto
                {
                    ClientType = group.Key,
                    Clients = group.Select(client => new ClientBalanceDto
                    {
                        ClientIdentification = client.ClientIdentification,
                        TotalBalance = client.TotalBalance
                    }).ToList()
                };

                groupedResults.Add(groupedDto);
            }

            return groupedResults;
        }
    }
}
